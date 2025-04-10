using Sirenix.OdinInspector;
using UnityEngine;

public class MetaLoader : MonoBehaviour
{
    [SerializeField] private string filename;
    [SerializeField] private TextAsset asset;
    [SerializeField] private ItemsData ItemsData;
    [Button]
    private void LoadData()
    {
        asset = Resources.Load<TextAsset>(filename);
        if(asset == null )
        {
            Debug.LogError("File not found");
            return;
        }
        string[] lines = asset.text.Split('\n');
        ItemsData.InventoryItems.Clear();
        for (int i=1; i<lines.Length; i++)
        {
            string[] data = lines[i].Split(',');
            for(int j=0; j<data.Length; j++)
                print(data[j]);

            string Name = data[0];
            string Icon = data[1];
            int Amount = int.Parse(data[2]);
            string Currency = data[3];
            ItemData itemData = new ItemData(Name, Icon, Amount, Currency);
            ItemsData.InventoryItems.Add(itemData);
            print('\n');
        }
    }
}
