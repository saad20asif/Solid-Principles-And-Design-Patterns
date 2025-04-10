using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CodeJam : SerializedMonoBehaviour
{
    //1) Given int second display time in hh:mm:ss
    [Button]
    public void PrintFormattedTime(int seconds)
    {
        int secs = seconds % 60;
        int mins = (seconds / 60) % 60;
        int hours24 = (seconds / 3600) % 24; // Time on a 24-hour clock

        // Determine AM or PM
        string period = hours24 >= 12 ? "PM" : "AM";

        // Convert 24-hour format to 12-hour format
        int hours12 = hours24 % 12;
        if (hours12 == 0)
            hours12 = 12;

        // Print the time in HH : MM : SS AM/PM format
        print($"{hours12:D2} : {mins:D2} : {secs:D2} {period}");
    }





    //You are given an array(or list) of strings.Your task is to determine the element (string
    //that occurs most frequently in the array. In other words, you need to find the string with
    //the highest frequency.
    //However, there is a tie-breaker rule:
    //Tie-Breaker: If two or more strings have the same maximum frequency and have the same length,
    //then choose the string that is lexicographically greater (i.e., comes later in alphabetical order).
    [SerializeField] private Dictionary<string,int> elementsFrequency = new Dictionary<string,int>();
    [Button]
    [ContextMenu("Find Highest Frequency Element")]
    private void HighestFrequencyElement(List<string> listOfString)
    {
        // Clear the dictionary if this method is called more than once.
        elementsFrequency.Clear();

        // Build the frequency dictionary using a for loop.
        for (int i = 0; i < listOfString.Count; i++)
        {
            string current = listOfString[i];
            if (elementsFrequency.ContainsKey(current))
            {
                elementsFrequency[current]++;
            }
            else
            {
                elementsFrequency.Add(current, 1);
            }
        }

        // Create a list of keys to iterate using a for loop.
        List<string> keys = new List<string>(elementsFrequency.Keys);

        string candidate = null;
        int maxFrequency = 0;

        // Iterate over the keys using a for loop.
        for (int i = 0; i < keys.Count; i++)
        {
            string key = keys[i];
            int frequency = elementsFrequency[key];

            if (frequency > maxFrequency)
            {
                maxFrequency = frequency;
                candidate = key;
            }
            else if (frequency == maxFrequency)
            {
                // Apply the tie-breaker only if both strings have the same length.
                if (candidate != null && candidate.Length == key.Length)
                {
                    // Use string.Compare: if key is lexicographically greater, update candidate.
                    if (string.Compare(key, candidate) > 0)
                    {
                        candidate = key;
                    }
                }
            }
        }

        // Output the result.
        Debug.Log("Highest frequency element: " + candidate + " with frequency: " + maxFrequency);
    }


}
