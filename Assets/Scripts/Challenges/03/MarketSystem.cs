using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem
{
    public string Name;
    public int Price;

    public TestItem(string name, int price) { Name = name; Price = price; }
}

public class MarketSystem : MonoBehaviour
{
    void Start()
    {
        List<TestItem> shopItems = new List<TestItem>
        {
            new TestItem("Iron Sword", 100),
            new TestItem("Golden Bow", 600),
            new TestItem("Potion", 50),
            new TestItem("Magic Staff", 1200),
            new TestItem("Shield", 150)
        };

        Predicate<TestItem> IsCheapItem = (item) => item.Price < 500;
        Func<TestItem, string> CheapItemNames = (item) => item.Name;

        var cheapItems = FilterItems(shopItems, IsCheapItem);
        List<string> itemNames = MapNames(cheapItems, CheapItemNames);

        foreach(string itemName in itemNames)
        {
            Debug.Log($"Filtered item name: {itemName}");
        }
    }
    private List<TestItem> FilterItems(List<TestItem> items, Predicate<TestItem> filteredItem)
    {
        var resultList = new List<TestItem>();
        foreach (var item in items)
        {
            if (filteredItem(item))
                resultList.Add(item);
        }
        return resultList;
    }
    private List<string> MapNames(List<TestItem> items, Func<TestItem, string> transforms)
    {
        var resultList = new List<string>();
        foreach (var item in items)
        {
            resultList.Add(item.Name);
        }
        return resultList;
    }
}
