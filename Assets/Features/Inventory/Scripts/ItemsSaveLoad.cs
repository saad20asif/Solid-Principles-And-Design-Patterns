using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemsDataWrapper
{
    public List<ItemData> InventoryItems;
}

public class ItemsSaveLoad : MonoBehaviour
{
    [SerializeField] private string ItemsDataPath;
    [SerializeField] private ItemsData ItemsData;

    [Button]
    private void SaveItemsData()
    {
        var wrapper = new ItemsDataWrapper { InventoryItems = ItemsData.InventoryItems };
        JsonHelper.Save(ItemsDataPath, wrapper);
    }
    [Button]
    private void LoadItemsData()
    {
        ItemsDataWrapper loadedWrapper = JsonHelper.Load<ItemsDataWrapper>(ItemsDataPath);
        if (loadedWrapper != null)
        {
            ItemsData.InventoryItems = loadedWrapper.InventoryItems;
        }
    }
}
