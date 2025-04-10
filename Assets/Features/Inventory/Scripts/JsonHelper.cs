using System;
using System.IO;
using UnityEngine;

public static class JsonHelper
{
    public static T Load<T>(string path)
    {
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            Debug.Log(jsonData);
            return JsonUtility.FromJson<T>(jsonData);
        }
        else
        {
            Debug.LogWarning($"File not found at path: {path}");
            return default;
        }
    }

    public static void Save<T>(string path, T data)
    {
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(path, jsonData);
    }
}
