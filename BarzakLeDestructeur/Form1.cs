using System;
using System.Drawing;
using System.Windows.Forms;
using BarzakLeDestructeur.Jeu;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using BarzakLeDestructeur.App_Data;
using System.Threading;
using System.ComponentModel;
using BarzakLeDestructeur.Model.BouttonEtLabel;

namespace BarzakLeDestructeur
{
    public partial class Form1 : Form
    {

        Page page;

        public Form1()
        {
            InitializeComponent();
            page = Page.Instance;
            ActualisationTaille = new System.Windows.Forms.Timer();
            MiseEnPlacePanelJeu();
            page.Page1();

        }

        public static Panel PanelJeu;        
        private Panel MiseEnPlacePanelJeu()
        {
            PanelJeu = new Panel();
            PanelJeu.Dock = DockStyle.Fill;
            PanelJeu.Location = new Point(0, 0);
            PanelJeu.Name = "panel1";
            PanelJeu.Size = new Size(ClientSize.Width, ClientSize.Height);
            PanelJeu.Visible = true;
            PanelJeu.BackgroundImage = Properties.Resources.Orc;
            PanelJeu.BackgroundImageLayout = ImageLayout.Center ;
            Controls.Add(PanelJeu);
            return PanelJeu;
        }

        public static System.Windows.Forms.Timer ActualisationTaille;//à modifier
        public System.Windows.Forms.Timer CreationTimer()
        {
            ActualisationTaille.Interval = 100;
            ActualisationTaille.Tick += new System.EventHandler(ActualisationTaille_Tick);
            return ActualisationTaille;
        }
        public void ActualisationTaille_Tick(object sender, EventArgs e)
        {
            ActualisationTaille.Stop();
            Controls.Remove(PanelJeu);
            PanelJeu.Size = new Size(ClientSize.Width, ClientSize.Height);
            Controls.Add(PanelJeu);
        }        
    }
}
