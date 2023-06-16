namespace DartCounter.Services;

public class NotificationService : IDisposable
{
    public event Action<string>? OnShow;
    public event Action? OnHide;
    private System.Timers.Timer? Countdown;

    public void Show(string message)
    {
        OnShow?.Invoke(message);
        StartCountdown();
    }

    private void StartCountdown()
    {
        SetCountdown();

        if (Countdown!.Enabled)
        {
            Countdown.Stop();
            Countdown.Start();
        }
        else
        {
            Countdown!.Start();
        }
    }

    private void SetCountdown()
    {
        if (Countdown != null) return;

        Countdown = new System.Timers.Timer(3000);
        Countdown.Elapsed += Hide;
        Countdown.AutoReset = false;
    }

    private void Hide(object? source, System.Timers.ElapsedEventArgs args)
        => OnHide?.Invoke();

    public void Dispose()
        => Countdown?.Dispose();
}
