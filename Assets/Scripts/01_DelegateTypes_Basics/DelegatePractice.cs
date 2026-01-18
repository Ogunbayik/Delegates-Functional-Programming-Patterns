using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatePractice : MonoBehaviour
{
    [SerializeField] private List<Item> _inventory;
    private void Awake() => Initialize();
    private void Initialize()
    {
        _inventory = new List<Item>
        {
        new Item(1, Const.ItemName.ITEM_SWORD, 150, Const.ItemCategory.CATEGORY_WEAPON),
        new Item(2, Const.ItemName.ITEM_SHIELD, 80, Const.ItemCategory.CATEGORY_ARMOR),
        new Item(3, Const.ItemName.ITEM_POTION, 20, Const.ItemCategory.CATEGORY_CONSUMABLE),
        new Item(4, Const.ItemName.ITEM_BOW, 200, Const.ItemCategory.CATEGORY_WEAPON)
        };
    }
    private void Start()
    {
        FilterAndProcess(_inventory, i => i.ItemPrice >= 100, i => Debug.Log($"Expensive Item: {i.ItemName}"));
        CalculateAndPrint(_inventory, item => item.ItemPrice * 1.1f);
    }
    private void FilterAndProcess(List<Item> items, Predicate<Item> filter, Action<Item> action)
    {
        foreach (var item in items)
        {
            if(filter(item))
            {
                action(item);
            }
        }
    }

    private void CalculateAndPrint(List<Item> items, Func<Item, double> calculator)
    {
        foreach (var item in items)
        {
            if(item.ItemCategory == Const.ItemCategory.CATEGORY_WEAPON)
            {
                var result  = calculator(item);
                Debug.Log($"{item.ItemName} Price: {result}");
            }
        }
    }
}
