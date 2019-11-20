using System;

public class Tenant : Account
{
    //Attributes
    private int AccountID;
    private int BackgroundStatus;
    private String TenantReason;
    
    //Constructor
	public Tenant(Account account, int BackgroundStatus, String TenantReason)
        : base(account.getFirstName(), account.getMiddleName(), account.getLastName(), account.getPhone(),
            account.getBday(), account.getEmail(), account.getHouseNumber(), account.getStreet(), account.getCity(),
            account.getState(), account.getZip(), account.getCountry(), account.getAccType(), account.getPID())
    {
        setBackgroundStatus(BackgroundStatus);
        setTenantReason(TenantReason);
    }
    //Setters
    public void setBackgroundStatus(int BackgroundStatus)
    {
        this.BackgroundStatus = BackgroundStatus;
    }
    public void setTenantReason(String TenantReason)
    {
        this.TenantReason = TenantReason;
    }
    //Getters
    public int getBackgroundStatus()
    {
        return this.BackgroundStatus;
    }
    public String getTenantReason()
    {
        return this.TenantReason;
    }
}
