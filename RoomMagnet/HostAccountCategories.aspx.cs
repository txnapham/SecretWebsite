using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HostAccountCategories : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["type"] != null)
        {
            if ((int)Session["type"] == 1)
            {
                this.MasterPageFile = "~/AdminPage.master";
            }
            else if ((int)Session["type"] == 2)
            {
                this.MasterPageFile = "~/HostPage.master";
            }
            else if ((int)Session["type"] == 3)
            {
                this.MasterPageFile = "~/TenantPage.master";
            }
        }
        else if (Session["type"] == null)
        {
            this.MasterPageFile = "~/MasterPage.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSet_Click(object sender, EventArgs e)
    {
        int English;
        int Mandarin;
        int German;
        int Spanish;
        int Japanese;
        int French;
        int EarlyR;
        int Introvert;
        int Family;
        int Night;
        int Extrovert;
        int TechSavvy;
        int NonSmoker;

        if (cbEnglish.Checked == true)
        {
            English = 1;
        }
        else
        {
            English = 0;
        }
        if(cbMandarin.Checked == true)
        {
            Mandarin = 1;
        }
        else
        {
            Mandarin = 0;
        }
        if (cbGerman.Checked == true)
        {
            German = 1;
        }
        else
        {
            German = 0;
        }
        if(cbSpanish.Checked == true)
        {
            Spanish = 1;
        }
        else
        {
            Spanish = 0;
        }
        if(cbJapanese.Checked == true)
        {
            Japanese = 1;
        }
        else
        {
            Japanese = 0;
        }
        if(cbFrench.Checked == true)
        {
            French = 1;
        }
        else
        {
            French = 0;
        }
        if(cbEarlyRiser.Checked == true)
        {
            EarlyR = 1;
        }
        else
        {
            EarlyR = 0;
        }
        if (cbIntrovert.Checked == true)
        {
            Introvert = 1;
        }
        else
        {
            Introvert = 0;
        }
        if (cbFamily.Checked == true)
        {
            Family = 1;
        }
        else
        {
            Family = 0;
        }
        if (cbNightOwl.Checked == true)
        {
            Night = 1;
        }
        else
        {
            Night = 0;
        }
        if (cbExtrovert.Checked == true)
        {
            Extrovert = 1;
        }
        else
        {
            Extrovert = 0;
        }
        if (cbTechSavy.Checked == true)
        {
            TechSavvy = 1;
        }
        else
        {
            TechSavvy = 0;
        }
        if (cbNonSmoker.Checked == true)
        {
            NonSmoker = 1;
        }
        else
        {
            NonSmoker = 0;
        }
    }
}