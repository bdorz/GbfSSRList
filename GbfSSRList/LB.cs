using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GbfSSRList
{
    public partial class LB : Form
    {
        public LB()
        {
            InitializeComponent();
        }

        private void btnLB_Click(object sender, EventArgs e)
        {          
            Button btn = (Button)sender;

            if (panLB1.Controls.Count == 0)
            {
                panLB1.Controls.Add(CreateBtnLB(btn));
            }
            else if (panLB2.Controls.Count == 0)
            {
                panLB2.Controls.Add(CreateBtnLB(btn));
            }
            else if (panLB3.Controls.Count == 0)
            {
                panLB3.Controls.Add(CreateBtnLB(btn));
            }
            else if (panLB4.Controls.Count == 0)
            {
                panLB4.Controls.Add(CreateBtnLB(btn));
            }
            else if (panLB5.Controls.Count == 0)
            {
                panLB5.Controls.Add(CreateBtnLB(btn));
            }
        }

        private Button CreateBtnLB(Button param)
        {
            Button btnClone = new Button();
            btnClone.BackgroundImage = param.BackgroundImage;
            btnClone.Width = param.Width;
            btnClone.Height = param.Height;
            btnClone.BackgroundImageLayout = param.BackgroundImageLayout;
            btnClone.Name = param.Name;
            if (param.Name.IndexOf("Sub") !=-1)
            {
                label1.Visible = true;
                tbSubSkill.Visible = true;
            }
            return btnClone;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].GetType().Name == "Panel")
                {
                    if (this.Controls[i].Name != "panLbImage")
                    {
                        this.Controls[i].Controls.Clear();
                    }
                }
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (tbResult.Text.IndexOf("**Limit Bonus") == -1)
            {
                sb.Append("**Limit Bonus\r\n");
                sb.Append("|~w(40px):圖示|w(140px):center:類別 |w(50px):center:☆1 |w(50px):center:☆2 |w(50px):center:☆3 |w(500px):center:備註 |\r\n");
                sb.Append("|w(40px):center:|w(140px):center: |w(50px):center: |w(50px):center: |w(50px):center: |w(300px): |c\r\n");
            }

            if (!string.IsNullOrEmpty(tbTitle.Text))
            {
                sb.Append("|>|>|>|>|>|" + tbTitle.Text + "|\r\n");
            }
            #region LB字串建立

            if (panLB1.Controls.Count > 0)
            {
                sb.Append(LBString((Button)panLB1.Controls[0]) + "\r\n");
            }
            if (panLB2.Controls.Count > 0)
            {
                sb.Append(LBString((Button)panLB2.Controls[0]) + "\r\n");
            }
            if (panLB3.Controls.Count > 0)
            {
                sb.Append(LBString((Button)panLB3.Controls[0]) + "\r\n");
            }
            if (panLB4.Controls.Count > 0)
            {
                sb.Append(LBString((Button)panLB4.Controls[0]) + "\r\n");
            }
            if (panLB5.Controls.Count > 0)
            {
                sb.Append(LBString((Button)panLB5.Controls[0]) + "\r\n");
            }

            #endregion LB字串建立

            if (tbResult.Text.IndexOf("||||||c\r\n") != -1)
            {
                tbResult.Text = tbResult.Text.Replace("||||||c\r\n", "");
            }
            sb.Append("||||||c\r\n");

            if (tbSubSkill.Visible == true)
            {
                tbSubSkill.Visible = false;
                label1.Visible = false;
            }

            tbResult.Text += sb.ToString();
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].GetType().Name == "Panel")
                {
                    if (this.Controls[i].Name != "panLbImage")
                    {
                        this.Controls[i].Controls.Clear();
                    }
                }
            }
        }
        
        private string LBString(Button panLBbtn)
        {
            //|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/cc002e81db730ba4.png,40) |攻&#25802;力|500|800|1000||
            string result = string.Empty;
            switch (panLBbtn.Name)
            {
                case "btnAtk":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/cc002e81db730ba4.png,40) |攻&#25802;力|500|800|1000||";
                    break;
                case "btnDef":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/3fc1f6875c2237cf.png,40) |防禦力|5%|8%|10%||";
                    break;
                case "btnHP":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/f2747a4bd4ecaf67.png,40) |HP|250|500|750||";
                    break;
                case "btnHeal":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/f085e26ee82c5584.png,40) |回復性能|10%|15%|20%||";
                    break;
                case "btnAbDMG":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/7809961ed2b2c928.png,40) |技能傷害|10%|15%|20%||";
                    break;
                case "btnAbLimit":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/8b482805cb3c9f2f.png,40) |技能傷害上限|5%|8%|10%||";
                    break;
                case "btnODDMG":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/6d3d2b332249ea67.png,40) |對OD時攻&#25802;UP|5%|8%|10%||";
                    break;
                case "btnODCurb":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/b77cee0440bcebc6.png,40) |對OD抑制力|5%|8%|10%||";
                    break;
                case "btnWeakPatience":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/b7677a23ca9008c0.png,40) |弱體耐性|5%|8%|10%||";
                    break;
                case "btnDBHit":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/1d1a18df5772eb55.png,40) |弱體命中率|5%|8%|10%||";
                    break;
                case "btnFireDMG":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/996fe55ab8fbf46a.png,40) |火屬性攻&#25802;力|5%|8%|10%||";
                    break;
                case "btnWaterDMG":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/1dceb337adb991d4.png,40) |水屬性攻&#25802;力|5%|8%|10%||";
                    break;
                case "btnEarthDMG":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/db4e4786a21524cd.png,40) |土屬性攻&#25802;力|5%|8%|10%||";
                    break;
                case "btnWindDMG":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/895a944bc6a559df.png,40) |風屬性攻&#25802;力|5%|8%|10%||";
                    break;
                case "btnLightDMG":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/35a69def1a9c0599.png,40) |光屬性攻&#25802;力|5%|8%|10%||";
                    break;
                case "btnDarkDMG":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/09128871b85de0a6.png,40) |闇屬性攻&#25802;力|5%|8%|10%||";
                    break;
                case "btnFireCut":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/747294c7e2c51af5.png,40) |火屬性傷害減輕 |2%|4%|5%||";
                    break;
                case "btnWaterCut":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/60796ee501dfa6f8.png,40) |水屬性傷害減輕 |2%|4%|5%||";
                    break;
                case "btnEarthCut":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/5658f335744872f1.png,40) |土屬性傷害減輕 |2%|4%|5%||";
                    break;
                case "btnWindCut":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/52a8a6933ba510e6.png,40) |風屬性傷害減輕 |2%|4%|5%||";
                    break;
                case "btnLightCut":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/6cad1a0ccee75076.png,40) |光屬性傷害減輕 |2%|4%|5%||";
                    break;
                case "btnDarkCut":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/a09cd8877af1f3e8.png,40) |闇屬性傷害減輕 |2%|4%|5%||";
                    break;
                case "btnMysDMG":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/33d4609f56564dfd.png,40) |奧義傷害|10%|15%|20%||";
                    break;
                case "btnMysLimit":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/c0a2b59581ab86f8.png,40) |奧義傷害上限|5%|8%|10%||";
                    break;
                case "btnCrit":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/425dcee27a3cfb7a.png,40) |暴&#25802;率|12%|20%|25%||";
                    break;
                case "btnDA":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/8dfaa0f519ee462a.png,40) |二連&#25802;機率|3%|5%|6%||";
                    break;
                case "btnTA":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/74fc621a165a20a0.png,40) |三連&#25802;機率|2%|4%|5%||";
                    break;
                case "btnMysFast":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/ae45ae629b53f84f.png,40) |奧義上升量|5%|8%|10%||";
                    break;
                case "btnBKDMG":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/7ef8016beaf08d00.png,40) |對Break時攻&#25802;UP|5%|8%|10%||";
                    break;
                case "btnModeCurb":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/2f2bdede0273a2d0.png,40) |mode條消減量上升|5%|8%|10%||";
                    break;
                case "btnAtkUpDefDown":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/a1ebbe711e291617.png,40) |攻UP防down|900/~~-10%|1300/~~-15%|1500/~~-20%||";
                    break;
                case "btnAtkDownDefUp":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/c9c112f0f943d6c3.png,40) |攻down防UP|-900/~~10%|-1300/~~15%|-1500/~~20%||";
                    break;
                case "btnReflex":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/d912ef13b659edbe.png,40) |反射|2%|4%|5%||";
                    break;
                case "btnAvoid":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/fcba8368f3411383.png,40) |迴避率|1%|2%|3%|回合開始時低機率敵全攻&#25802;迴避|";
                    break;
                case "btnHostilityUp":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/a332443c13af0023.png,40) |敵對心UP|小|中|大|敵對心+5/8/10|";
                    break;
                case "btnHostilityDown":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/246a8cb336a01057.png,40) |敵對心down|小|中|大|敵對心-2/4/5|";
                    break;
                case "btnAdversity":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/2aFhVtxBBq.png,40) |背水 |小|中|大|滿血1%/殘血最大9%，半血提升量約3%|";
                    break;
                case "btnStrong":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/ed47ef2f81bf01cc.png,40) |渾身|小|中|大|滿血最大6%/殘血2%，線性衰減|";
                    break;
                case "btnFightbackDMG":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/UCn1q3ylo5.png,40) |反&#25802;傷害|10%|15%|20%| 與反&#25802;倍率乘算 |";
                    break;
                case "btnSubSkill":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/1ee80b7a4124ed18.png,40) |角色被動|>|>|>|" + tbSubSkill.Text + "|";
                    break;
                //十天
                case "btnSupplementDMG1":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/H2EVtcVlvq.png,40) |傷害上限|5%|8%|10%||";
                    break;
                case "btnSupplementDMG2":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/H2EVtcVlvq.png,40) |傷害上限|1%|3%|5%||";
                    break;
                case "btnNormalSupplement":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/tLepCfMJC8.jpg,40) |普通攻&#25802;傷害UP|5%|8%|10%||";
                    break;
                case "btnAbSupplement":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/xwoikwYcMB.png,40) |技能傷害給予UP|10000|30000|50000||";
                    break;
                case "btnMysSupplement":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/QfB8rZOFy4.png,40) |奧義傷害給予UP|50000|100000|150000||";
                    break;
                //轉世
                case "btnATK_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/9Z9Hzq_axH.png,40) |攻&#25802;力|>|>|1000||";
                    break;
                case "btnDef_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/KY44TtGzHh.png,40) |防禦力 |>|>|10% ||";
                    break;
                case "btnHP_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/Ov4gA0xsqh.png,40) |HP |>|>|750 ||";
                    break;
                case "btnDA_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/dL1JMS4PBA.png,40) |二連&#25802;機率 |>|>|6% ||";
                    break;
                case "btnTA_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/pcrETlP7rm.png,40) |三連&#25802;機率 |>|>|5% ||";
                    break;
                case "btnCrit_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/ns5JL0AtKG.png,40) |暴&#25802;率 |>|>|25% ||";
                    break;
                case "btnFireDMG_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/UdNeFhioiY.png,40) |火屬性攻&#25802;力 |>|>|10% ||";
                    break;
                case "btnWaterDMG_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/Q00t3_8aQG.png,40) |水屬性攻&#25802;力 |>|>|10% ||";
                    break;
                case "btnEarthDMG_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/LKDDHyaeFm.png,40) |土屬性攻&#25802;力 |>|>|10% ||";
                    break;
                case "btnWindDMG_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/cfwSXloGyn.png,40) |風屬性攻&#25802;力 |>|>|10% ||";
                    break;
                case "btnLightDMG_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/c6kVW8QSFq.png,40) |光屬性攻&#25802;力 |>|>|10% ||";
                    break;
                case "btnDarkDMG_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/HDbr6fJMB_.png,40) |闇屬性攻&#25802;力 |>|>|10% ||";
                    break;
                case "btnAdversity_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/J6QA6wZFMy.png,40) |背水 |>|>|大 ||";
                    break;
                case "btnStrong_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/efT9ol6A1E.png,40) |渾身 |>|>|大 ||";
                    break;
                case "btnAbDMG_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/8NQtsWp_O_.png,40) |技能傷害 |>|>|20% ||";
                    break;
                case "btnAbLimit_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/CytYpwOceP.png,40) |技能傷害上限 |>|>|10% ||";
                    break;
                case "btnMysDMG_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/lylVsZW4ob.png,40) |奧義傷害 |>|>|20% ||";
                    break;
                case "btnMysLimit_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/ap8eDbbCH9.png,40) |奧義傷害上限 |>|>|15% ||";
                    break;
                case "btnMysFast_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/CrcBWvHOMl.png,40) |奧義上升量 |>|>|10% ||";
                    break;
                case "btnWeakPatience_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/IKjiaL7_WQ.png,40) |弱體耐性 |>|>|10% ||";
                    break;
                case "btnDBHit_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/u67Yjj9EM2.png,40) |弱體命中率 |>|>|10% ||";
                    break;
                case "btnFireCut_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/DXx2Yp8vDi.png,40) |火屬性傷害減輕 |>|>|5% ||";
                    break;
                case "btnWaterCut_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/N9tUbEmuuI.png,40) |水屬性傷害減輕 |>|>|5% ||";
                    break;
                case "btnEarthCut_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/vb3mM4WONc.png,40) |土屬性傷害減輕 |>|>|5% ||";
                    break;
                case "btnWindCut_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/B7ZsJmBwJi.png,40) |風屬性傷害減輕 |>|>|5% ||";
                    break;
                case "btnLightCut_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/UdY6txIspi.png,40) |光屬性傷害減輕 |>|>|5% ||";
                    break;
                case "btnDarkCut_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/Gem0jqHZd0.png,40) |闇屬性傷害減輕 |>|>|5% ||";
                    break;
                case "btnReflex_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/8U7x8gVW1j.png,40) |反射 |>|>|5% ||";
                    break;
                case "btnAvoid_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/ToWcMQ9tRJ.png,40) |迴避 |>|>|3% ||";
                    break;
                case "btnHeal_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/G1O0FCQykj.png,40) |回復性能 |>|>|20% ||";
                    break;
                case "btnNormalSupplement_Arcarum":
                    result = "|&ref(https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/o29wWNrdmv.png,40) |普通攻&#25802;傷害 |>|>|3% ||";
                    break;
                case "btnSubSkill_Arcarum":
                    result = "|&ref(https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/QMPIO5tprj.png,40) |被動 |>|>|"+tbSubSkill.Text+"||";
                    break;

            }
            
            return result;
        }

        #region 預設版型
        private void btnBalanceRow_Click(object sender, EventArgs e)
        {
            btnClear_Click(null, null);
            panLB1.Controls.Add(CreateBtnLB(btnAtk));
            panLB2.Controls.Add(CreateBtnLB(btnDef));
            panLB3.Controls.Add(CreateBtnLB(btnHP));
            panLB4.Controls.Add(CreateBtnLB(btnDA));
            panLB5.Controls.Add(CreateBtnLB(btnWeakPatience));
        }

        private void btnAtkRow_Click(object sender, EventArgs e)
        {
            btnClear_Click(null, null);
            panLB1.Controls.Add(CreateBtnLB(btnAtk));
            panLB2.Controls.Add(CreateBtnLB(btnDef));
            panLB3.Controls.Add(CreateBtnLB(btnDA));
            panLB4.Controls.Add(CreateBtnLB(btnCrit));
            panLB5.Controls.Add(CreateBtnLB(btnMysDMG));
        }

        private void btnDefRow_Click(object sender, EventArgs e)
        {
            btnClear_Click(null, null);
            panLB1.Controls.Add(CreateBtnLB(btnAtk));
            panLB2.Controls.Add(CreateBtnLB(btnDef));
            panLB3.Controls.Add(CreateBtnLB(btnDef));
            panLB4.Controls.Add(CreateBtnLB(btnHP));
        }

        private void btnHealRow_Click(object sender, EventArgs e)
        {
            btnClear_Click(null, null);
            panLB1.Controls.Add(CreateBtnLB(btnAtk));
            panLB2.Controls.Add(CreateBtnLB(btnDef));
            panLB3.Controls.Add(CreateBtnLB(btnHP));
            panLB4.Controls.Add(CreateBtnLB(btnWeakPatience));
            panLB5.Controls.Add(CreateBtnLB(btnHeal));
        }

        private void btnSpRow_Click(object sender, EventArgs e)
        {
            btnClear_Click(null, null);
            panLB1.Controls.Add(CreateBtnLB(btnAtk));
            panLB2.Controls.Add(CreateBtnLB(btnDef));
            panLB3.Controls.Add(CreateBtnLB(btnWeakPatience));
            panLB4.Controls.Add(CreateBtnLB(btnODDMG));
            panLB5.Controls.Add(CreateBtnLB(btnODCurb));
        }

        private void btnHuman_Click(object sender, EventArgs e)
        {
            btnClear_Click(null, null);
            panLB1.Controls.Add(CreateBtnLB(btnAtk));
            panLB2.Controls.Add(CreateBtnLB(btnDef));
            panLB3.Controls.Add(CreateBtnLB(btnHP));
            panLB4.Controls.Add(CreateBtnLB(btnDA));
            panLB5.Controls.Add(CreateBtnLB(btnCrit));
        }

        private void btnErune_Click(object sender, EventArgs e)
        {
            btnClear_Click(null, null);
            panLB1.Controls.Add(CreateBtnLB(btnAtk));
            panLB2.Controls.Add(CreateBtnLB(btnDef));
            panLB3.Controls.Add(CreateBtnLB(btnDA));
            panLB4.Controls.Add(CreateBtnLB(btnTA));
        }

        private void btnDraft_Click(object sender, EventArgs e)
        {
            btnClear_Click(null, null);
            panLB1.Controls.Add(CreateBtnLB(btnAtk));
            panLB2.Controls.Add(CreateBtnLB(btnDef));
            panLB3.Controls.Add(CreateBtnLB(btnHP));
            panLB4.Controls.Add(CreateBtnLB(btnCrit));
        }

        private void btnHarvin_Click(object sender, EventArgs e)
        {
            btnClear_Click(null, null);
            panLB1.Controls.Add(CreateBtnLB(btnAtk));
            panLB2.Controls.Add(CreateBtnLB(btnAtk));
            panLB3.Controls.Add(CreateBtnLB(btnDA));
            panLB5.Controls.Add(CreateBtnLB(btnMysDMG));
        }

        private void btnStar_Click(object sender, EventArgs e)
        {
            btnClear_Click(null, null);
            panLB1.Controls.Add(CreateBtnLB(btnAtk));
            panLB2.Controls.Add(CreateBtnLB(btnDef));
            panLB3.Controls.Add(CreateBtnLB(btnHP));
            panLB5.Controls.Add(CreateBtnLB(btnMysDMG));
        }
        #endregion 預設版型
    }
}
