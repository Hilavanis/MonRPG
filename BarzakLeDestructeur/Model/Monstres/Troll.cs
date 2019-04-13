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
    public class Troll : Monstre, INotifyPropertyChanged
    {
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

        public static Troll Instance = null;

        public Troll(int PtVie) : base(PtVie)
        {
            AttaqueRapide = 25;
            AttaqueLourde = 30;
            Bouclier = 40;
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
            int[] UneAttaque = new int[] { AttaqueRapide, AttaqueLourde, Bouclier };
            int Frappe = new Random().Next(3);
            if (UneAttaque[Frappe] == AttaqueRapide)
            {
                DelegAsync.MethAsyncTexteM("Le troll donne un coup de pied!");
                Degats = AttaqueRapide;

            }
            else if (UneAttaque[Frappe] == AttaqueLourde)
            {
                DelegAsync.MethAsyncTexteM("Le troll frappe avec sa masse!");
                Degats = AttaqueLourde;
            }
            else if (UneAttaque[Frappe] == Bouclier)
            {
                DelegAsync.MethAsyncTexteM("Le troll concencre une grosse frappe!");
                Degats = Bouclier;
            }
        }

        public void UpMVie()
        {
            MVie++;
            MVie--;
        }
    }
}
