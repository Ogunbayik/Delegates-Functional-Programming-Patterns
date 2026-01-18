using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int ItemID;
    public string ItemName;
    public double ItemPrice;
    public string ItemCategory;

    public Item(int itemID, string itemName, double itemPrice, string itemCategory)
    {
        ItemID = itemID;
        ItemName = itemName;
        ItemPrice = itemPrice;
        ItemCategory = itemCategory;
    }
}
