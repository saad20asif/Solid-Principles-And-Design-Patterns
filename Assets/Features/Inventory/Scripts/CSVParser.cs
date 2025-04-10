using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class CSVParser
{
    static StringReader stringReader;

    public static List<string[]> GetDataListFromCSV(TextAsset csv)
    {
        stringReader = new StringReader(csv.text);
        List<string[]> data = new List<string[]>();
        string splitStr = ",";

        while (stringReader.Peek() != -1)
        {
            string line = stringReader.ReadLine();
            string[] items = line.Split(splitStr.ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
            data.Add(items);
        }
        return data;
    }

    /// <summary>
    /// Converts the list of string arrays parsed from a csv into a dictionary."
    /// </summary>
    public static Dictionary<string, string[]> GetDictionaryFromDataList(List<string[]> data)
    {
        // string dictionary based on line 0 keys, that has an array of items.
        Dictionary<string, string[]> datadic = new Dictionary<string, string[]>();

        for (int i = 0; i < data[0].Length; i++)
        {
            // array of items is size of data list minus 1 to account for line 0 which is keys. 
            string[] items = new string[data.Count - 1];

            // start at line 1, add item to array from data list j, i
            for (int j = 1; j < data.Count - 1; j++)
            {
                items[j - 1] = data[j][i];
            }

            // create a dictionary entry with keys from line 0, value items
            datadic.Add(data[0][i], items);
        }

        return datadic;
    }
}
