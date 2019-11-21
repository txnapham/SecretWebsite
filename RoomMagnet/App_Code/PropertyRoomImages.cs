using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class PropertyRoomImages
{
    private int imagesID;
    private int propertyID;
    private int roomID;
    private string images;
    public static ArrayList propertyRoomImagesArray = new ArrayList();


    // Constrcutors
    public PropertyRoomImages(string images)
    {
        setImages(images);
    }

    public PropertyRoomImages(int propertyID, int roomID, string images)
    {
        setPropertyID(propertyID);
        setRoomID(roomID);
        setImages(images);
    }

    // Setters for PropertyRoomImages class
    public void setImagesID(int imagesID)
    {
        this.imagesID = imagesID;
    }

    public void setPropertyID(int propertyID)
    {
        this.propertyID = propertyID;
    }

    public void setRoomID(int roomID)
    {
        this.roomID = roomID;
    }

    public void setImages(string images)
    {
        this.images = images;
    }
    
    public void setPropertyRoomImagesArray(int propertyRoomImagesID)
    {
        propertyRoomImagesArray.Add(propertyRoomImagesID);
    }

    // Getters for PropertyRoomImages class
    public int getImagesID()
    {
        return this.imagesID;
    }

    public int getPropertyID()
    {
        return this.propertyID;
    }

    public int getRoomID()
    {
        return this.roomID; 
    }

    public string getImages()
    {
        return this.images;
    }
}