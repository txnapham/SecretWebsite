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
using System.Collections;
using System.Web.Script.Serialization;

public partial class Search : System.Web.UI.Page
{
    System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //Gives access to certain account types
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
        divider.Text = String.Empty;

        if (Session["Search"] != null)
        {
            String homeSearch = "";
            homeSearch = Convert.ToString(Session["Search"]);
            txtSearch.Text = homeSearch;
            btnSearch_Click(sender, e);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //Shows the main sorted results 
        cardBuilder(mainResults, filter(), txtSearch.Text);
        divider.Text = "<hr/>" +
            "<strong>Other Results in State That May Interest You:</strong> ";
        cardBuilder(otherResults, filterOtherResults(), txtSearch.Text);
    }

    public string cardBuilder(Literal name, string cardQuery, string searchString)
    {
        string cardString = "";

        Boolean searchCheck = false;
        for (int i = 0; i < searchString.Length - 1; i++)
        {
            String checkValue = searchString.Substring(i, 2);
            if (checkValue == ", ")
            {
                searchCheck = true;
            }
        }

        if (searchCheck == true)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());
            sqlConn.Open();
            //City
            String tSearch = HttpUtility.HtmlEncode(searchString);
            int commaSplit = tSearch.IndexOf(",");
            String cityString = tSearch.Substring(0, commaSplit).ToUpper();
            String state = tSearch.Substring(commaSplit + 2).ToUpper();
            //Show Results with City/State 
            System.Data.SqlClient.SqlCommand sqlComm = new System.Data.SqlClient.SqlCommand(cardQuery, sqlConn);
            sqlComm.Parameters.Add(new SqlParameter("@City", cityString));
            sqlComm.Parameters.Add(new SqlParameter("@State", state));
            System.Data.SqlClient.SqlDataReader reader = sqlComm.ExecuteReader();

            int resultCount = 0;
            name.Text = String.Empty;

