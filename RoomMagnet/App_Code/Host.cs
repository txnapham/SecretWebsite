using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Host
/// </summary>
public class Host : Account
{
    private int BackCheck;
    private string HostReason;

    public Host(Account account, int BackCheck, string HostReason)
        : base(account.getFirstName(), account.getMiddleName(), account.getLastName(), account.getPhone(), 
            account.getBday(), account.getEmail(), account.getHouseNumber(), account.getStreet(), account.getCity(), 
            account.getState(), account.getZip(), account.getCountry(), account.getAccType(), account.getPID())
    {
        setBackCheck(BackCheck);
        setHostReason(HostReason);
    }
    
    //Setters
    public void setBackCheck(int BackCheck)
    {
        this.BackCheck = BackCheck;
    }
    public void setHostReason(string HostReason)
    {
        this.HostReason = HostReason;
    }

    //getter
    public int getBackCheck()
    {
        return this.BackCheck;
    }
    public string getHostReason()
    {
        return this.HostReason;
    }
}