namespace WpfApplication1
{
    using System.Threading.Tasks;
    using System.Windows;
    using System.Threading;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            doWorkAsync().Wait();

            //System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            //await doWorkAsync().ConfigureAwait(false);
            //System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        private async Task doWorkAsync()
        {
            await Task.Delay(1000);
        }
    }
}
