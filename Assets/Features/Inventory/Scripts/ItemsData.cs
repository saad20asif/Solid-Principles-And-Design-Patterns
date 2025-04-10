using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string Name;
    public string Icon;
    public int Amount;
    public string Currency;

    public ItemData(string name, string iconname, int amount, string currency)
    {
        Name = name;
        Icon = iconname;    
        Amount = amount;
        Currency = currency;
    }
}
[CreateAssetMenu(fileName = "ItemsDataConfig", menuName = "ScriptableObjects/ItemsData")]
[Serializable]
public class ItemsData : ScriptableObject
{
    public List<ItemData> InventoryItems;
}
