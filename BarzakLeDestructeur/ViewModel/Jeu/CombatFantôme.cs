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
    public class CombatFantôme
    {
        public static async void CombattreFantôme()
        {
            Joueur Vivi = Joueur.Instance;
            Fantôme Bhou = Fantôme.Instance;
            Query query = new Query();
            Page page = Page.Instance;
            bool jeu = true;

            DelegAsync.MethAsyncTexteJ("Combat: un fantôme.");
            await Task.Delay(2000);
            while (jeu)
            {
                while (Vivi.Vivant && Bhou.Vivant)
                {
                    Form1.PanelJeu.Invoke(new MethodInvoker(delegate{ Vivi.LibereAttaque(); }));
                    MesBouttons.stop.WaitOne();
                    await Task.Delay(3000);
                    MesBouttons.stop.WaitOne();
                    Form1.PanelJeu.Invoke(new MethodInvoker(delegate { Vivi.BlockAttaque(); }));
                    Bhou.Attaque(Vivi);
                    if (Bhou.Degats == Bhou.AttaqueRapide && Vivi.Degats == Vivi.Bouclier || Bhou.Degats == Bhou.AttaqueLourde && Vivi.Degats == Vivi.AttaqueRapide || Bhou.Degats == Bhou.Bouclier && Vivi.Degats == Vivi.AttaqueLourde || Vivi.Degats == Vivi.Magie)
                    {
                        Bhou.SubirDegats(Vivi.Degats);
                        MesLabels.PVM.Invoke(new MethodInvoker(delegate { Bhou.UpMVie(); }));
                        if (Bhou.MVie > 0)
                        {
                            DelegAsync.MethAsyncTexteC("Ton attaque réussit.\nIl reste " +
                            Convert.ToString(Bhou.MVie) +
                            " point de vie au fantôme et tu en as encore " +
                            Convert.ToString(Vivi.Vie) +
                            " point de vies!");
                            await Task.Delay(3000);
                        }
                        else
                        {
                            DelegAsync.MethAsyncTexteJ("Le fantôme meurs!");
                            DelegAsync.MethAsyncTexteM("");
                        }
                    }
                    else if (Bhou.Degats == Bhou.AttaqueRapide && Vivi.Degats == Vivi.AttaqueLourde || Bhou.Degats == Bhou.AttaqueLourde && Vivi.Degats == Vivi.Bouclier || Bhou.Degats == Bhou.Bouclier && Vivi.Degats == Vivi.AttaqueRapide)
                    {
                        Vivi.SubitDegats(Bhou.Degats);
                        MesLabels.PV.Invoke(new MethodInvoker(delegate { Vivi.UpVie(); }));
                        if (Vivi.Vie > 0)
                        {
                            DelegAsync.MethAsyncTexteC("Le fantôme te touche.\nIl te reste " +
                            Convert.ToString(Vivi.Vie) +
                            " point de vie et le fantôme possède encore " +
                            Convert.ToString(Bhou.MVie) +
                            " point de vies!");
                            await Task.Delay(3000);
                        }
                        else
                        {
                            DelegAsync.MethAsyncTexteJ("Tu meurs!\nLe fantome se ris de toi!");
                            DelegAsync.MethAsyncTexteM("");
                        }
                    }
                    else
                    {
                        DelegAsync.MethAsyncTexteC("Le coup est contré!");
                        await Task.Delay(3000);
                    }
                    if (Vivi.Vivant && !Bhou.Vivant)
                    {
                        Vivi.Experience += 15;
                        Vivi.NiveauGagner();
                        Stuff stuff = Stuff.Lotterie;
                        stuff.EquipementLeger();
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
