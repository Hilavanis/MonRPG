﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarzakLeDestructeur.Joueur_et_Equipement;
using BarzakLeDestructeur.SystemeJeu;

namespace BarzakLeDestructeur.Monstres
{
    public class Gobelin : Monstre, INotifyPropertyChanged
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

        public static Gobelin Instance = null;

        public Gobelin(int PtVie) : base(PtVie)
        {
            AttaqueRapide = 10;
            AttaqueLourde = 15;
            Bouclier = 5;
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
                DelegAsync.MethAsyncTexteM("Le gobelin attaque avec sa massue!");
                Degats = AttaqueRapide;

            }
            else if (UneAttaque[Frappe] == AttaqueLourde)
            {
                DelegAsync.MethAsyncTexteM("Le gobelin ce prépare a te sauter dessus!");
                Degats = AttaqueLourde;
            }
            else if (UneAttaque[Frappe] == Bouclier)
            {
                DelegAsync.MethAsyncTexteM("Le gobelin jete une pierre!");
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
