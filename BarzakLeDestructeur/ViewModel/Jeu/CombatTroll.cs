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
    public class CombatTroll
    {
        public static async void CombattreTroll()
        {
            Joueur Vivi = Joueur.Instance;
            Troll Trolly = Troll.Instance;
            Query query = new Query();
            Page page = Page.Instance;
            bool jeu = true;

            DelegAsync.MethAsyncTexteJ("Combat: un troll.");
            await Task.Delay(2000);
            while (jeu)
            {
                while (Vivi.Vivant && Trolly.Vivant)
                {
                    Form1.PanelJeu.Invoke(new MethodInvoker(delegate{ Vivi.LibereAttaque(); }));
                    MesBouttons.stop.WaitOne();
                    await Task.Delay(3000);
                    MesBouttons.stop.WaitOne();
                    Form1.PanelJeu.Invoke(new MethodInvoker(delegate { Vivi.BlockAttaque(); }));
                    Trolly.Attaque(Vivi);
                    if (Trolly.Degats == Trolly.AttaqueRapide && Vivi.Degats == Vivi.Bouclier || Trolly.Degats == Trolly.AttaqueLourde && Vivi.Degats == Vivi.AttaqueRapide || Trolly.Degats == Trolly.Bouclier && Vivi.Degats == Vivi.AttaqueLourde || Vivi.Degats == Vivi.Magie)
                    {
                        Trolly.SubirDegats(Vivi.Degats);
                        MesLabels.PVM.Invoke(new MethodInvoker(delegate { Trolly.UpMVie(); }));
                        if (Trolly.MVie > 0)
                        {
                            DelegAsync.MethAsyncTexteC("Ton attaque réussit.\nIl reste " +
                            Convert.ToString(Trolly.MVie) +
                            " point de vie au troll et tu en as encore " +
                            Convert.ToString(Vivi.Vie) +
                            " point de vies!");
                            await Task.Delay(3000);
                        }
                        else
                        {
                            DelegAsync.MethAsyncTexteJ("Le troll meurs!");
                            DelegAsync.MethAsyncTexteM("");
                        }
                    }
                    else if (Trolly.Degats == Trolly.AttaqueRapide && Vivi.Degats == Vivi.AttaqueLourde || Trolly.Degats == Trolly.AttaqueLourde && Vivi.Degats == Vivi.Bouclier || Trolly.Degats == Trolly.Bouclier && Vivi.Degats == Vivi.AttaqueRapide)
                    {
                        Vivi.SubitDegats(Trolly.Degats);
                        MesLabels.PV.Invoke(new MethodInvoker(delegate { Vivi.UpVie(); }));
                        if (Vivi.Vie > 0)
                        {
                            DelegAsync.MethAsyncTexteC("Le troll te touche.\nIl te reste " +
                            Convert.ToString(Vivi.Vie) +
                            " point de vie et le troll possède encore " +
                            Convert.ToString(Trolly.MVie) +
                            " point de vies!");
                            await Task.Delay(3000);
                        }
                        else
                        {
                            DelegAsync.MethAsyncTexteJ("Tu meurs!\nLe troll se délecte de ton cadavre!");
                            DelegAsync.MethAsyncTexteM("");
                        }
                    }
                    else
                    {
                        DelegAsync.MethAsyncTexteC("Le coup est contré!");
                        await Task.Delay(3000);
                    }

                    if (Vivi.Vivant && !Trolly.Vivant)
                    {
                        Vivi.Experience += 20;
                        Vivi.NiveauGagner();
                        Stuff stuff = Stuff.Lotterie;
                        stuff.EquipementLourd();
                        Vivi.PotionDeVie();
                        MesLabels.TexteCombat.Invoke(new MethodInvoker(delegate { Vivi.UpVie(); }));
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
