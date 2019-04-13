using BarzakLeDestructeur.Joueur_et_Equipement;
using BarzakLeDestructeur.Model.BouttonEtLabel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarzakLeDestructeur.SystemeJeu
{
    public class DelegAsync
    {
        public static void MethAsyncTexteC(string s)
        {
            MesLabels.TexteCombat.Invoke(new MethodInvoker(delegate
            { MesLabels.TexteCombat.Text = s; }));
        }

        public static void MethAsyncTexteJ(string s)
        {
            MesLabels.TexteAttaqueJ.Invoke(new MethodInvoker(delegate
            { MesLabels.TexteAttaqueJ.Text = s; }));
        }

        public static void MethAsyncTexteM(string s)
        {
            MesLabels.TexteAttaqueM.Invoke(new MethodInvoker(delegate
            { MesLabels.TexteAttaqueM.Text = s; }));
        }

        public static void MethAsyncTexteR(string s)
        {
            MesLabels.TexteRecompense.Invoke(new MethodInvoker(delegate
            { MesLabels.TexteRecompense.Text = s; }));
        }

        public static void MethAsyncTexteT(string s)
        {
            MesLabels.Titre.Invoke(new MethodInvoker(delegate
            { MesLabels.Titre.Text = s; }));
        }
    }
}
