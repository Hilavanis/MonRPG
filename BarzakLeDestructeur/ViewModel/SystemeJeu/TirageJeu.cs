using BarzakLeDestructeur.Jeu;
using BarzakLeDestructeur.Model.BouttonEtLabel;
using BarzakLeDestructeur.Monstres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarzakLeDestructeur.SystemeJeu
{
    public class TirageJeu
    {
        Gobelin Gobi;
        Fantôme Bhou;
        Troll Trolly;
        BossBarzak Barzak;
        Page page = Page.Instance;
        public static int ChoixMonstre;

        public void Tirage()
        {
            int TirageMonstre = new Random().Next(1);
            if (TirageMonstre == 3)
            {
                ChoixMonstre = 4;
                BossBarzak.Instance = null;
                Barzak = new BossBarzak(300);
                BossBarzak.Instance = Barzak;
            }
            else if (TirageMonstre == 2)
            {
                ChoixMonstre = 3;
                Troll.Instance = null;
                Trolly = new Troll(200);
                Troll.Instance = Trolly;
            }
            else if (TirageMonstre == 1)
            {
                ChoixMonstre = 2;
                Fantôme.Instance = null;
                Bhou = new Fantôme(100);
                Fantôme.Instance = Bhou;
            }
            else if (TirageMonstre == 0)
            {
                ChoixMonstre = 1;
                Gobelin.Instance = null;
                Gobi = new Gobelin(50);
                Gobelin.Instance = Gobi;
            }
        }

        public void Lancement()
        {
            if (ChoixMonstre == 4)
            {                
                Task.Run(() => CombatBossBarzak.CombattreBossBarzak());                
            }
            else if (ChoixMonstre == 3)
            {
                Task.Run(() => CombatTroll.CombattreTroll());
            }
            else if (ChoixMonstre == 2)
            {
                Task.Run(() => CombatFantôme.CombattreFantôme());
            }
            else
            {
                Task.Run(() => CombatGobelin.CombattreGobelin());
            }
        }
    }
}
