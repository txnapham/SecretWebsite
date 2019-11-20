using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Appointment
/// </summary>
public class Appointment
{
    private DateTime date;
    private int favTenID;
    public Appointment(DateTime date, int favTenID)
    {
        setDate(date);
        setfavTen(favTenID);
    }
    //setters
    public void setDate(DateTime date)
    {
        this.date = date;
    }
    public void setfavTen(int favTenID)
    {
        this.favTenID = favTenID;
    }
    //getter
    public DateTime getDate()
    {
        return this.date;
    }
    public int getfavTen()
    {
        return this.favTenID;
    }
}