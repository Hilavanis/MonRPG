using BarzakLeDestructeur.Jeu;
using BarzakLeDestructeur.Joueur_et_Equipement;
using BarzakLeDestructeur.SystemeJeu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarzakLeDestructeur.Model.BouttonEtLabel
{
    class MesBouttons
    {
        Joueur Vivi;
        Query query;
        Page page ;

        //Démarrage
        public static Button NouvellePartie = new Button();
        public Button B_NouvellePartie()
        {
            Form1.PanelJeu.Controls.Add(NouvellePartie);
            NouvellePartie.BackColor = Color.Pink;
            NouvellePartie.Font = new Font("Microsoft Sans Serif", 20F);
            NouvellePartie.ForeColor = Color.Red;
            NouvellePartie.FlatAppearance.BorderSize = 0;
            NouvellePartie.FlatStyle = FlatStyle.Flat;
            NouvellePartie.Size = new Size(312, 63);
            NouvellePartie.Name = "NouvellePartie";
            NouvellePartie.TabIndex = 0;
            NouvellePartie.Text = "Nouvelle Partie";
            NouvellePartie.UseVisualStyleBackColor = false;
            NouvellePartie.Location = new Point(Form1.PanelJeu.Width / 2 - NouvellePartie.Width / 2, 700);
            NouvellePartie.Click += new EventHandler(NouvellePartie_Click);
            return NouvellePartie;
        }
        private void NouvellePartie_Click(object sender, EventArgs e)
        {
            page = Page.Instance;
            query = new Query();
            page.Page2();
            query.NouveauPerso();
        }

        public static Button Continue = new Button();
        public Button B_Continue()
        {
            Form1.PanelJeu.Controls.Add(Continue);
            Continue.BackColor = Color.Pink;
            Continue.Font = new Font("Microsoft Sans Serif", 20F);
            Continue.ForeColor = Color.Red;
            Continue.FlatAppearance.BorderSize = 0;
            Continue.FlatStyle = FlatStyle.Flat;
            Continue.Size = new Size(312, 63);
            Continue.Name = "BouttonContinue";
            Continue.TabIndex = 0;
            Continue.Text = "Continué";
            Continue.UseVisualStyleBackColor = false;
            Continue.Location = new Point((Form1.PanelJeu.Width / 2) - Continue.Width /2, 800);
            Continue.Click += new EventHandler(Continue_Click);
            return Continue;
        }
        private void Continue_Click(object sender, EventArgs e)
        {
            page = Page.Instance;
            query = new Query();
            page.Page2();
            query.ChargerPerso();
        }

        //Presentation
        public static Button Suivant = new Button();
        public Button B_Suivant()
        {
            Form1.PanelJeu.Controls.Add(Suivant);
            Suivant.AutoSize = true;
            Suivant.BackColor = Color.Transparent;
            Suivant.Font = new Font("Microsoft Sans Serif", 20F);
            Suivant.ForeColor = Color.Red;
            Suivant.Name = "Bouttonjouer";
            Suivant.Text = "Suivant";
            Suivant.UseVisualStyleBackColor = false;
            Suivant.Location = new Point(Form1.PanelJeu.Width / 2 - Suivant.Width / 2, 450);
            Suivant.Click += new EventHandler(B_Suivant_Click);
            return Suivant;
        }
        public void B_Suivant_Click(object sender, EventArgs e)
        {
            page = Page.Instance;
            page.Page3();
        }

        public static Button AttaqueRapide = new Button();
        public Button B_AttaqueRapide()
        {
            Form1.PanelJeu.Controls.Add(AttaqueRapide);
            AttaqueRapide.AutoSize = true;
            AttaqueRapide.BackColor = Color.Transparent;
            AttaqueRapide.Font = new Font("Microsoft Sans Serif", 20F);
            AttaqueRapide.ForeColor = Color.Red;
            AttaqueRapide.Name = "BouttonAttaqueRapide";
            AttaqueRapide.Text = "AttaqueRapide";
            AttaqueRapide.UseVisualStyleBackColor = false;
            AttaqueRapide.Enabled = false;
            AttaqueRapide.Visible = false;
            AttaqueRapide.Location = new Point(Form1.PanelJeu.Width - Form1.PanelJeu.Width /50 * 39, Form1.PanelJeu.Height - AttaqueRapide.Height - 10);
            AttaqueRapide.Click += new EventHandler(B_AttaqueRapide_Click);
            return AttaqueRapide;
        }
        //Choix attaque + desactivation boutton
        public void B_AttaqueRapide_Click(object sender, EventArgs e)
        {
            Vivi = Joueur.Instance;
            Vivi.AttaqueR();
            AttaqueRapide.Enabled = false;
            AttaqueLourde.Enabled = false;
            Bouclier.Enabled = false;
            AttaqueMagique.Enabled = false;
        }

        public static Button AttaqueLourde = new Button();
        public Button B_AttaqueLourde()
        {
            Form1.PanelJeu.Controls.Add(AttaqueLourde);
            AttaqueLourde.AutoSize = true;
            AttaqueLourde.BackColor = Color.Transparent;
            AttaqueLourde.Font = new Font("Microsoft Sans Serif", 20F);
            AttaqueLourde.ForeColor = Color.Red;
            AttaqueLourde.Name = "BouttonAttaqueLourde";
            AttaqueLourde.Text = "AttaqueLourde";
            AttaqueLourde.UseVisualStyleBackColor = false;
            AttaqueLourde.Enabled = false;
            AttaqueLourde.Visible = false;
            AttaqueLourde.Location = new Point(Form1.PanelJeu.Width - Form1.PanelJeu.Width / 50 * 29, Form1.PanelJeu.Height - AttaqueLourde.Height - 10);
            AttaqueLourde.Click += new EventHandler(B_AttaqueLourde_Click);
            return AttaqueLourde;
        }
        //Choix attaque + desactivation boutton
        public void B_AttaqueLourde_Click(object sender, EventArgs e)
        {
            Vivi = Joueur.Instance;
            Vivi.AttaqueL();
            AttaqueRapide.Enabled = false;
            AttaqueLourde.Enabled = false;
            Bouclier.Enabled = false;
            AttaqueMagique.Enabled = false;
        }

        public static Button Bouclier = new Button();
        public Button B_Bouclier()
        {
            Form1.PanelJeu.Controls.Add(Bouclier);
            Bouclier.AutoSize = true;
            Bouclier.BackColor = Color.Transparent;
            Bouclier.Font = new Font("Microsoft Sans Serif", 20F);
            Bouclier.ForeColor = Color.Red;
            Bouclier.Name = "BouttonBouclier";
            Bouclier.Text = "Bouclier";
            Bouclier.UseVisualStyleBackColor = false;
            Bouclier.Enabled = false;
            Bouclier.Visible = false;
            Bouclier.Location = new Point(Form1.PanelJeu.Width - Form1.PanelJeu.Width / 50 * 19, Form1.PanelJeu.Height - Bouclier.Height - 10);
            Bouclier.Click += new EventHandler(B_Bouclier_Click);
            return Bouclier;
        }
        //Choix attaque + desactivation boutton
        public void B_Bouclier_Click(object sender, EventArgs e)
        {
            Vivi = Joueur.Instance;
            Vivi.AttaqueB();
            AttaqueRapide.Enabled = false;
            AttaqueLourde.Enabled = false;
            Bouclier.Enabled = false;
            AttaqueMagique.Enabled = false;
        }

        public static Button AttaqueMagique = new Button();
        public Button B_AttaqueMagique()
        {
            Form1.PanelJeu.Controls.Add(AttaqueMagique);
            AttaqueMagique.AutoSize = true;
            AttaqueMagique.BackColor = Color.Transparent;
            AttaqueMagique.Font = new Font("Microsoft Sans Serif", 20F);
            AttaqueMagique.ForeColor = Color.Red;
            AttaqueMagique.Name = "BouttonAttaqueMagique";
            AttaqueMagique.Text = "AttaqueMagique";
            AttaqueMagique.UseVisualStyleBackColor = false;
            AttaqueMagique.Enabled = false;
            AttaqueMagique.Visible = false;
            AttaqueMagique.Location = new Point(Form1.PanelJeu.Width - Form1.PanelJeu.Width / 50 * 9, Form1.PanelJeu.Height - AttaqueMagique.Height -10);
            AttaqueMagique.Click += new EventHandler(B_AttaqueMagique_Click);
            return AttaqueMagique;
        }
        //Choix attaque + desactivation boutton
        public void B_AttaqueMagique_Click(object sender, EventArgs e)
        {
            Vivi = Joueur.Instance;
            Vivi.AttaqueM();
            AttaqueRapide.Enabled = false;
            AttaqueLourde.Enabled = false;
            Bouclier.Enabled = false;
            AttaqueMagique.Enabled = false;
        }

        //Continué aventure apres combat
        public static Button CombatFinit = new Button();
        public Button B_CombatFinit()
        {
            Form1.PanelJeu.Controls.Add(CombatFinit);
            CombatFinit.AutoSize = true;
            CombatFinit.BackColor = Color.Transparent;
            CombatFinit.Font = new Font("Microsoft Sans Serif", 20F);
            CombatFinit.ForeColor = Color.Red;
            CombatFinit.Name = "BouttonCombatFinit";
            CombatFinit.Text = "Fermer";
            CombatFinit.UseVisualStyleBackColor = false;
            CombatFinit.Location = new Point(Form1.PanelJeu.Width / 2 - CombatFinit.Width / 2, Form1.PanelJeu.Height - CombatFinit.Height - 10);
            CombatFinit.Click += new EventHandler(B_CombatFinit_Click);
            return CombatFinit;
        }

        public void B_CombatFinit_Click(object sender, EventArgs e)
        {
            page.PageCombatFermer();
        }

        //Pause du jeu
        public static Button Pause = new Button();
        public static ManualResetEvent stop = new ManualResetEvent(true);
        bool pause;

        public Button B_Pause()
        {
            Form1.PanelJeu.Controls.Add(Pause);
            Pause.AutoSize = true;
            Pause.BackColor = Color.Transparent;
            Pause.Font = new Font("Microsoft Sans Serif", 20F);
            Pause.Location = new Point(Form1.PanelJeu.Width - Pause.Width - 10, 30);
            Pause.ForeColor = Color.Red;
            Pause.Name = "Pause";
            Pause.Text = "||";
            Pause.UseVisualStyleBackColor = false;
            Pause.Click += new EventHandler(B_Pause_Click);
            return Pause;
        }        
        public void B_Pause_Click(object sender, EventArgs e)
        {
            if (!pause)
            {
                Pause.Text = "►";
                pause = true;
                stop.Reset();
            }
            else if (pause)
            {
                Pause.Text = "||";
                pause = false;
                stop.Set();
            }
        }        
    }
}