            while (reader.Read())
            {
                //Get data from database with City, State, Price, Image
                int PropID = Convert.ToInt32(reader["PropertyID"].ToString());
                String city = reader["City"].ToString();
                String homeState = reader["HomeState"].ToString();
                String priceRangeLow = reader["RoomPriceRangeLow"].ToString();
                String priceRangeHigh = reader["RoomPriceRangeHigh"].ToString();
                String filename = reader["images"].ToString();
                if (filename == "") filename = "imagenotfound.png";
                double priceLowRounded = Math.Round(Convert.ToDouble(priceRangeLow), 0, MidpointRounding.ToEven);
                double priceHighRounded = Math.Round(Convert.ToDouble(priceRangeHigh), 0, MidpointRounding.ToEven);
                string chars = addCharacteristics(PropID);

                //Display property profile that matches result on card 
                StringBuilder myCard = new StringBuilder();
                myCard
                .Append("<div class=\"col-xs-4 col-md-3\">")
                .Append("   <div class=\"card  shadow-sm  mb-4\">")
                .Append("       <img class=\"img-fluid card-img-small\" src=\"https://duvjxbgjpi3nt.cloudfront.net/PropertyImages/" + filename + "\" />")
                .Append("       <div class=\"card-body\">")
                .Append("           <h5 class=\"card-title\">" + city + ", " + homeState + "</h5>")
                .Append("           <p class=\"card-text\">" + "$" + priceLowRounded + " - " + "$" + priceHighRounded + "</p>")
                .Append(chars)
                .Append("       </div>")
                .Append("   </div>")
                .Append("</div>");

                name.Text += myCard.ToString();
                resultCount++;
            }
            reader.Close();
            Session["Search"] = null;
        }

        else
        {
            //Label for no search results
            resultLabel.Visible = true;
            resultLabel.Text = "No searches match your criteria.";
        }

        return cardString;
    }

    protected string filter()
    {
        //Filtering queries for properties with the attributes selected 
        string queryFilter = "SELECT P.PropertyID, P.City, P.HomeState, P.RoomPriceRangeLow, P.RoomPriceRangeHigh, I.images " +
            "FROM Account A FULL OUTER JOIN Characteristics C ON A.AccountID = C.AccountID FULL OUTER JOIN Host H ON A.AccountID = H.HostID FULL OUTER JOIN " +
            "PropertyImages I FULL OUTER JOIN Property P ON I.PropertyID = P.PropertyID ON H.HostID = P.HostID  FULL OUTER JOIN PropertyRoom R ON R.PropertyID = P.PropertyID " +
            "WHERE P.City = @City AND P.HomeState = @State   ";
        //Count for number of matching selected values
        int qualityCount = 0;
        //HomeShare filter
        if (cbHomeShareYES.Checked == true)
        {
            queryFilter += "AND P.HomeShareSmarter = 1   ";
        }
        if (cbHomeShareNO.Checked == true)
        {
            queryFilter += "AND P.HomeShareSmarter = 0   ";
        }
        //Extrovert Filter
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
        //Introvert Filter
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
        //Non-Smoking Filter
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
        //Early Riser Filter
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
        //Night Owl Filter
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
        //TechSavvy Filter 
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
        //Family Oriented Filter 
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
        //Kitchen Ammenity Filter
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
        //Heating AC Filter
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
        //Wifi Filter
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
        //Private Bathroom Filter
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
        //Walk in Closet Filter
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
        //Washer/Dryer Filter
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
        //Street Parking Filter
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
        //Garage Filter
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
        //Backyard Filter
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
        //Porch Filter
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
        //Pool Filter 
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
        //Languages Filters 
        //English
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
        //Spanish
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
        //Mandarin
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
        //Japanese
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
        //German
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
        //French
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
        //Shows the amount of filters chosen/in property 
        int size = queryFilter.Length;
        queryFilter = queryFilter.Substring(0, queryFilter.Length - 2);
        return queryFilter;
    }

    protected string filterOtherResults()
    {
        //Showing the other results that are most similar to the attributes selected
        string queryFilter = "SELECT P.PropertyID, P.City, P.HomeState, P.RoomPriceRangeLow, P.RoomPriceRangeHigh, I.images " +
            "FROM Account A FULL OUTER JOIN Characteristics C ON A.AccountID = C.AccountID FULL OUTER JOIN Host H ON A.AccountID = H.HostID FULL OUTER JOIN " +
            "PropertyImages I FULL OUTER JOIN Property P ON I.PropertyID = P.PropertyID ON H.HostID = P.HostID  FULL OUTER JOIN PropertyRoom R ON R.PropertyID = P.PropertyID " +
            "WHERE P.City != @City AND P.HomeState = @State   ";

        int qualityCount = 0;
        //Home Share Filter
        if (cbHomeShareYES.Checked == true)
        {
            queryFilter += "AND P.HomeShareSmarter = 1   ";
        }
        if (cbHomeShareNO.Checked == true)
        {
            queryFilter += "AND P.HomeShareSmarter = 0   ";
        }
        //Extrovert Filter
        if (cbExtrovert.Checked == true)
        {
            if (qualityCount == 0)
            {
                queryFilter += " ORDER BY C.Extrovert DESC, ";
                qualityCount++;
            }
            else
            {
                queryFilter += "C.Extrovert DESC, ";
            }
        }
        //Introvert Filter
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
        //Non-Smoker Filter
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
        //Early Riser Filter
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
        //Night Owl Filter
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
        //TechSavvy Filter
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
        //Family Oriented Filter
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
        //House Ammenities Filters
        //Kitchen 
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
        //Heating and AC Filter
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
        //Wifi Filter
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
        //Private Filter 
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
        //Walk in Closet Filter
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
        //Washer Dryer Filter
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
        //Street Parking Filter
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
        //Garage Parking Filter
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
        //Backyard Filter
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
        //Porch Filter
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
        //Pool Filter
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
        //Languages Filters///////
        //English
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
        //Spanish
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
        //Mandarin
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
        //Japanese
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
        //German
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
        //French
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
        //Amount of attributes that were the same 
        int size = queryFilter.Length;
        queryFilter = queryFilter.Substring(0, queryFilter.Length - 2);
        return queryFilter;
    }

    protected string addCharacteristics(int PropID)
    {
        System.Data.SqlClient.SqlConnection charConn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());
        string appendChar = "";

        //Showing the other results that are most similar to the attributes selected
        string charButton = "SELECT * " +
            "FROM Host FULL OUTER JOIN " +
            "Property ON Host.HostID = Property.HostID FULL OUTER JOIN Account ON Host.HostID = Account.AccountID FULL OUTER JOIN " +
            "Characteristics ON Account.AccountID = Characteristics.AccountID FULL OUTER JOIN PropertyRoom ON Property.PropertyID = PropertyRoom.PropertyID " +
            "WHERE Property.PropertyID = " + PropID;

        int charCount = 0;

        System.Data.SqlClient.SqlCommand charB = new System.Data.SqlClient.SqlCommand(charButton, charConn);
        charConn.Open();
        //Seeing if any matches with the characteristics
        SqlDataReader rdr = charB.ExecuteReader();

        while (rdr.Read())
        {
            if (charCount < 3)
            {
                if (rdr["HomeShareSmarter"].ToString() == "1" && cbHomeShareYES.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">HomeshareSmarter® Living</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["Extrovert"].ToString() == "1" && cbExtrovert.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Extrovert</button>";
                    charCount++;
                }
            }
            if (charCount < 3)
            {
                if (rdr["Introvert"].ToString() == "1" && cbIntrovert.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Introvert</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["NonSmoker"].ToString() == "1" && cbNonSmoker.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Non-Smoker</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["EarlyRiser"].ToString() == "1" && cbEarlyRiser.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Early-Riser</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["NightOwl"].ToString() == "1" && cbNightOwl.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Night Owl</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["TechSavvy"].ToString() == "1" && cbTechSavvy.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Tech-Savvy</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["FamilyOriented"].ToString() == "1" && cbFamily.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Family-Oriented</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["Kitchen"].ToString() == "1" && cbKitchen.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Kitchen</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["HVAC"].ToString() == "1" && cbHVAC.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Heating / Air Conditioning</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["Wifi"].ToString() == "1" && cbWifi.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Wifi</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["PrivateBR"].ToString() == "1" && cbPrivateBath.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Private Bathroom</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["WashAndDry"].ToString() == "1" && cbWashDry.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Washer and Dryer</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["WalkInCloset"].ToString() == "1" && cbWalkInCloset.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Walk-In Closet</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["StreetParking"].ToString() == "1" && cbStreetPark.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Street Parking</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["GarageParking"].ToString() == "1" && cbGarPark.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">GarageParking</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["Backyard"].ToString() == "1" && cbBackyard.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Backyard</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["PorchOrDeck"].ToString() == "1" && cbEnglish.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">English</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["Pool"].ToString() == "1" && cbPool.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Pool</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["English"].ToString() == "1" && cbEnglish.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">English</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["Spanish"].ToString() == "1" && cbSpanish.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Spanish</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["Mandarin"].ToString() == "1" && cbMandarin.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Mandarin</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["Japanese"].ToString() == "1" && cbJapanese.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Japanese</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["German"].ToString() == "1" && cbGerman.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">German</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["French"].ToString() == "1" && cbFrench.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">French</button>";
                    charCount++; ;
                }
            }
        }
        rdr.Close();
        charConn.Close();

        return appendChar;
    }
}
