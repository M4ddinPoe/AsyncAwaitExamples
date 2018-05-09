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
            System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var task = await doWorkAsync();//.ConfigureAwait(false);
            System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);

            doWorkAsync().ConfigureAwait(false);
        }

        private async Task doWorkAsync()
        {
            Task.Delay(1000).Wait();
        }
    }
}
