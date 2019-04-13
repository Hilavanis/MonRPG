using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarzakLeDestructeur.Joueur_et_Equipement;

namespace BarzakLeDestructeur.Monstres
{
    public abstract class Monstre
    {
        [Key]
        public int MonstreId { get; protected set; }
        public int AttaqueRapide { get; protected set; }
        public int AttaqueLourde { get; protected set; }
        public int Bouclier { get; protected set; }
        public int Degats { get; protected set; }

        protected Monstre(int PtVie)
        {
        }        

        public abstract void SubirDegats(int valeur);

        public abstract void Attaque(Joueur joueur);        
    }
}
