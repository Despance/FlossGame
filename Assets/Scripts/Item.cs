using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    private string[] item = {"Umbrella","Wallet","Ball"};
    private string[] colors = {"Purple","Red","Blue","Orange","Yellow","Green"};
    private string[] types = {"Straight","Stars","Spotted"};
    private string[] locations = {"kadikoy","bebek","besiktas","nisantasi","maltepe"};

    

    public string itemType;
    public string itemColor;
    public string itemShape;
    public string itemLocation;
    public string itemTime;
    public int day;
    public int month;
    public string what;
    public Sprite sprite;

    public Item(string real)
    {

        what = real;
        if(real == "true" ||real == "false") {
        itemType = item[Random.Range(0, item.Length)];
        itemColor = colors[Random.Range(0, colors.Length)];
        itemShape = types[Random.Range(0, types.Length)];
        itemLocation = locations[Random.Range(0, locations.Length)];}
        
        
        day = Random.Range(1, 29);
        month = Random.Range(1, 12);
        itemTime = day + "." + month + ".2021";




    }

    public string randomDate ()
    {
        day = Random.Range(1, 29);
        month = Random.Range(1, 12);
        itemTime = day + "." + month + ".2021";
        return itemTime;
    }
    public void randomLocation()
    {
        itemLocation = locations[Random.Range(0, locations.Length)];
    }
    
}
