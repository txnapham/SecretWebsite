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


public partial class Search_Tenant : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //Access for certain account types on this page
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
        //Tenant Access
        if (Session["AccountId"] != null && Convert.ToInt16(Session["type"]) == 3)
        {
            divider.Text = String.Empty;
            filterCard.Text = String.Empty;

            //Search for Home 
            if (Session["Search"] != null)
            {
                String homeSearch = "";
                homeSearch = Convert.ToString(Session["Search"]);
                txtSearch.Text = homeSearch;
                btnSearch_Click(sender, e);
            }
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        filterCard.Text = string.Empty;
        //Shows the search results with the sorting and ones of main interest
        cardBuilder(mainResults, filter(), txtSearch.Text);
        divider.Text = "<hr/>" +
            "<strong>Other Results in State That May Interest You:</strong> ";
        cardBuilder(otherResults, filterOtherResults(), txtSearch.Text);
    }


    public string cardBuilder(Literal name,string cardQuery, string searchString)
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
            SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());
            sqlConn.Open();

            String tSearch = HttpUtility.HtmlEncode(searchString);
            int commaSplit = tSearch.IndexOf(",");
            String cityString = tSearch.Substring(0, commaSplit).ToUpper();
            String state = tSearch.Substring(commaSplit + 2).ToUpper();

            System.Data.SqlClient.SqlCommand sqlComm = new System.Data.SqlClient.SqlCommand(cardQuery, sqlConn);
            sqlComm.Parameters.Add(new SqlParameter("@City", cityString));
            sqlComm.Parameters.Add(new SqlParameter("@State", state));
            System.Data.SqlClient.SqlDataReader reader = sqlComm.ExecuteReader();

            name.Text = "";
            int resultCount = 0;

            while (reader.Read())
            {
                int PropID = Convert.ToInt32(reader["PropertyID"]);
                String city = reader["City"].ToString();
                String homeState = reader["HomeState"].ToString();
                String priceRangeLow = reader["RoomPriceRangeLow"].ToString();
                String priceRangeHigh = reader["RoomPriceRangeHigh"].ToString();
                String filename = reader["images"].ToString();
                if (filename == "") filename = "imagenotfound.png";

                System.Data.SqlClient.SqlCommand modal = new System.Data.SqlClient.SqlCommand();
                modal.Connection = sc;
                modal.CommandText = "SELECT PropertyImages.images, PropertyRoom.AboutPropertyRoom " +
                    "FROM PropertyImages INNER JOIN" +
                    " Property ON PropertyImages.PropertyID = Property.PropertyID INNER JOIN" +
                    "PropertyRoom ON Property.PropertyID = PropertyRoom.PropertyID" +
                    "WHERE Property.PropertyID = "+PropID;

                double priceLowRounded = Math.Round(Convert.ToDouble(priceRangeLow), 0, MidpointRounding.ToEven);
                double priceHighRounded = Math.Round(Convert.ToDouble(priceRangeHigh), 0, MidpointRounding.ToEven);
                string chars = addCharacteristics(PropID);

                //Displays property on card 
                StringBuilder myCard = new StringBuilder();
                myCard
                .Append("<div class=\"col-xs-4 col-md-3\">")
                .Append("   <div class=\"card  shadow-sm  mb-4\" >")
                .Append("       <img class=\"img-fluid card-img-small\" src=\"https://duvjxbgjpi3nt.cloudfront.net/PropertyImages/" + filename + "\" />")
                .Append("       <a data-toggle=\"modal\" href=\"#propDetailModal\" class=\"cardLinks\">")
                .Append("           <div class=\"card-body\">")
                .Append("               <h5 class=\"card-title\">" + city + ", " + homeState + "</h5>")
                .Append("               <p class=\"card-text\">" + "$" + priceLowRounded + " - " + "$" + priceHighRounded + "</p>")
                .Append(chars)
                .Append("           </div>")
                .Append("       </a>")
                .Append("       <div>")
                .Append("           <button type=\"button\" id=\"heartbtn" + resultCount + "\" onClick=\"favoriteBtn(" + PropID + "," + "\'" + city + "\'" + "," +
                                    "\'" + homeState + "\'" + "," + priceLowRounded + "," + priceHighRounded + ")\" " +
                                    "class=\"btn favoriteHeartButton\"><i id=\"hearti\" class=\"far fa-heart\"></i></button>")
                .Append("       </div>")
                .Append("   </div>")
                .Append("</div>")
                .Append(" ")
                .Append("<div class=\"modal\" id=\"propDetailModal\">")
                .Append("    <div class=\"modal-dialog modal-lg\">")
                .Append("        <div class=\"modal-content\">")
                .Append("            <div class=\"modal-body\">")
                .Append("                <div class=\"container-fluid searchpageDetailBodyContent pl-0 pr-0 mt-0\">")
                .Append("                    <div id=\"carousel-thumb\" class=\"carousel slide carousel-fade carousel-thumbnails\" data-ride=\"carousel\">")
                .Append("                        <div class=\"carousel-inner\" role=\"listbox\">")
                .Append("                            <div class=\"carousel-item active\">")
                .Append("                                <img class=\"d-block w-100\" src=\"images/anthony-rooke--NJO7AF0mUo-unsplash.jpg\"")
                .Append("                                    alt=\"First slide\">")
                .Append("                            </div>")
                .Append("")
                .Append("                            <div class=\"carousel-item\">")
                .Append("                                <img class=\"d-block w-100\" src=\"images/loft-style-bedroom.jpg\"")
                .Append("                                    alt=\"Second slide\">")
                .Append("                            </div>")
                .Append("")
                .Append("                            <div class=\"carousel-item\">")
                .Append("                                <img class=\"d-block w-100\" src=\"images/scott-webb-1ddol8rgUH8-unsplash.jpg\"")
                .Append("                                    alt=\"Third slide\">")
                .Append("                            </div>")
                .Append("                        </div>")
                .Append("")
                .Append("                        <a class=\"carousel-control-prev\" href=\"#carousel-thumb\" role=\"button\" data-slide=\"prev\">")
                .Append("                            <span class=\"carousel-control-prev-icon\" aria-hidden=\"true\"></span>")
                .Append("                            <span class=\"sr-only\">Previous</span>")
                .Append("                        </a>")
                .Append("")
                .Append("                        <a class=\"carousel-control-next\" href=\"#carousel-thumb\" role=\"button\" data-slide=\"next\">")
                .Append("                            <span class=\"carousel-control-next-icon\" aria-hidden=\"true\"></span>")
                .Append("                            <span class=\"sr-only\">Next</span>")
                .Append("                        </a>")
                .Append("")
                .Append("                        <ol class=\"carousel-indicators\">")
                .Append("                            <li data-target=\"#carousel-thumb\" data-slide-to=\"0\" class=\"active\">")
                .Append("                                <img src=\"images/anthony-rooke--NJO7AF0mUo-unsplash.jpg\" width=\"100\">")
                .Append("                            </li>")
                .Append("                            <li data-target=\"#carousel-thumb\" data-slide-to=\"1\">")
                .Append("                                <img src=\"images/loft-style-bedroom.jpg\" width=\"100\">")
                .Append("                            </li>")
                .Append("                            <li data-target=\"#carousel-thumb\" data-slide-to=\"2\">")
                .Append("                                <img src=\"images/scott-webb-1ddol8rgUH8-unsplash.jpg\" width=\"100\">")
                .Append("                            </li>")
                .Append("                        </ol>")
                .Append("                    </div>")
                .Append("")
                .Append("                    <section>")
                .Append("                        <div class=\"row propertyPageDetailTitle pt-3 pb-3\">")
                .Append("                            <div class=\"col-md-10 pl-5\">")
                .Append("                                <h2>Kew Gardens</h2>")
                .Append("                            </div>")
                .Append("                            <div class=\"col-md-2\">")
                .Append("                                <button class=\"btn favoriteHeartButton\"><i class=\"far fa-heart\"></i></button>")
                .Append("                            </div>")
                .Append("            ")
                .Append("                            <div class=\"col-md-12\">")
                .Append("                                <div class=\"pl-3\">")
                .Append("                                    <button class=\"btn personality-outline btn-sm\">Extrovert</button>")
                .Append("                                    <button class=\"btn personality-outline btn-sm\">Wifi</button>")
                .Append("                                    <button class=\"btn personality-outline btn-sm\">Street Parking</button>")
                .Append("                                </div>")
                .Append("                            </div>")
                .Append("            ")
                .Append("                        </div>")
                .Append("                    </section>")
                .Append("            ")
                .Append("                    <section>")
                .Append("                        <div class=\"row px-5 py-5\">")
                .Append("                            <div class=\"col-md-8 \">")
                .Append("                                <div class=\"col-md-12 card  shadow-sm  px-5 py-5\">")
                .Append("                                    <div>")
                .Append("                                        <h4>AboutProperty</h4>")
                .Append("                                    </div>")
                .Append("                                </div>")
                .Append("            ")
                .Append("                                <div class=\"col-md-12 card  shadow-sm  px-5 py-5\">")
                .Append("                                    <div>")
                .Append("                                        <h4>Amenities</h4>")
                .Append("                                    </div>")
                .Append("                                </div>")
                .Append("            ")
                .Append("                                <div class=\"col-md-12 card  shadow-sm  px-5 py-5\">")
                .Append("                                    <div>")
                .Append("                                        <h4>Local Information</h4>")
                .Append("                                    </div>")
                .Append("                                </div>")
                .Append("                            </div>")
                .Append("                        </div>")
                .Append("            ")
                .Append("                    </section>")
                .Append("                </div>")
                .Append("            </div>")
                .Append("        </div>")
                .Append("    </div>")
                .Append("</div>");

                name.Text += myCard.ToString();
                resultCount++;
                Session["Search"] = null;            
                }
                
            reader.Close();
            Session["Search"] = null;
            resultLabel.Visible = true;
            resultLabel.Text = "Search Results for " + tSearch;
        }
        else
        {
            //Label for no search results
            resultLabel.Visible = true;
            resultLabel.Text = "No searches match your criteria.";
        }

        return cardString;
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static void MiddleMan(int propertyID, string city, string state, double priceLow, double priceHigh)
    {
        int propID = propertyID;
        int loginID = Convert.ToInt32(HttpContext.Current.Session["AccountId"].ToString());

        System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["roommagnetdbConnectionString"].ToString());
        sqlConn.Open();
        //Show the amount of properties that have been favorited 
        System.Data.SqlClient.SqlCommand check = new System.Data.SqlClient.SqlCommand();
        check.Connection = sqlConn;
        check.CommandText = "SELECT COUNT(*) FROM [dbo].[FavoritedProperties] WHERE (TenantID = @tenantID) AND (PropertyID = @propertyID)";
        check.Parameters.Add(new SqlParameter("@tenantID", loginID));
        check.Parameters.Add(new SqlParameter("@propertyID", propID));
        int checkValue = (int)check.ExecuteScalar();
        
        if(checkValue == 0)
        {
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sqlConn;
            insert.CommandText = "INSERT into [dbo].[FavoritedProperties] VALUES(@tenantID, @propertyID)";
            insert.Parameters.Add(new SqlParameter("@tenantID", loginID));
            insert.Parameters.Add(new SqlParameter("@propertyID", propID));

            insert.ExecuteNonQuery();
        }
        else if (checkValue == 1)
        {
            System.Data.SqlClient.SqlCommand delete = new System.Data.SqlClient.SqlCommand();
            delete.Connection = sqlConn;
            delete.CommandText = "DELETE FROM [dbo].[FavoritedProperties] WHERE (TenantID = @tenantID) AND (PropertyID = @propertyID)";
            delete.Parameters.Add(new SqlParameter("@tenantID", loginID));
            delete.Parameters.Add(new SqlParameter("@propertyID", propID));

            delete.ExecuteNonQuery();
        }
    }
    
    protected string filter()
    {
        //SQL for amount of filters that match 
        string queryFilter = "SELECT P.PropertyID, P.City, P.HomeState, P.RoomPriceRangeLow, P.RoomPriceRangeHigh, I.images " +
            "FROM Account A FULL OUTER JOIN Characteristics C ON A.AccountID = C.AccountID FULL OUTER JOIN Host H ON A.AccountID = H.HostID FULL OUTER JOIN " +
            "PropertyImages I FULL OUTER JOIN Property P ON I.PropertyID = P.PropertyID ON H.HostID = P.HostID  FULL OUTER JOIN PropertyRoom R ON R.PropertyID = P.PropertyID " +
            "WHERE P.City = @City AND P.HomeState = @State   ";
        string orderBy = " ";

        //Counter for amount of matching filters
        int qualityCount = 0;
        


        StringBuilder filterBreadCrumbs = new StringBuilder();
        filterBreadCrumbs.Append("<li class=\"breadcrumb-item active\" aria-current=\"page\"> Filters Applied: ");

        //Checked HomeShare
        //Showing the results in a sorted way by number of matches to filters
        //Shows the main result 
        //HomeShare Filter
        if (cbHomeShareYES.Checked == true)
        {
            queryFilter += "AND P.HomeShareSmarter = 1   ";
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">HomeshareSmarter®</button>");
        }
        if (cbHomeShareNO.Checked == true)
        {
            queryFilter += "AND P.HomeShareSmarter = 0   ";
        }

        queryFilter += "GROUP BY P.PropertyID, P.City, P.HomeState, P.RoomPriceRangeLow, P.RoomPriceRangeHigh, I.images,  ";

        //Extrovert Filter
        if (cbExtrovert.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Extrovert</button>");
            queryFilter += "C.Extrovert, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.Extrovert DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.Extrovert DESC, ";
            }
        }
        //Introvert Filter
        if (cbIntrovert.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Introvert</button>");
            queryFilter += "C.Introvert, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.Introvert DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.Introvert DESC, ";
            }
        }
        //NonSmoking Filter
        if (cbNonSmoker.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Non-Smoker</button>");
            queryFilter += "C.NonSmoker, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.NonSmoker DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.NonSmoker DESC, ";
            }
        }
        //Early Riser Filter
        if (cbEarlyRiser.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Early-Riser</button>");
            queryFilter += "C.EarlyRiser, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.EarlyRiser DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.EarlyRiser DESC, ";
            }
        }
        //Night Owl Filter
        if (cbNightOwl.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Night Owl</button>");
            queryFilter += "C.NightOwl, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.NightOwl DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.NightOwl DESC, ";
            }
        }
        //TechSavvy Filter
        if (cbTechSavvy.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Tech-Savvy</button>");
            queryFilter += "C.TechSavvy, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.TechSavvy DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.TechSavvy DESC, ";
            }
        }
        //Family Oriented Filter 
        if (cbFamily.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Family-Oriented</button>");
            queryFilter += "C.FamilyOriented, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.FamilyOriented DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.FamilyOriented DESC, ";
            }
        }
        //Property Ammenities 
        //Kitchen 
        if (cbKitchen.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Kitchen</button>");
            queryFilter += "R.Kitchen, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY R.Kitchen DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "R.Kitchen DESC, ";
            }
        }
        //Heating/ AC Filter
        if (cbHVAC.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Heating/AC</button>");
            queryFilter += "R.HVAC, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY R.HVAC DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "R.HVAC DESC, ";
            }
        }
        //Wifi Filter
        if (cbWifi.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">WiFi</button>");
            queryFilter += "R.Wifi, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY R.Wifi DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "R.Wifi DESC, ";
            }
        }
        //Private Bathroom Filter 
        if (cbPrivateBath.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Private Bathroom</button>");
            queryFilter += "R.PrivateBR, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY R.PrivateBR DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "R.PrivateBR DESC, ";
            }
        }
        //Walk In Closet Filter
        if (cbWalkInCloset.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Walk-In Closet</button>");
            queryFilter += "R.WalkInCloset, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY R.WalkInCloset DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "R.WalkInCloset DESC, ";
            }
        }
        //Washer Dryer Filter
        if (cbWashDry.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Washer/Dryer</button>");
            queryFilter += "R.WashAndDry, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY R.WashAndDry DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "R.WashAndDry DESC, ";
            }
        }
        //Street Parking Filter
        if (cbStreetPark.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Street Parking</button>");
            queryFilter += "P.StreetParking, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY P.StreetParking DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "P.StreetParking DESC, ";
            }
        }
        //Garage Parking Filter
        if (cbGarPark.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Garage Parking</button>");
            queryFilter += " P.GarageParking, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY P.GarageParking DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += " P.GarageParking DESC, ";
            }
        }
        //Backyard Filter
        if (cbBackyard.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Backyard</button>");
            queryFilter += "P.Backyard, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY P.Backyard DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "P.Backyard DESC, ";
            }
        }
        //Porch Filter
        if (cbPorch.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Porch/Deck</button>");
            queryFilter += "P.PorchOrDeck, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY P.PorchOrDeck DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "P.PorchOrDeck DESC, ";
            }
        }
        //Pool Filter
        if (cbPool.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Pool</button>");
            queryFilter += "P.Pool, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY P.Pool DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "P.Pool DESC, ";
            }
        }
        //Languages Filters
        //English 
        if (cbEnglish.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">English</button>");
            queryFilter += "C.English, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.English DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.English DESC, ";
            }
        }
        //Spanish
        if (cbSpanish.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Spanish</button>");
            queryFilter += "C.Spanish, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.Spanish DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.Spanish DESC, ";
            }
        }
        //Mandarin
        if (cbMandarin.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Mandarin</button>");
            queryFilter += "C.Mandarin, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.Mandarin DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.Mandarin DESC, ";
            }
        }
        //Japanese
        if (cbJapanese.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">Japenese</button>");
            queryFilter += "C.Japanese, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.Japanese DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.Japanese DESC, ";
            }
        }
        //German
        if (cbGerman.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">German</button>");
            queryFilter += "C.German, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.German DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.German DESC, ";
            }
        }
        //French 
        if (cbFrench.Checked == true)
        {
            filterBreadCrumbs.Append("<button class=\"btn personality-outline btn-sm\">French</button>");
            queryFilter += "C.French, ";

            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.French DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.French DESC, ";
            }
        }

        //Number of attributes that are a match 
        filterBreadCrumbs.Append("</li>");
        filterCard.Text += filterBreadCrumbs.ToString();

        //Shows the amount of filters chosen/in property 
        queryFilter = queryFilter.Substring(0, queryFilter.Length - 2);
        queryFilter += orderBy;
        queryFilter = queryFilter.Substring(0, queryFilter.Length - 2);

        return queryFilter;
    }

    protected string filterOtherResults()
    {
        string queryFilter = "SELECT P.PropertyID, P.City, P.HomeState, P.RoomPriceRangeLow, P.RoomPriceRangeHigh, I.images " +
            "FROM Account A FULL OUTER JOIN Characteristics C ON A.AccountID = C.AccountID FULL OUTER JOIN Host H ON A.AccountID = H.HostID FULL OUTER JOIN " +
            "PropertyImages I FULL OUTER JOIN Property P ON I.PropertyID = P.PropertyID ON H.HostID = P.HostID  FULL OUTER JOIN PropertyRoom R ON R.PropertyID = P.PropertyID " +
            "WHERE P.City != @City AND P.HomeState = @State   ";

        string orderBy = " ";

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

        queryFilter += "GROUP BY P.PropertyID, P.City, P.HomeState, P.RoomPriceRangeLow, P.RoomPriceRangeHigh, I.images,  ";

        //Extrovert Filter
        if (cbExtrovert.Checked == true)
        {
            queryFilter += "C.Extrovert, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.Extrovert DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.Extrovert DESC, ";
            }
        }
        //Introvert Filter
        if (cbIntrovert.Checked == true)
        {
            queryFilter += "C.Introvert, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.Introvert DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.Introvert DESC, ";
            }
        }
        //Non-Smoking Filter
        if (cbNonSmoker.Checked == true)
        {
            queryFilter += "C.NonSmoker, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.NonSmoker DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.NonSmoker DESC, ";
            }
        }
        //Early Riser Filter
        if (cbEarlyRiser.Checked == true)
        {
            queryFilter += "C.EarlyRiser, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.EarlyRiser DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.EarlyRiser DESC, ";
            }
        }
        //Night Owl Filter
        if (cbNightOwl.Checked == true)
        {
            queryFilter += "C.NightOwl, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.NightOwl DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.NightOwl DESC, ";
            }
        }
        //TechSavvy Filter 
        if (cbTechSavvy.Checked == true)
        {
            queryFilter += "C.TechSavvy, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.TechSavvy DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.TechSavvy DESC, ";
            }
        }
        //Family Oriented Filter 
        if (cbFamily.Checked == true)
        {
            queryFilter += "C.FamilyOriented, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.FamilyOriented DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.FamilyOriented DESC, ";
            }
        }
        //Kitchen Ammenity Filter
        if (cbKitchen.Checked == true)
        {
            queryFilter += "R.Kitchen, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY R.Kitchen DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "R.Kitchen DESC, ";
            }
        }
        //Heating AC Filter
        if (cbHVAC.Checked == true)
        {
            queryFilter += "R.HVAC, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY R.HVAC DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "R.HVAC DESC, ";
            }
        }
        //Wifi Filter
        if (cbWifi.Checked == true)
        {
            queryFilter += "R.Wifi, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY R.Wifi DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "R.Wifi DESC, ";
            }
        }
        //Private Bathroom Filter
        if (cbPrivateBath.Checked == true)
        {
            queryFilter += "R.PrivateBR, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY R.PrivateBR DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "R.PrivateBR DESC, ";
            }
        }
        //Walk in Closet Filter
        if (cbWalkInCloset.Checked == true)
        {
            queryFilter += "R.WalkInCloset, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY R.WalkInCloset DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "R.WalkInCloset DESC, ";
            }
        }
        //Washer/Dryer Filter
        if (cbWashDry.Checked == true)
        {
            queryFilter += "R.WashAndDry, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY R.WashAndDry DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "R.WashAndDry DESC, ";
            }
        }
        //Street Parking Filter
        if (cbStreetPark.Checked == true)
        {
            queryFilter += "P.StreetParking, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY P.StreetParking DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "P.StreetParking DESC, ";
            }
        }
        //Garage Filter
        if (cbGarPark.Checked == true)
        {
            queryFilter += " P.GarageParking, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY P.GarageParking DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += " P.GarageParking DESC, ";
            }
        }
        //Backyard Filter
        if (cbBackyard.Checked == true)
        {
            queryFilter += "P.Backyard, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY P.Backyard DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "P.Backyard DESC, ";
            }
        }
        //Porch Filter
        if (cbPorch.Checked == true)
        {
            queryFilter += "P.PorchOrDeck, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY P.PorchOrDeck DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "P.PorchOrDeck DESC, ";
            }
        }
        //Pool Filter 
        if (cbPool.Checked == true)
        {
            queryFilter += "P.Pool, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY P.Pool DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "P.Pool DESC, ";
            }
        }
        //Languages Filters 
        //English
        if (cbEnglish.Checked == true)
        {
            queryFilter += "C.English, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.English DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.English DESC, ";
            }
        }
        //Spanish
        if (cbSpanish.Checked == true)
        {
            queryFilter += "C.Spanish, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.Spanish DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.Spanish DESC, ";
            }
        }
        //Mandarin
        if (cbMandarin.Checked == true)
        {
            queryFilter += "C.Mandarin, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.Mandarin DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.Mandarin DESC, ";
            }
        }
        //Japanese
        if (cbJapanese.Checked == true)
        {
            queryFilter += "C.Japanese, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.Japanese DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.Japanese DESC, ";
            }
        }
        //German
        if (cbGerman.Checked == true)
        {
            queryFilter += "C.German, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.German DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.German DESC, ";
            }
        }
        //French
        if (cbFrench.Checked == true)
        {
            queryFilter += "C.French, ";
            if (qualityCount == 0)
            {
                orderBy += " ORDER BY C.French DESC, ";
                qualityCount++;
            }
            else
            {
                orderBy += "C.French DESC, ";
            }
        }

        //Shows the amount of filters chosen/in property 
        queryFilter = queryFilter.Substring(0, queryFilter.Length - 2);
        queryFilter += orderBy;
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
                    appendChar += "<button class=\"btn personality-outline btn-sm\">HomeshareSmarter®</button>";
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
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Heating/AC</button>";
                    charCount++; ;
                }
            }
            if (charCount < 3)
            {
                if (rdr["Wifi"].ToString() == "1" && cbWifi.Checked == true)
                {
                    appendChar += "<button class=\"btn personality-outline btn-sm\">WiFi</button>";
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
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Washer/Dryer</button>";
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
                    appendChar += "<button class=\"btn personality-outline btn-sm\">Porch/Deck</button>";
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
            if(charCount == 0)
            {
                appendChar += "<br/>";
                charCount++; ;
            }
        }
        rdr.Close();
        charConn.Close();

        return appendChar;
    }
}
