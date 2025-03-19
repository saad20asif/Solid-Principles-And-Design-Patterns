using Cysharp.Threading.Tasks;
using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class TaskExample : MonoBehaviour
{
    [SerializeField] private bool _useUniTask = false;
    private CancellationTokenSource _cts;

    #region Basic Async Operation
    [Button("Basic Async")]
    public async UniTask BasicAsyncOperation()
    {
        Debug.Log("Starting basic operation...");
        await UniTask.Delay(1000); // Use UniTask delay instead
        Debug.Log("Basic operation completed!");
    }
    #endregion

    #region Error Handling
    [Button("Error Handling")]
    public async UniTask TaskWithErrorHandling()
    {
        try
        {
            Debug.Log("Starting error-prone task...");
            await TaskThatMightFail();
        }
        catch (Exception ex)
        {
            Debug.LogError($"Caught exception: {ex.Message}");
        }
    }

    private async UniTask TaskThatMightFail()
    {
        await UniTask.Delay(500);
        throw new InvalidOperationException("Simulated error!");
    }
    #endregion

    #region Cancellation
    [Button("Start Cancellable Task")]
    public async UniTask StartCancellableTask()
    {
        _cts = new CancellationTokenSource();
        try
        {
            await LongRunningTask(_cts.Token);
            Debug.Log("Task completed successfully");
        }
        catch (OperationCanceledException)
        {
            Debug.LogWarning("Task was cancelled!");
        }
    }

    [Button("Cancel Task")]
    public void CancelTask()
    {
        _cts?.Cancel();
        _cts?.Dispose();
        _cts = null;
    }

    private async UniTask LongRunningTask(CancellationToken ct)
    {
        for (int i = 0; i < 10; i++)
        {
            ct.ThrowIfCancellationRequested();
            Debug.Log($"Progress: {i * 10}%");
            await UniTask.Delay(1000, cancellationToken: ct);
        }
    }
    #endregion

    #region Parallel Execution
    [Button("Parallel Tasks")]
    public async UniTask RunParallelTasks()
    {
        Debug.Log("Starting parallel tasks...");

        var task1 = UniTask.RunOnThreadPool(() => HeavyCalculation(1));
        var task2 = UniTask.RunOnThreadPool(() => HeavyCalculation(2));

        await UniTask.WhenAll(task1, task2);

        Debug.Log($"Results: {task1} ,  {task2}");
    }

    private int HeavyCalculation(int id)
    {
        // Simulate CPU-bound work (use UniTask.Yield for frame-based waiting)
        Thread.Sleep(2000); // Only for demonstration - use async waits in real code
        return id * 100;
    }
    #endregion

    #region Task Chaining
    [Button("Chained Tasks")]
    public async UniTask ChainedTasks()
    {
        var firstResult = await FirstTask();
        var secondResult = await SecondTask(firstResult);
        var finalResult = await FinalTask(secondResult);

        Debug.Log($"Final result: {finalResult}");
    }

    private async UniTask<int> FirstTask() => await UniTask.FromResult(10);
    private async UniTask<string> SecondTask(int input) => await UniTask.FromResult($"Processed: {input * 2}");
    private async UniTask<string> FinalTask(string input) => await UniTask.FromResult($"{input} - Finalized");
    #endregion

    #region Unity Coroutine Integration
    [Button("Coroutine Hybrid")]
    public async UniTask RunCoroutineAndTask()
    {
        Debug.Log("Starting hybrid operation...");

        // Convert coroutine to UniTask
        var coroutineTask = UnityCoroutine().ToUniTask(this);
        var dotweenTask = DotweenAnimationTask();

        // Wait for both tasks to complete
        await UniTask.WhenAll(coroutineTask, dotweenTask);

        Debug.Log("Hybrid operation completed!");
    }

    private IEnumerator UnityCoroutine()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Coroutine finished");
    }

    private async UniTask DotweenAnimationTask()
    {
        var target = transform;
        await target.DOMoveY(5, 1).AsyncWaitForCompletion();
        Debug.Log("Animation completed");
    }
    #endregion

    #region Advanced Patterns
    [Button("Fire-and-Forget")]
    public void FireAndForget()
    {
        // Use UniTask's fire-and-forget pattern
        FireAndForgetTask().Forget();
    }

    private async UniTaskVoid FireAndForgetTask()
    {
        await UniTask.Delay(1500);
        Debug.Log("Fire-and-forget completed");
    }

    [Button("ValueTask Example")]
    public async UniTask ValueTaskExample()
    {
        // Use UniTask's optimized delay
        await UniTask.Delay(500);
        Debug.Log("ValueTask completed");
    }
    #endregion

    #region UniTask Example
    [Button("UniTask Example")]
    public async UniTaskVoid UniTaskExample()
    {
        if (!_useUniTask) return;

        await UniTask.Delay(1000);
        Debug.Log("UniTask delay completed");

        await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        Debug.Log("Space pressed!");
    }
    #endregion

    private async void Start()
    {
        await InitializeAsyncSystems();
    }

    private async UniTask InitializeAsyncSystems()
    {
        Debug.Log("Initializing...");
        await UniTask.Delay(500);
        Debug.Log("Initialization complete");
    }

    private void OnDestroy()
    {
        _cts?.Cancel();
        _cts?.Dispose();
    }
}