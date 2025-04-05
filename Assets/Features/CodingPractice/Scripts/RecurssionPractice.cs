using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class RecurssionPractice : SerializedMonoBehaviour
{
    [Button]
    public int CalculateFactorial(int number)
    {
        if (number < 0)
        {
            Debug.LogWarning("Cannot calculate the factorial of a negative number");
            return -1;
        }
        else if (number == 0 || number == 1)
        {
            return 1;
        }

        else
        {
            return number * CalculateFactorial(number - 1);
        }
    }


    [Button]
    // Cache to store computed Fibonacci numbers
    [OdinSerialize] private Dictionary<int, BigInteger> fibCache = new Dictionary<int, BigInteger>();

    [Button]
    private BigInteger Fibonacci(int n)
    {
        if (n < 0)
        {
            Debug.LogWarning("Fibonacci is not defined for negative numbers.");
            return -1;
        }
        if (n == 0) return 0;
        if (n == 1) return 1;

        // Check if value is already computed
        if (fibCache.ContainsKey(n))
            return fibCache[n];

        // Recursively compute and cache the result
        BigInteger result = Fibonacci(n - 1) + Fibonacci(n - 2);
        fibCache[n] = result;

        print("Fibonacci : " + result);
        return result;
    }

    [Button]
    public string ReverseString(string input)
    {
        // Base case: if the string is empty or has one character, return it as is.
        if (input.Length <= 1)
        {
            return input;
        }

        // Recursive call: reverse the substring from index 1 to the end,
        // and then append the first character at the end.
        print(input.Substring(1) + "  " + input[0]);
        return ReverseString(input.Substring(1)) + input[0];
    }
    [Button]
    public bool IsPalindrome(string input)
    {
        // Base case: If the string is empty or has one character, it's a palindrome.
        if (input.Length <= 1)
        {
            return true;
        }

        // If the first and last characters are not equal, it's not a palindrome.
        if (input[0] != input[input.Length - 1])
        {
            return false;
        }

        // Recursive call: Check the substring excluding the first and last characters.
        print(input.Substring(1, input.Length - 2));
        return IsPalindrome(input.Substring(1, input.Length - 2));
    }
    [Button]
    public void SolveTowerOfHanoi(int n)
    {
        // Starting the recursive process with labeled pegs
        MoveDisks(n, "Source", "Target", "Auxiliary");
    }

    private void MoveDisks(int n, string source, string target, string auxiliary)
    {
        // Base case: only one disk to move
        if (n == 1)
        {
            Debug.Log("Move disk 1 from " + source + " to " + target);
            return;
        }

        // Move n-1 disks from the source to the auxiliary peg using the target peg
        MoveDisks(n - 1, source, auxiliary, target);

        // Move the nth (largest) disk from source to target
        Debug.Log("Move disk " + n + " from " + source + " to " + target);

        // Move the n-1 disks from the auxiliary peg to the target peg using the source peg
        MoveDisks(n - 1, auxiliary, target, source);
    }
}
