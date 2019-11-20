using System;
using System.Text;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;


public partial class Search : System.Web.UI.Page
{
    System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());
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
        if (Session["Search"] != null)
        {
            String homeSearch = "";
            if(Session["Search"] != null)
            {
                homeSearch = Convert.ToString(Session["Search"]);
            }
            btnHomeSearch_Click(homeSearch);
        }
    }

    public void btnHomeSearch_Click(String homeSearch)
    {
        Boolean searchCheck = false;
        for (int i = 0; i < homeSearch.Length - 1; i++)
        {
            String checkValue = homeSearch.Substring(i, 2);
            if (checkValue == ", ")
            {
                searchCheck = true;
            }
        }

        if (searchCheck == true)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());

            sqlConn.Open(); 

            String tSearch = HttpUtility.HtmlEncode(homeSearch);
            int commaSplit = tSearch.IndexOf(",");
            String cityString = tSearch.Substring(0, commaSplit).ToUpper();
            String state = tSearch.Substring(commaSplit + 2).ToUpper();
            String query = filter();
            System.Data.SqlClient.SqlCommand sqlComm = new System.Data.SqlClient.SqlCommand(query, sqlConn);
            sqlComm.Parameters.Add(new SqlParameter("@City", cityString));
            sqlComm.Parameters.Add(new SqlParameter("@State", state));
            System.Data.SqlClient.SqlDataReader reader = sqlComm.ExecuteReader();

            Card1.Text = "";
            int resultCount = 0;

            while (reader.Read())
            {
                int PropID = Convert.ToInt32(reader["PropertyID"]);
                String city = reader["City"].ToString();
                String homeState = reader["HomeState"].ToString();
                String priceRangeLow = reader["RoomPriceRangeLow"].ToString();
                String priceRangeHigh = reader["RoomPriceRangeHigh"].ToString();
                double priceLowRounded = Math.Round(Convert.ToDouble(priceRangeLow), 0, MidpointRounding.ToEven);
                double priceHighRounded = Math.Round(Convert.ToDouble(priceRangeHigh), 0, MidpointRounding.ToEven);

                StringBuilder myCard = new StringBuilder();
                myCard
                .Append("<div class=\"col-xs-4 col-md-3\">")
                .Append("   <div class=\"card  shadow-sm  mb-4\">")
                .Append("       <img src=\"images/scott-webb-1ddol8rgUH8-unsplash.jpg\" class=\"card-img-top\" alt=\"image\">")
                .Append("           <div class=\"card-body\">")
                .Append("               <h5 class=\"card-title\">" + city + ", " + homeState + "</h5>")
                .Append("               <p class=\"card-text\">" + "$" + priceLowRounded + " - " + "$" + priceHighRounded + "</p>")
                .Append("           </div>")
                .Append("   </div>")
                .Append("</div>");

                Card1.Text += myCard.ToString();
                resultCount++;
            }
            reader.Close();
            Session["Search"] = null;
        }
        else
        {
            txtSearch.Text = "That Search Query Did Not Display Results";
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Boolean searchCheck = false;
        for (int i = 0; i < txtSearch.Text.Length - 1; i++)
        {
            String checkValue = txtSearch.Text.Substring(i, 2);
            if (checkValue == ", ")
            {
                searchCheck = true;
            }
        }

        if (searchCheck == true)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ToString());

            if (String.IsNullOrEmpty(txtSearch.Text))
            {
                // Do nothing
            }
            else
            {
                sqlConn.Open();
                String tSearch = HttpUtility.HtmlEncode(txtSearch.Text);
                int commaSplit = tSearch.IndexOf(",");
                String cityString = tSearch.Substring(0, commaSplit).ToUpper();
                String state = tSearch.Substring(commaSplit + 2).ToUpper();
                String query = filter();
                System.Data.SqlClient.SqlCommand sqlComm = new System.Data.SqlClient.SqlCommand(query, sqlConn);
                sqlComm.Parameters.Add(new SqlParameter("@City", cityString));
                sqlComm.Parameters.Add(new SqlParameter("@State", state));
                System.Data.SqlClient.SqlDataReader reader = sqlComm.ExecuteReader();



                Card1.Text = "";
                int resultCount = 0;

                while (reader.Read())
                {
                    String city = reader["City"].ToString();
                    String homeState = reader["HomeState"].ToString();
                    String priceRangeLow = reader["RoomPriceRangeLow"].ToString();
                    String priceRangeHigh = reader["RoomPriceRangeHigh"].ToString();
                    double priceLowRounded = Math.Round(Convert.ToDouble(priceRangeLow), 0, MidpointRounding.ToEven);
                    double priceHighRounded = Math.Round(Convert.ToDouble(priceRangeHigh), 0, MidpointRounding.ToEven);

                    StringBuilder myCard = new StringBuilder();
                    myCard
                    .Append("<div class=\"col-xs-4 col-md-3\">")
                    .Append("   <div class=\"card  shadow-sm  mb-4\">")
                    .Append("       <img src=\"images/scott-webb-1ddol8rgUH8-unsplash.jpg\" class=\"card-img-top\" alt=\"image\">")
                    .Append("           <div class=\"card-body\">")
                    .Append("               <h5 class=\"card-title\">" + city + ", " + homeState + "</h5>")
                    .Append("               <p class=\"card-text\">" + "$" + priceLowRounded + " - " + "$" + priceHighRounded + "</p>")
                    .Append("           </div>")
                    .Append("   </div>")
                    .Append("</div>");

                    Card1.Text += myCard.ToString();
                    resultCount++;
                }
                reader.Close();
                Session["Search"] = null;
            }
        }
        else
        {
            txtSearch.Text = "That Search Did Not Display Results";
        }
    }

    protected string filter()
    {
        string queryFilter = "SELECT P.PropertyID, P.City, P.HomeState, P.RoomPriceRangeLow, P.RoomPriceRangeHigh, I.images " +
            "FROM Account A FULL OUTER JOIN Characteristics C ON A.AccountID = C.AccountID FULL OUTER JOIN Host H ON A.AccountID = H.HostID FULL OUTER JOIN " +
            "PropertyImages I FULL OUTER JOIN Property P ON I.PropertyID = P.PropertyID ON H.HostID = P.HostID " +
            "WHERE P.City = @City AND P.HomeState = @State   ";

        int qualityCount = 0;

        if (cbHomeShareYES.Checked == true)
        {
            queryFilter += "AND P.HomeShareSmarter = 1   ";
        }
        if (cbHomeShareNO.Checked == true)
        {
            queryFilter += "AND P.HomeShareSmarter = 0   ";
        }
        if (cbExtrovert.Checked == true)
        {
            if(qualityCount == 0)
            {
                queryFilter += " ORDER BY C.Extrovert DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "C.Extrovert DESC, ";
            }
        }

        if (cbIntrovert.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY C.Introvert DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "C.Introvert DESC, ";
            }
        }
        if (cbNonSmoker.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY C.NonSmoker DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "C.NonSmoker DESC, ";
            }
        }
        if (cbEarlyRiser.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY C.EarlyRiser DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "C.EarlyRiser DESC, ";
            }
        }
        if (cbNightOwl.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY C.NightOwl DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "C.NightOwl DESC, ";
            }
        }
        if (cbTechSavvy.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY C.TechSavvy DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "C.TechSavvy DESC, ";
            }
        }
        if (cbFamily.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY C.FamilyOriented DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "C.FamilyOriented DESC, ";
            }
        }
        if (cbKitchen.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY R.Kitchen DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "R.Kitchen DESC, ";
            }
        }
        if (cbHVAC.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY R.HVAC DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "R.HVAC DESC, ";
            }
        }
        if (cbWifi.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY R.Wifi DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "R.Wifi DESC, ";
            }
        }
        if (cbPrivateBath.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY R.PrivateBR DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "R.PrivateBR DESC, ";
            }
        }
        if (cbWalkInCloset.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY R.WalkInCloset DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "R.WalkInCloset DESC, ";
            }
        }
        if (cbWashDry.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY R.WashAndDry DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "R.WashAndDry DESC, ";
            }
        }

        if (cbStreetPark.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY P.StreetParking DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "P.StreetParking DESC, ";
            }
        }
        if (cbGarPark.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY P.GarageParking DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += " P.GarageParking DESC, ";
            }
        }
        if (cbBackyard.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY P.Backyard DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "P.Backyard DESC, ";
            }
        }
        if (cbPorch.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY P.PorchOrDeck DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "P.PorchOrDeck DESC, ";
            }
        }
        if (cbPool.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY P.Pool DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "P.Pool DESC, ";
            }
        }
        if (cbEnglish.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY C.English DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "C.English DESC, ";
            }
        }
        if (cbSpanish.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY C.Spanish DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "C.Spanish DESC, ";
            }
        }
        if (cbMandarin.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY C.Mandarin DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "C.Mandarin DESC, ";
            }
        }
        if (cbJapanese.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY C.Japanese DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "C.Japanese DESC, ";
            }
        }
        if (cbGerman.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY C.German DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "C.German DESC, ";
            }
        }
        if (cbFrench.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY C.French DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "C.French DESC, ";
            }
        }

        int size = queryFilter.Length;
        queryFilter = queryFilter.Substring(0, queryFilter.Length - 2);
        return queryFilter;
    }
}
