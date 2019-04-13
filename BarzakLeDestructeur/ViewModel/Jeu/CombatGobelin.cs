using BarzakLeDestructeur.App_Data;
using BarzakLeDestructeur.Joueur_et_Equipement;
using BarzakLeDestructeur.Model.BouttonEtLabel;
using BarzakLeDestructeur.Monstres;
using BarzakLeDestructeur.SystemeJeu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarzakLeDestructeur.Jeu
{
    public class CombatGobelin
    {
        public static async void CombattreGobelin()
        {
            Joueur Vivi = Joueur.Instance;
            Gobelin Gobi = Gobelin.Instance;
            Query query = new Query();
            Page page = Page.Instance;
            bool jeu = true;

            DelegAsync.MethAsyncTexteJ("Combat: un gobelin.");
            await Task.Delay(2000);
            while (jeu)
            {
                while (Vivi.Vivant && Gobi.Vivant)
                {
                    Form1.PanelJeu.Invoke(new MethodInvoker(delegate { Vivi.LibereAttaque(); }));
                    MesBouttons.stop.WaitOne();
                    await Task.Delay(3000);
                    MesBouttons.stop.WaitOne();
                    Form1.PanelJeu.Invoke(new MethodInvoker(delegate { Vivi.BlockAttaque(); }));
                    Gobi.Attaque(Vivi);
                    if (Gobi.Degats == Gobi.AttaqueRapide && Vivi.Degats == Vivi.Bouclier || Gobi.Degats == Gobi.AttaqueLourde && Vivi.Degats == Vivi.AttaqueRapide || Gobi.Degats == Gobi.Bouclier && Vivi.Degats == Vivi.AttaqueLourde || Vivi.Degats == Vivi.Magie)
                    {
                        Gobi.SubirDegats(Vivi.Degats);
                        MesLabels.PVM.Invoke(new MethodInvoker(delegate { Gobi.UpMVie(); }));
                        if (Gobi.MVie > 0)
                        {
                            DelegAsync.MethAsyncTexteC("Ton attaque réussit.\n Il reste " +
                            Convert.ToString(Gobi.MVie) +
                            " point de vie au gobelin et tu en as encore " +
                            Convert.ToString(Vivi.Vie) +
                            " point de vies!");
                            await Task.Delay(3000);
                        }
                        else
                        {
                            DelegAsync.MethAsyncTexteJ("Le gobelin meurs!");
                            DelegAsync.MethAsyncTexteM("");
                        }
                    }
                    else if (Gobi.Degats == Gobi.AttaqueRapide && Vivi.Degats == Vivi.AttaqueLourde || Gobi.Degats == Gobi.AttaqueLourde && Vivi.Degats == Vivi.Bouclier || Gobi.Degats == Gobi.Bouclier && Vivi.Degats == Vivi.AttaqueRapide || Vivi.Degats == 0)
                    {
                        Vivi.SubitDegats(Gobi.Degats);
                        MesLabels.PV.Invoke(new MethodInvoker(delegate { Vivi.UpVie(); }));
                        if (Vivi.Vie > 0)
                        {
                            DelegAsync.MethAsyncTexteC("Le gobelin te touche.\nIl te reste " +
                            Convert.ToString(Vivi.Vie) +
                            " point de vie et le gobelin possède encore " +
                            Convert.ToString(Gobi.MVie) +
                            " point de vies!");
                            await Task.Delay(3000);
                        }
                        else
                        {
                            DelegAsync.MethAsyncTexteJ("Tu meurs!\nLe gobelin dance de joie!");
                            DelegAsync.MethAsyncTexteM("");
                        }
                    }
                    else
                    {
                        DelegAsync.MethAsyncTexteC("Le coup est contré!");
                        await Task.Delay(3000);
                    }
                    if (Vivi.Vivant && !Gobi.Vivant)
                    {
                        Vivi.Experience += 10;
                        Vivi.NiveauGagner();
                        Stuff stuff = Stuff.Lotterie;
                        stuff.EquipementLeger();
                        Vivi.PotionDeVie();
                        MesLabels.PV.Invoke(new MethodInvoker(delegate { Vivi.UpVie(); }));
                        query.SauvegardeDuJeu();
                        jeu = false;
                        Form1.PanelJeu.Invoke(new MethodInvoker(delegate { page.PageCombatFinit(); }));
                    }                    
                    else if (!Vivi.Vivant)
                    {
                        DelegAsync.MethAsyncTexteC("Perdu!!!");
                        jeu = false;
                    }
                }
            }
        }
    }
}
    

