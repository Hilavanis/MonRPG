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
    public class CombatBossBarzak
    {
        public static async void CombattreBossBarzak()
        {
            Joueur Vivi = Joueur.Instance;
            BossBarzak Barzak = BossBarzak.Instance;
            Query query = new Query();
            Page page = Page.Instance;
            bool jeu = true;
            

            DelegAsync.MethAsyncTexteJ("Combat: Barzak le roi des Orcs.");
            await Task.Delay(2000);
            while (jeu)
            {
                while (Vivi.Vivant && Barzak.Vivant)
                {
                    Form1.PanelJeu.Invoke(new MethodInvoker(delegate{ Vivi.LibereAttaque(); }));
                    MesBouttons.stop.WaitOne();
                    await Task.Delay(3000);
                    MesBouttons.stop.WaitOne();
                    Form1.PanelJeu.Invoke(new MethodInvoker(delegate { Vivi.BlockAttaque(); }));
                    Barzak.Attaque(Vivi);
                    if (Barzak.Degats == Barzak.AttaqueRapide && Vivi.Degats == Vivi.Bouclier || Barzak.Degats == Barzak.AttaqueLourde && Vivi.Degats == Vivi.AttaqueRapide || Barzak.Degats == Barzak.Bouclier && Vivi.Degats == Vivi.AttaqueLourde || Vivi.Degats == Vivi.Magie)
                    {
                        Barzak.SubirDegats(Vivi.Degats);
                        MesLabels.PVM.Invoke(new MethodInvoker(delegate { Barzak.UpMVie(); }));
                        if (Barzak.MVie > 0)
                        {
                            DelegAsync.MethAsyncTexteC("Ton attaque réussit.\nIl reste " +
                            Convert.ToString(Barzak.MVie) +
                            " point de vie à Barzak et tu en as encore " +
                            Convert.ToString(Vivi.Vie) +
                            " point de vies!");
                            await Task.Delay(3000);
                        }
                        else
                        {
                            DelegAsync.MethAsyncTexteJ("Barzak meurs!\nBravo!!!   Tu viens de porter le coup de grace a Barzak!");
                            DelegAsync.MethAsyncTexteM("");
                        }
                    }
                    else if (Barzak.Degats == Barzak.AttaqueRapide && Vivi.Degats == Vivi.AttaqueLourde || Barzak.Degats == Barzak.AttaqueLourde && Vivi.Degats == Vivi.Bouclier || Barzak.Degats == Barzak.Bouclier && Vivi.Degats == Vivi.AttaqueRapide || Barzak.Degats == Barzak.AttaqueMortel && Vivi.Degats == Vivi.Magie || Barzak.Degats == Barzak.AttaqueMortel)
                    {
                        Vivi.SubitDegats(Barzak.Degats);
                        MesLabels.PV.Invoke(new MethodInvoker(delegate { Vivi.UpVie(); }));
                        if (Vivi.Vie > 0)
                        {
                            DelegAsync.MethAsyncTexteC("Barzak te touche.\nIl te reste " +
                            Convert.ToString(Vivi.Vie) +
                            " point de vie et Barzak possède encore " +
                            Convert.ToString(Barzak.MVie) +
                            " point de vies!");
                            await Task.Delay(3000);
                        }
                        else
                        {
                            DelegAsync.MethAsyncTexteJ("Tu meurs!\nBarzak plante ta tête sur une pique!");
                            DelegAsync.MethAsyncTexteM("");
                        }
                    }
                    else
                    {
                        DelegAsync.MethAsyncTexteC("Le coup est contré!");
                        await Task.Delay(3000);
                    }
                    if (Vivi.Vivant && !Barzak.Vivant)
                    {
                        DelegAsync.MethAsyncTexteC("Victoire!!!\n\n/FIN/");
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
