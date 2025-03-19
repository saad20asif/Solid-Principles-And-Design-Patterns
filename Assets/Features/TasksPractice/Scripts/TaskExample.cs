using Sirenix.OdinInspector;
using System.Threading.Tasks;
using UnityEngine;

public class TaskExample : MonoBehaviour
{
    private async void Start()
    {
        await MainAsync(); // Await the async method
    }

    public async Task<int> CalculateSumAsync(int a, int b)
    {
        Debug.Log("Calculating sum...");
        await Task.Delay(1000); // Simulate async work (e.g., I/O or delay)
        int sum = a + b;
        Debug.Log("Sum calculated!");
        return sum;
    }

    [Button]
    public async Task MainAsync()
    {
        Debug.Log("Starting calculation...");
        Task<int> sumTask = CalculateSumAsync(5, 10); // Start the async operation
        Debug.Log("Waiting for result...");
        int result = await sumTask; // Wait for the result
        Debug.Log($"Result: {result}");
    }
}