using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarzakLeDestructeur.Joueur_et_Equipement;
using BarzakLeDestructeur.SystemeJeu;

namespace BarzakLeDestructeur.Monstres
{
    public class BossBarzak : Monstre, INotifyPropertyChanged
    {
        public int AttaqueMortel { get; private set; }
        private int _MVie;
        public int MVie
        {
            get { return _MVie; }
            set
            {
                if (value != _MVie)
                {
                    _MVie = value;
                    OnPropertyChanged("MVie");
                }
            }
        }

        public static BossBarzak Instance = null;

        public BossBarzak(int PtVie) : base(PtVie)
        {
            AttaqueRapide = 45;
            AttaqueLourde = 50;
            Bouclier = 40;
            AttaqueMortel = 100;
            MVie = PtVie;
        }

        protected virtual void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Vivant
        {
            get { return MVie > 0; }
        }

        public override void SubirDegats(int valeur)
        {
            MVie -= valeur;
        }

        public override void Attaque(Joueur joueur)
        {
            Degats = 0;
            int[] UneAttaque = new int[] { AttaqueRapide, AttaqueLourde, Bouclier, AttaqueMortel };
            int Frappe = new Random().Next(4);
            if (UneAttaque[Frappe] == AttaqueRapide)
            {
                DelegAsync.MethAsyncTexteM("Barzak crache du feu!");
                Degats = AttaqueRapide;

            }
            else if (UneAttaque[Frappe] == AttaqueLourde)
            {
                DelegAsync.MethAsyncTexteM("Barzak frappe avec sa hache!");
                Degats = AttaqueLourde;
            }
            else if (UneAttaque[Frappe] == Bouclier)
            {
                DelegAsync.MethAsyncTexteM("Barzak utilise son bouclier!");
                Degats = Bouclier;
            }
            else if (UneAttaque[Frappe] == AttaqueMortel)
            {
                DelegAsync.MethAsyncTexteM("Barzak déchaine toute sa puissance!");
                Degats = AttaqueMortel;
            }
        }

        public void UpMVie()
        {
            MVie++;
            MVie--;
        }
    }
}
