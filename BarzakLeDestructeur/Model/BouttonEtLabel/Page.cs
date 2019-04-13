using BarzakLeDestructeur.SystemeJeu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarzakLeDestructeur.Model.BouttonEtLabel
{
    public class Page
    {
        public int NumeroPage { get; private set; }
        MesLabels Labi = new MesLabels();
        MesBouttons Boutti = new MesBouttons();
        TirageJeu TJAleatoire;

        private static readonly Page instance = new Page();

        private Page()
        {
        }

        public static Page Instance
        {
            get
            {
                return instance;
            }
        }
        public void Page1()
        {
            Labi.L_Titre();
            Boutti.B_NouvellePartie();
            Boutti.B_Continue();
        }

        public void Page2()
        {
            Form1.PanelJeu.BackgroundImage = null;
            Form1.PanelJeu.Controls.Remove(MesBouttons.NouvellePartie);
            Form1.PanelJeu.Controls.Remove(MesBouttons.Continue);
            Form1.PanelJeu.Controls.Remove(MesLabels.Titre);
            Labi.L_Intro();
            Boutti.B_Suivant();

        }

        public void Page3()
        {
            Form1.PanelJeu.Controls.Remove(MesLabels.Intro);
            Form1.PanelJeu.Controls.Remove(MesBouttons.Suivant);
            Labi.L_PointsDeVies();
            Labi.L_PV();
            Labi.L_PointsDeManas();
            Labi.L_PM();
            Labi.L_PointsDeViesMonstre();
            Labi.L_PVM();
            Labi.L_TexteAttaqueJ();
            Labi.L_TexteAttaqueM();
            Labi.L_TexteCombat();
            Labi.L_TexteRecompense();
            Boutti.B_AttaqueRapide();
            Boutti.B_AttaqueLourde();
            Boutti.B_Bouclier();
            Boutti.B_AttaqueMagique();
            Boutti.B_Pause();
            //debut de l'histoire
            Page4();
        }

        public void Page4()
        {
            TJAleatoire = new TirageJeu();
            TJAleatoire.Tirage();
            PageCombat();
            TJAleatoire.Lancement();
        }

        public void PageCombat()
        {
            Labi.BindingPVm();
            MesBouttons.AttaqueRapide.Visible = true;
            MesBouttons.AttaqueLourde.Visible = true;
            MesBouttons.Bouclier.Visible = true;
            MesBouttons.AttaqueMagique.Visible = true;
            MesBouttons.Pause.Visible = true;
            MesLabels.PointsDeVies.Visible = true;
            MesLabels.PV.Visible = true;
            MesLabels.PointsDeManas.Visible = true;
            MesLabels.PM.Visible = true;
            MesLabels.PointsDeViesMonstre.Visible = true;
            MesLabels.PVM.Visible = true;
            MesLabels.TexteAttaqueJ.Visible = true;
            MesLabels.TexteAttaqueM.Text = "";
            MesLabels.TexteAttaqueM.Visible = true;
            MesLabels.TexteCombat.Text = "";
            MesLabels.TexteCombat.Visible = true;
            MesBouttons.CombatFinit.Visible = true;
        }

        public void PageCombatFinit()
        {
            MesBouttons.AttaqueRapide.Visible = false;
            MesBouttons.AttaqueLourde.Visible = false;
            MesBouttons.Bouclier.Visible = false;
            MesBouttons.AttaqueMagique.Visible = false;
            MesBouttons.Pause.Visible = false;
            MesLabels.TexteRecompense.Visible = true;
            Boutti.B_CombatFinit();
        }
        public void PageCombatFermer()
        {
            MesLabels.PointsDeVies.Visible = false;
            MesLabels.PV.Visible = false;
            MesLabels.PointsDeManas.Visible = false;
            MesLabels.PM.Visible = false;
            MesLabels.PointsDeViesMonstre.Visible = false;
            MesLabels.PVM.Visible = false;
            MesLabels.TexteAttaqueJ.Visible = false;
            MesLabels.TexteAttaqueM.Visible = false;
            MesLabels.TexteCombat.Visible = false;
            MesLabels.TexteRecompense.Visible = false;
            MesBouttons.CombatFinit.Visible = false;
            Page4();
        }
    }
}
