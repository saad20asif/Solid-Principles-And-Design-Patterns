using System.IO;
using UnityEngine;

public static class InventoryJSONUtility
{
    // Saves the ItemsData to a JSON file in the persistent data path.
    public static void SaveInventory(ItemsData itemsData, string fileName)
    {
        // Convert the ItemsData object to a JSON string.
        string json = JsonUtility.ToJson(itemsData, true);

        // Combine the persistent path with the file name.
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        // Write the JSON string to the file.
        File.WriteAllText(filePath, json);

        Debug.Log("Inventory saved to: " + filePath);
    }

    // Loads the ItemsData from a JSON file and overwrites the given ItemsData object.
    public static void LoadInventory(ItemsData itemsData, string fileName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        // Check if the file exists.
        if (File.Exists(filePath))
        {
            // Read the JSON string from the file.
            string json = File.ReadAllText(filePath);

            // Overwrite the existing itemsData with the JSON data.
            JsonUtility.FromJsonOverwrite(json, itemsData);

            Debug.Log("Inventory loaded from: " + filePath);
        }
        else
        {
            Debug.LogWarning("Save file not found at: " + filePath);
        }
    }
}
