using BarzakLeDestructeur.App_Data;
using BarzakLeDestructeur.Model.BouttonEtLabel;
using BarzakLeDestructeur.SystemeJeu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarzakLeDestructeur.Joueur_et_Equipement
{
    public class Joueur : INotifyPropertyChanged
    {
        //blabla
        //Caratéristique du personnage
        [Key]
        public string Perso { get; set; }
        private int _AttaqueRapide;
        public int AttaqueRapide { get => _AttaqueRapide; set => _AttaqueRapide = value; }
        private int _AttaqueLourde;
        public int AttaqueLourde { get => _AttaqueLourde; set => _AttaqueLourde = value; }
        private int _Bouclier;
        public int Bouclier { get => _Bouclier; set => _Bouclier = value; }
        private int _Magie;
        public int Magie { get => _Magie; set => _Magie = value; }
        private int _Degats;
        public int Degats { get => _Degats; set => _Degats = value; }
        private int _PieceDOr;
        public int PieceDOr { get => _PieceDOr; set => _PieceDOr = value; }
        private int _Niveau;
        public int Niveau { get => _Niveau; set => _Niveau = value; }
        private int _Experience;
        public int Experience { get => _Experience; set => _Experience = value; }
        private int _ExperienceMax;
        public int ExperienceMax { get => _ExperienceMax; private set => _ExperienceMax = value; }
        private int _VieMax;
        public int VieMax { get => _VieMax; private set => _VieMax = value; }
        private int _Vie;
        public int Vie
        {
            get { return _Vie; }
            set
            {
                if (value != _Vie)
                {
                    _Vie = value;
                    OnPropertyChanged("Vie");
                }
            }
        }
        private int _ManaMax;
        public int ManaMax { get => _ManaMax; private set => _ManaMax = value; }
        private int _Mana;
        public int Mana
        {
            get { return _Mana; }
            set
            {
                if (value != _Mana)
                {
                    _Mana = value;
                    OnPropertyChanged("Mana");
                }
            }
        }
        Query query;
        // Création du personnage
        public Joueur(int PtVie, int PtMana)
        {
            Perso = "Vivi";
            AttaqueRapide = 10;
            AttaqueLourde = 15;
            Bouclier = 5;
            Magie = 20;
            Vie = PtVie;
            VieMax = 100;
            Mana = PtMana;
            ManaMax = 6;
            Experience = 0;
            ExperienceMax = 15;
            Niveau = 1;
        }

        //Constructeur pour la database
        public Joueur() { }

        //Binding PV et PM
        protected virtual void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //Singleton
        public static Joueur Instance = null;

        //Variable modifiable
        public bool Vivant
        {
            get { return Vie > 0; }
        }

        public void SubitDegats(int valeur)
        {
            Vie -= valeur;
        }

        public void PieceDor(int or)
        {
            PieceDOr += or;
        }

        //Création potion de vie
        public void PotionDeVie()
        {
            int[] Potions = new int[] { 25, 25, 50, 50, 75, };
            int potions = new Random().Next(5);
            int soin = Potions[potions];
            if (Potions[potions] == 25)
            {
                Vie += soin;
                DelegAsync.MethAsyncTexteC("Tu viens de trouver une petite potion qui te rend 25 points de vie.");
                if (Vie >= VieMax)
                    Vie = VieMax;
            }
            else if (Potions[potions] == 75)
            {
                Vie += soin;
                DelegAsync.MethAsyncTexteC("Tu viens de trouver un élixir qui te rend 75 points de vie.");
                if (Vie >= VieMax)
                    Vie = VieMax;
            }
            else
            {
                Vie += soin;
                DelegAsync.MethAsyncTexteC("Tu viens de trouver une super potion qui te rend 50 points de vie.\n");
                if (Vie >= VieMax)
                    Vie = VieMax;
            }
        }

        public void NiveauGagner()
        {
            int ExperienceRestante;
            if (Experience >= ExperienceMax)
            {
                ExperienceRestante = Experience - ExperienceMax;
                Experience = ExperienceRestante;
                ExperienceMax *= 2;
                Niveau += 1;
                AttaqueRapide += 2;
                AttaqueLourde += 2;
                Bouclier += 2;
                Magie += 2;
                VieMax += 20;
                ManaMax += 2;
                DelegAsync.MethAsyncTexteM("Tu viens de passe niveau: " + Niveau);
            }
        }

        //Système de combats
        public void AttaqueR()
        {
            Query query = new Query();
            if (Mana >= ManaMax)
            {
                Mana = ManaMax;
            }
            else
            {
                Mana++;
            }
            Degats = AttaqueRapide;
            DelegAsync.MethAsyncTexteJ("Tu te lance dans un coup d'estoc rapide.");
        }

        public void AttaqueL()
        {
            Query query = new Query();
            if (Mana >= ManaMax)
            {
                Mana = ManaMax;
            }
            else
            {
                Mana++;
            }
            Degats = AttaqueLourde;
            DelegAsync.MethAsyncTexteJ("Tu envoie toute ta force dans une frappe lourde.");
        }

        public void AttaqueB()
        {
            Query query = new Query();
            if (Mana >= ManaMax)
            {
                Mana = ManaMax;
            }
            else
            {
                if (Mana == ManaMax - 1)
                    Mana += 1;
                else
                    Mana += 2;
            }
            Degats = Bouclier;
            DelegAsync.MethAsyncTexteJ("Tu repousse l'ennemie avec ton bouclier.");
        }

        public void AttaqueM()
        {
            Query query = new Query();
            Degats = Magie;
            Mana -= 6;
            query.SauvegardeDuJeu();
            DelegAsync.MethAsyncTexteJ("Tu concentre ton enegie pour lance ton sortilège.");
        }

        public void LibereAttaque()
        {
            //reinitialisation degats et boutton
            query = new Query();
            Degats = 0;
            DelegAsync.MethAsyncTexteJ("Reflexion");
            DelegAsync.MethAsyncTexteM("Ton ennemie prepare son attaque");
            DelegAsync.MethAsyncTexteC("");
            MesBouttons.AttaqueRapide.Enabled = true;
            MesBouttons.AttaqueLourde.Enabled = true;
            MesBouttons.Bouclier.Enabled = true;
            if (Mana >= 6)
            {
                MesBouttons.AttaqueMagique.Enabled = true;
            }
        }

        public void BlockAttaque()
        {
            MesBouttons.AttaqueRapide.Enabled = false;
            MesBouttons.AttaqueLourde.Enabled = false;
            MesBouttons.Bouclier.Enabled = false;
            MesBouttons.AttaqueMagique.Enabled = false;
        }

        public void UpVie()
        {
            Vie++;
            Vie--;
        }
    }
}
