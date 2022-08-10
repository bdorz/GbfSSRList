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
    public partial class context : Form
    {
        public context()
        {
            InitializeComponent();            
        }
        #region 奧義
        private void btnMysteryOutput_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            //第一次進行奧義編輯
            if (tbResultMystery.Text.IndexOf("奧義") == -1)
            {
                sb.Append("|~w(100px):center:奧義 |> |> |w(300px):center:名稱 |> |> |> |w(800px):center:效果 |\r\n");
            }

            //奧義-倍率&描述
            sb.Append("|^ |> |> |center:" + changeStrWave(tbMsName.Text) + " |> |> |> |center:" + changeStrWave(tbMsEff.Text) + "|\r\n");
            sb.Append("|^ |> |> |^ |> |> |> |" + changeStrWave(tbMsEffInfo.Text) + " |\r\n");
            tbResultMystery.Text += sb.ToString();
        }

        //清空
        private void btnMysteryClear_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < panMystery.Controls.Count; i++)
            {
                if (panMystery.Controls[i].GetType().Name == "TextBox" || panMystery.Controls[i].GetType().Name == "ComboBox")
                {
                    panMystery.Controls[i].Text = string.Empty;
                }
            }
        }
        #endregion 奧義

        #region 技能
        //紅色 #FF0000
        //黄色 #FFD700
        //綠色 #98F898
        //藍色 #6495ED
        //紫色 #BA55D3
        //◆用 &color(#0000FF){◆}
        private void btnSkillOutput_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            //第一次進行技能編輯
            if (tbResultSkill.Text.IndexOf("技能") == -1)
            {
                sb.Append("|~center:技能 |> |> |center:名稱 |center:等級 |center:持續 |center:冷卻 |center:效果 |\r\n");
            }

            //技能&描述
            sb.Append("|^ |> |> |center:&color(#"+ SkillColor(cbSkillColor.Text) + "){■}" + changeStrWave(tbSkillName.Text) + " |center:" 
                + changeStrWave(tbSkillLevelUpOne.Text) + " |center:" + changeStrWave(tbSkillTurnOne.Text) + " |center:" + changeStrWave(tbSkillCDOne.Text) 
                + " |center:" + changeStrWave(tbSkillEffOne.Text) + " |\r\n");          
            //判斷等級上升調整不只一次
            if (!string.IsNullOrEmpty(tbSkillLevelUpTwo.Text))
            {
                sb.Append("|^ |> |> |^ |center:" + changeStrWave(tbSkillLevelUpTwo.Text) + " |center:" + changeStrWave(tbSkillTurnTwo.Text) 
                    + " |center:" + changeStrWave(tbSkillCDTwo.Text) + " |center:" + changeStrWave(tbSkillEffTwo.Text) + " |\r\n");
            }
            if (!string.IsNullOrEmpty(tbSkillLevelUpThree.Text))
            {
                sb.Append("|^ |> |> |^ |center:" + changeStrWave(tbSkillLevelUpThree.Text) + " |center:" + changeStrWave(tbSkillTurnThree.Text) 
                    + " |center:" + changeStrWave(tbSkillCDThree.Text) + " |center:" + changeStrWave(tbSkillEffThree.Text) + " |\r\n");
            }         
            sb.Append("|^ |> |> |^ |> |> |> | " + changeStrWave(tbSkillEffInfo.Text) + "|\r\n");
            tbResultSkill.Text += sb.ToString();

            
        }

        //清空
        private void btnSkillClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < panSkill.Controls.Count; i++)
            {
                if (panSkill.Controls[i].GetType().Name == "TextBox" || panSkill.Controls[i].GetType().Name == "ComboBox")
                {
                    panSkill.Controls[i].Text = string.Empty;
                }
            }
        }

        private string SkillColor(string ColorCode)
        {
            string result = string.Empty;
            switch (ColorCode)
            {
                case "紅":
                    result = "FF0000";
                    break;
                case "黃":
                    result = "FFD700";
                    break;
                case "藍":
                    result = "6495ED";
                    break;
                case "綠":
                    result = "98F898";
                    break;
                case "紫":
                    result = "BA55D3";
                    break;
            }
            return result;
        }
        #endregion 技能

        #region 被動
        private void btnSubSkillOutput_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            //第一次進行技能編輯
            if (tbResultSubSkill.Text.IndexOf("被動") == -1)
            {
                sb.Append("|~center:被動 |> |> |center:名稱 |> |> |> |center:效果 |\r\n");
            }

            if (tbResultSubSkill.Text.IndexOf("|}") != -1)
            {
                tbResultSubSkill.Text = tbResultSubSkill.Text.Replace("|}\r\n", "");
            }
            sb.Append("|^ |> |> |center:" + changeStrWave(tbSubSkillName.Text) + " |> |> |> |center:" + changeStrWave(tbSubSkillEff.Text) + " |\r\n");
            sb.Append("|^ |> |> |^ |> |> |> | " + changeStrWave(tbSubSkillEffInfo.Text) + " |\r\n");
            sb.Append("|}\r\n");

            tbResultSubSkill.Text += sb.ToString();
        }

        //清空
        private void btnSubSkillClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < panSubSkill.Controls.Count; i++)
            {
                if (panSubSkill.Controls[i].GetType().Name == "TextBox" || panSubSkill.Controls[i].GetType().Name == "ComboBox")
                {
                    panSubSkill.Controls[i].Text = string.Empty;
                }
            }
        }
        #endregion 被動

        #region 評價
        private void btnCollapse_Click(object sender, EventArgs e)
        {
            //tbComment.Text += "\r\n";
            //tbComment.Text += "[+]&color(#003377){&size(16){'' " + changeStrWave(tbCollaspeTitle.Text) + "''}}\r\n";
            //tbComment.Text += "\r\n";
            //tbComment.Text += "[END]\r\n";
            //tbComment.ScrollToCaret();
            //tbCollaspeTitle.Text = string.Empty;
        }
        #endregion 評價

        
        private string changeStrWave(string strParam)
        {
            strParam = strParam.Replace("\r\n", "~~");
            return strParam;
        }

        //設定
        private void btnOtherOutput_Click(object sender, EventArgs e)
        {
            //測試資料
            //tbTitle.Text = "ユエル (尤艾爾)";
            //cbAttr.Text = "火";
            //tbZhName.Text = "ユエル";
            //tbFullName.Text = "[千年を探す者]ユエル";
            //tbImg1.Text = "https://image02.seesaawiki.jp/g/o/gbfssrlistbyod-memo/1ec23f2a46fa9e2d.png";
            //tbImg2.Text = "https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/d009a34662087d15.png";
            //tbImg3.Text = "https://image01.seesaawiki.jp/g/o/gbfssrlistbyod-memo/5c48dc03b0c58426.png";
            //cbRace.Text = "エルーン";
            //cbType.Text = "平衡";
            //tbProud.Text = "樂器/刀";
            //tbCV.Text = "植田佳奈";
            //tbHP.Text = "2000 (+270)";
            //tbATK.Text = "8550 (+360)";

            StringBuilder sb = new StringBuilder();
            //標題
            //sb.Append("*" + tbTitle.Text + "\r\n");
            ////屬性主頁面
            //sb.Append("[[" + cbAttr.Text + "屬性主頁]]\r\n");
            //基本資料
            sb.Append("**基本資料\r\n");
            sb.Append("{| width=\"1200\"\r\n");
            //基本資料_名稱
            sb.Append("|> |> |> |~w(400px):center:" + tbZhName.Text + "|> |> |>|w(800px):center:" + tbFullName.Text + "|\r\n");
            //基本資料_圖片
            if (string.IsNullOrEmpty(tbImg3.Text))
            {
                sb.Append("|> |> |> |w(400px):center:&ref(" + tbImg1.Text + ",400)|> |> |w(400px):center:&ref(" + tbImg2.Text + ",400) "
                    + "|w(400px):h(350px):center:- |\r\n");
            }
            else
            {
                sb.Append("|> |> |> |w(400px):center:&ref(" + tbImg1.Text + ",400)|> |> |w(400px):center:&ref(" + tbImg2.Text + ",400)"
                    + " |w(400px):h(350px):center:&ref(" + tbImg3.Text + ",400) |\r\n");
            }
            //基本資料_種族類型雜項
            sb.Append("|~w(100px):center:種族 |w(100px):center:類型 |w(100px):center:得意 |w(100px):center:聲優 |> |> |center:HP |center:ATK |\r\n");
            sb.Append("|center:" + cbRace.Text + " |center:" + cbType.Text + " |center:" + tbProud.Text + "|center:" + tbCV.Text 
                + " |> |> |center:" + tbHP.Text + " |center:" + tbATK.Text + " |\r\n");
            tbResultOther.Text = sb.ToString();
        }

        private void btnOtherClear_Click(object sender, EventArgs e)
        {
            //清空
            for (int i = 0; i < panOther.Controls.Count; i++)
            {
                if (panOther.Controls[i].GetType().Name == "TextBox" || panSubSkill.Controls[i].GetType().Name == "ComboBox")
                {
                    panOther.Controls[i].Text = string.Empty;
                }
            }
        }
        ////最後彙整輸出
        //private void btnContextOutput_Click(object sender, EventArgs e)
        //{
        //    tbResultImport.Text = string.Empty;
        //    tbResultImport.Text = tbResultOther.Text + "\r\n" + tbResultMystery.Text + "\r\n" +tbResultSkill.Text + "\r\n" +tbResultSubSkill.Text + "\r\n **評價 \r\n" +tbComment.Text;
        //}

        private void btnLB_Click(object sender, EventArgs e)
        {
            LB fromLB = new LB();
            fromLB.Show();
        }
    }
}
