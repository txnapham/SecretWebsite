using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Property
/// </summary>
public class Property
{
    private int propertyType;
    private String houseNumber;
    private String street;
    private String city;
    private String homeState;
    private String country;
    private String zip;
    private String houseRule;
    private int streetParking;
    private int garageParking;
    private int backyard;
    private int porchOrDeck;
    private int pool;
    private int petsAllowed;
    private int guestAllowed;
    private int nonSmoking;
    private int homeShareSmarter;
    private DateTime modifiedDate;
    private int hostID;
    private double roomPrice;
    private double lowPrice;
    private double highPrice;


    public Property(String houseNumber, String street, String city, String homeState, String zip, String country)
    {
        setHouseNumber(houseNumber);
        setStreet(street);
        setCity(city);
        setHomeState(homeState);
        setCountry(country);
        setZip(zip);
        setModDate(DateTime.Now);
    }

    //RoomPrices
    public double getRoomPrice()
    {
        return this.roomPrice;
    }

    public void setRoomPrices(double roomPrice)
    {
        this.roomPrice = roomPrice;
    }

    //propertyType
    public int getPropertyType()
    {
        return this.propertyType;
    }

    public void setPropertyType(int propertyType)
    {
        this.propertyType = propertyType;
    }

    //hostID
    public int getHostID()
    {
        return this.hostID;
    }

    public void setHostID(int hostID)
    {
        this.hostID = hostID;
    }

    //houseNumber
    public void setHouseNumber(String houseNumber)
    {
        this.houseNumber = houseNumber;
    }
    public String getHouseNumber()
    {
        return this.houseNumber;
    }


    public void setStreet(String street)
    {
        this.street = street;
    }
    public String getStreet()
    {
        return this.street;
    }
    public void setCity(String city)
    {
        this.city = city;
    }
    public String getCity()
    {
        return this.city;
    }
    public void setHomeState(String homeState)
    {

        this.homeState = homeState;
    }
    public String getHomeState()
    {
        return this.homeState;
    }
    public void setCountry(String country)
    {
        this.country = country;
    }
    public String getCountry()
    {
        return this.country;
    }
    public void setZip(String zip)
    {

        this.zip = zip;
    }
    public String getZip()
    {
        return this.zip;
    }

    //modifiedDate
    public DateTime getModDate()
    {
        return this.modifiedDate;
    }

    public void setModDate(DateTime ModDate)
    {
        this.modifiedDate = ModDate;
    }

    //StreetParking
    public void setStreetParking(int streetParking)
    {
        this.streetParking = streetParking;
    }

    public int getStreetParking()
    {
        return this.streetParking;
    }

    //GarageParking
    public void setGarageParking(int garageParking)
    {
        this.garageParking = garageParking;
    }

    public int getGarageParking()
    {
        return this.garageParking;
    }

    //Backyard
    public void setBackyard(int backyard)
    {
        this.backyard = backyard;
    }

    public int getBackyard()
    {
        return this.backyard;
    }

    //PorchOrDeck
    public void setPorchOrDeck(int porchOrDeck)
    {
        this.porchOrDeck = porchOrDeck;
    }

    public int getPorchOrDeck()
    {
        return this.porchOrDeck;
    }

    //Pool
    public void setPool(int pool)
    {
        this.pool = pool;
    }

    public int getPool()
    {
        return this.pool;
    }

    //NonSmoking
    public void setNonSmoking(int nonSmoking)
    {
        this.nonSmoking = nonSmoking;
    }

    public int getNonSmoking()
    {
        return this.nonSmoking;
    }

    //HomeShareSmarter
    public void setHomeShareSmarter(int homeShareSmarter)
    {
        this.homeShareSmarter = homeShareSmarter;
    }

    public int getHomeShareSmarter()
    {
        return this.homeShareSmarter;
    }

    //PetsAllowed
    public void setPets(int petsAllowed)
    {
        this.petsAllowed = petsAllowed;
    }

    public int getPets()
    {
        return this.petsAllowed;
    }

    //GuestAllowed
    public void setGuest(int guestAllowed)
    {
        this.guestAllowed = guestAllowed;
    }

    public int getGuest()
    {
        return this.petsAllowed;
    }
    
}