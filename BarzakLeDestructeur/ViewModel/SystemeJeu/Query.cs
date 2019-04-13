using BarzakLeDestructeur.App_Data;
using BarzakLeDestructeur.Joueur_et_Equipement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarzakLeDestructeur.SystemeJeu
{
    public class Query
    {
        Joueur Vivi;

        //Creation donnée et sauvegarde
        public void NouveauPerso()
        {
            
            Vivi = new Joueur(100, 0);
            using (var db = new BarzakContext())
            {
                //Selection du type de personnage par attribut Perso
                var query = from data in db.Joueurs
                            orderby data.Perso
                            select data;
                //Chercher dans la database
                foreach (Joueur details in query)
                {
                    // Suppression Personnage Vivi si existant
                    if (details.Perso == "Vivi")
                    {
                        var DelVivi = db.Joueurs.First<Joueur>();
                        db.Joueurs.Remove(DelVivi);
                    }
                }
                //création ou recréation personnage et sauvergarde
                db.Joueurs.Add(Vivi);
                Joueur.Instance = Vivi;
                db.SaveChanges();
            }
        }

        //Charger Perso
        public void ChargerPerso()
        {
            using (var db = new BarzakContext())
            {
                //Selection du type de personnage par attribut Perso
                var query = from data in db.Joueurs
                            orderby data.Perso
                            select data;
                //Chercher dans la database
                foreach (Joueur details in query)
                {
                    // Suppression Personnage Vivi si existant
                    if (details.Perso == "Vivi")
                    {
                        var ChargeVivi = db.Joueurs.First<Joueur>();
                        Joueur.Instance = ChargeVivi;
                    }
                }
            }
        }
        //Sauvegarde
        public void SauvegardeDuJeu()
        {

            Vivi = Joueur.Instance;
            using (var db = new BarzakContext())
            {
                //Selection du type de personnage par attribut Perso
                var query = from data in db.Joueurs
                            orderby data.Perso
                            select data;
                //Chercher dans la database
                foreach (Joueur details in query)
                {
                    // Mise à jour du joueur
                    if (details.Perso == "Vivi")
                    {
                        var UpVivi = db.Joueurs.First<Joueur>();
                        UpVivi = Vivi;
                    }
                }
                //Sauvergarde
                db.SaveChanges();
            }
        }
    }
}
