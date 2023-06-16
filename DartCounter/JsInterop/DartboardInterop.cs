using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace DartCounter.JsInterop;
public class DartboardInterop : IAsyncDisposable
{
	private readonly Lazy<Task<IJSObjectReference>> moduleTask;

	public DartboardInterop(IJSRuntime jsRuntime)
	{
		moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
			"import", "./js/dartboard.js").AsTask());
	}

	public async ValueTask<string?> Click(double x, double y)
	{
		var module = await moduleTask.Value;
		return await module.InvokeAsync<string?>("dartboardClick", x, y);
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
