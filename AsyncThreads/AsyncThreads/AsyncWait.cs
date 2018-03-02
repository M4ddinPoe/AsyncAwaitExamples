namespace AsyncThreads
{
  using System;
  using System.Threading.Tasks;

  internal class AsyncWait
  {
    public async Task Main()
    {
      Console.WriteLine($"Starting on: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
      await WaitAsync();
      Console.WriteLine($"Return to main on: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
    }

    private async Task WaitAsync()
    {
      Console.WriteLine($"Entering WaitAsync on: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
      await System.Threading.Tasks.Task.Run(() => Wait());
      Console.WriteLine($"Leaving WaitAsync on: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
    }

    private void Wait()
    {
      Console.WriteLine($"Entering Wait on: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
      System.Threading.Thread.Sleep(5000);
      //await System.Threading.Tasks.Task.Delay(2000).ConfigureAwait(true);
      Console.WriteLine($"Leaving Wait on: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
    }
  }
}
