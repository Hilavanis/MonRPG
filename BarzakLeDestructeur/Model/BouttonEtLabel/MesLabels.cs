using BarzakLeDestructeur.Joueur_et_Equipement;
using BarzakLeDestructeur.Monstres;
using BarzakLeDestructeur.SystemeJeu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarzakLeDestructeur.Model.BouttonEtLabel
{
    class MesLabels
    {
        Joueur Vivi;
        Gobelin Gobi;
        Fantôme Bhou;
        Troll Trolly;
        BossBarzak Barzak;

        public static Label Titre = new Label();
        public Label L_Titre()
        {
            Form1.PanelJeu.Controls.Add(Titre);
            Titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            Titre.Location = new System.Drawing.Point(0, 149);
            Titre.Name = "Titre";
            Titre.Size = new System.Drawing.Size(Form1.PanelJeu.Width, 71);
            Titre.TabIndex = 1;
            Titre.Text = "Barzak le destructeur";
            Titre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            return Titre;
        }
        public static Label Intro = new Label();
        public Label L_Intro()
        {
            Form1.PanelJeu.Controls.Add(Intro);
            Intro.Font = new Font("Microsoft Sans Serif", 20F);
            Intro.Location = new Point(0, 100);
            Intro.Name = "Intro";
            Intro.Size = new Size(Form1.PanelJeu.Width, 200);
            Intro.Text = "Choisit ton attaque via les bouttons\nA chaque tour tu gagne de la mana, qui te permet de lancer une attaque magique imparable\nTu marque des points a chaque monstre tuer\n";
            Intro.TextAlign = ContentAlignment.MiddleCenter;
            return Intro;
        }

        public static Label PointsDeVies = new Label();//texte
        public Label L_PointsDeVies()
        {
            Form1.PanelJeu.Controls.Add(PointsDeVies);
            PointsDeVies.AutoSize = true;
            PointsDeVies.TextAlign = ContentAlignment.MiddleCenter;
            PointsDeVies.Font = new Font("Microsoft Sans Serif", 20F);
            PointsDeVies.Text = "Points de vies: ";
            PointsDeVies.Name = "PointsDeVies";
            PointsDeVies.Visible = false;
            PointsDeVies.Location = new Point(Form1.PanelJeu.Width - Form1.PanelJeu.Width / 50 * 49, Form1.PanelJeu.Height - PointsDeVies.Height *3);
            return PointsDeVies;
        }

        public static Label PV = new Label();//chiffre
        public Label L_PV()
        {
            Vivi = Joueur.Instance;
            Form1.PanelJeu.Controls.Add(PV);
            PV.DataBindings.Add(new Binding("Text", Vivi, "Vie", true));
            PV.AutoSize = true;
            PV.Font = new Font("Microsoft Sans Serif", 20F);
            PV.ForeColor = Color.Red;
            PV.Name = "PtV";
            PV.TextAlign = ContentAlignment.MiddleCenter;
            PV.Visible = false;
            PV.Location = new Point(PointsDeVies.Location.X + PointsDeVies.Width + 10, PointsDeVies.Location.Y);
            return PV;
        }

        public static Label PointsDeManas = new Label();//texte
        public Label L_PointsDeManas()
        {
            Form1.PanelJeu.Controls.Add(PointsDeManas);
            PointsDeManas.AutoSize = true;
            PointsDeManas.Font = new Font("Microsoft Sans Serif", 20F);
            PointsDeManas.Name = "pointsDeManas";
            PointsDeManas.Text = "Points de manas: ";
            PointsDeManas.TextAlign = ContentAlignment.MiddleCenter;
            PointsDeManas.Visible = false;
            PointsDeManas.Location = new Point(Form1.PanelJeu.Width - Form1.PanelJeu.Width / 50 * 49, Form1.PanelJeu.Height - PointsDeVies.Height * 2);
            return PointsDeManas;
        }

        public static Label PM = new Label();//chiffre
        public Label L_PM()
        {
            Vivi = Joueur.Instance;
            Form1.PanelJeu.Controls.Add(PM);
            PM.AutoSize = true;
            PM.DataBindings.Add(new Binding("Text", Vivi, "Mana", true));
            PM.Font = new Font("Microsoft Sans Serif", 20F);
            PM.ForeColor = Color.Blue;
            PM.Name = "PM";
            PM.TextAlign = ContentAlignment.MiddleCenter;
            PM.Visible = false;
            PM.Location = new Point(PointsDeManas.Location.X + PointsDeManas.Width + 10, PointsDeManas.Location.Y);
            return PM;
        }

        public static Label PointsDeViesMonstre = new Label();//texte
        public Label L_PointsDeViesMonstre()
        {
            Form1.PanelJeu.Controls.Add(PointsDeViesMonstre);
            PointsDeViesMonstre.AutoSize = true;
            PointsDeViesMonstre.Font = new Font("Microsoft Sans Serif", 20F);
            PointsDeViesMonstre.Name = "PointsDeViesMonstre";
            PointsDeViesMonstre.Text = "points de vies de l'enemie: ";
            PointsDeViesMonstre.TextAlign = ContentAlignment.MiddleCenter;
            PointsDeViesMonstre.Visible = false;
            PointsDeViesMonstre.Location = new Point(Form1.PanelJeu.Width - Form1.PanelJeu.Width / 50 * 49, 30);
            return PointsDeViesMonstre;
        }

        public static Label PVM = new Label();//chiffre
        public Label L_PVM()
        {
            Form1.PanelJeu.Controls.Add(PVM);
            PVM.AutoSize = true;            
            PVM.Font = new Font("Microsoft Sans Serif", 20F);
            PVM.ForeColor = Color.Red;
            PVM.Name = "PVM";
            PVM.TextAlign = ContentAlignment.MiddleCenter;
            PVM.Visible = false;
            PVM.Location = new Point(PointsDeViesMonstre.Location.X + PointsDeViesMonstre.Width + 10, 30);
            return PVM;
        }
        public void BindingPVm()
        {
            PVM.DataBindings.Clear();
            if (TirageJeu.ChoixMonstre == 1)
            {
                Gobi = Gobelin.Instance;
                PVM.DataBindings.Add(new Binding("Text", Gobi, "MVie", true));
            }
            else if (TirageJeu.ChoixMonstre == 2)
            {
                Bhou = Fantôme.Instance;
                PVM.DataBindings.Add(new Binding("Text", Bhou, "MVie", true));
            }
            else if (TirageJeu.ChoixMonstre == 3)
            {
                Trolly = Troll.Instance;
                PVM.DataBindings.Add(new Binding("Text", Trolly, "MVie", true));
            }
            else if (TirageJeu.ChoixMonstre == 4)
            {
                Barzak = BossBarzak.Instance;
                PVM.DataBindings.Add(new Binding("Text", Barzak, "MVie", true));
            }
        }

        //Combat
        public static Label TexteAttaqueJ = new Label();
        public Label L_TexteAttaqueJ()
        {
            Form1.PanelJeu.Controls.Add(TexteAttaqueJ);
            TexteAttaqueJ.Font = new Font("Microsoft Sans Serif", 20F);
            TexteAttaqueJ.Location = new Point(0, 200);
            TexteAttaqueJ.Padding = new Padding(2, 0, 2, 0);
            TexteAttaqueJ.Size = new Size(Form1.PanelJeu.Width, 100);
            TexteAttaqueJ.Name = "TexteAttaqueJ";
            TexteAttaqueJ.Text = "";
            TexteAttaqueJ.TextAlign = ContentAlignment.MiddleCenter;
            TexteAttaqueJ.Visible = false;
            return TexteAttaqueJ;
        }

        public static Label TexteAttaqueM = new Label();
        public Label L_TexteAttaqueM()
        {
            Form1.PanelJeu.Controls.Add(TexteAttaqueM);
            TexteAttaqueM.Font = new Font("Microsoft Sans Serif", 20F);
            TexteAttaqueM.Location = new Point(0, 300);
            TexteAttaqueM.Padding = new Padding(2, 0, 2, 0);
            TexteAttaqueM.Size = new Size(Form1.PanelJeu.Width, 100);
            TexteAttaqueM.Name = "TexteAttaqueM";
            TexteAttaqueM.Text = "";
            TexteAttaqueM.TextAlign = ContentAlignment.MiddleCenter;
            TexteAttaqueM.Visible = false;
            return TexteAttaqueM;
        }

        public static Label TexteCombat = new Label();
        public Label L_TexteCombat()
        {
            Form1.PanelJeu.Controls.Add(TexteCombat);
            TexteCombat.Font = new Font("Microsoft Sans Serif", 20F);
            TexteCombat.Location = new Point(0, 400);
            TexteCombat.Padding = new Padding(2, 0, 2, 0);
            TexteCombat.Size = new Size(Form1.PanelJeu.Width, 100);
            TexteCombat.Name = "TexteCombat";
            TexteCombat.Text = "L'aventure commence";
            TexteCombat.TextAlign = ContentAlignment.MiddleCenter;
            TexteCombat.Visible = false;
            return TexteCombat;
        }

        public static Label TexteRecompense = new Label();
        public Label L_TexteRecompense()
        {
            Form1.PanelJeu.Controls.Add(TexteRecompense);
            TexteRecompense.Font = new Font("Microsoft Sans Serif", 20F);
            TexteRecompense.Location = new Point(0, 550);
            TexteRecompense.Padding = new Padding(2, 0, 2, 0);
            TexteRecompense.Size = new Size(Form1.PanelJeu.Width, 100);
            TexteRecompense.Name = "TexteRecompense";
            TexteRecompense.Text = "";
            TexteRecompense.TextAlign = ContentAlignment.MiddleCenter;
            TexteRecompense.Visible = false;
            return TexteRecompense;
        }        
    }
}
