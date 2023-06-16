using Microsoft.JSInterop;

namespace DartCounter.JsInterop;
public class WakeLockInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public WakeLockInterop(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./js/wake-lock.js").AsTask());
    }

    public async ValueTask Init()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("wakeLockInit");
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
