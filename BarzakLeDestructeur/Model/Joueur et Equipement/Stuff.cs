using BarzakLeDestructeur.SystemeJeu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarzakLeDestructeur.Joueur_et_Equipement
{
    public class Stuff
    {
        public string ID;
        public string Nom;
        public int DegatPV;
        public bool Cumulable;
        public int QuantiteMax;
        public int Quantite;

        private static Stuff lot = null; //Instanciation singleton       

        public Stuff()
        {
            
        }

        public static Stuff Lotterie // Declaration singleton
        {
            get
            {
                if (lot == null)
                {
                    lot = new Stuff();
                }
                return lot;
            }
        }

        Joueur Vivi = Joueur.Instance;

        private static int[] Arme = new int[8];
        private static int arme = new Random().Next(6);

        public void EquipementLeger() // Arme petit monstre
        {
            Arme[arme] = new Random().Next(5);
            if (Arme[arme] == 3)
            {                
                DelegAsync.MethAsyncTexteR("Génial, une nouvelle épée plus tranchante.");
            }
            else if (Arme[arme] == 4)
            {                
                DelegAsync.MethAsyncTexteR("Super, un bouclier à pointe.");
            }
            else if (Arme[arme] == 2)
            {                
                DelegAsync.MethAsyncTexteR("Un livre de magie, magnifique!");
            }
            else
                DelegAsync.MethAsyncTexteR("Un Coffre! /n??? Vide? Qu'elle arnaque.");

        }
        public void EquipementLourd() // Arme gros monstre
        {
            Arme[arme] = new Random().Next(8);
            if (Arme[arme] == 2)
            {                
                DelegAsync.MethAsyncTexteR("Qu'est ce que?? un puissant livre de magie, cool.");
            }
            else if (Arme[arme] == 3)
            {
                DelegAsync.MethAsyncTexteR("Ho joie, une hache.");
            }
            else if (Arme[arme] == 4)
            {
                DelegAsync.MethAsyncTexteR("Hmmm, un espadon.");
            }
            else if (Arme[arme] == 5)
            {
                DelegAsync.MethAsyncTexteR("Trop cool! Un bouclier d'acier.");
            }
            else
                DelegAsync.MethAsyncTexteR("Un Coffre! /n??? Vide? Qu'elle arnaque.");
        }
    }
}
