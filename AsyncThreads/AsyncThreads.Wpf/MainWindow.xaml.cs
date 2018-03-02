namespace AsyncThreads.Wpf
{
  using System;
  using System.Threading.Tasks;
  using System.Windows;

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
      this.WriteLine($"Starting on: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
      await this.WaitAsync();
      this.WriteLine($"Return to main on: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
      this.WriteLine($"{Environment.NewLine}");
    }

    private async Task WaitAsync()
    {
      this.WriteLine($"Entering WaitAsync on: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
      await Task.Run(() => this.Wait());
      this.WriteLine($"Leaving WaitAsync on: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
    }

    private void Wait()
    {
      this.WriteLine($"Entering Wait on: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
      System.Threading.Thread.Sleep(5000);
      //await System.Threading.Tasks.Task.Delay(2000).ConfigureAwait(true);
      this.WriteLine($"Leaving Wait on: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
    }

    private void WriteLine(string line)
    {
      this.Dispatcher.Invoke(() => this.Console.Text += $"{line}{Environment.NewLine}");
    }
  }
}
