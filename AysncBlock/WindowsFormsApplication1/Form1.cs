namespace WindowsFormsApplication1
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);

            //doWorkAsync().Wait();
            await doWorkAsync();//.ConfigureAwait(false);

            System.Diagnostics.Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        private async Task doWorkAsync()
        {
            //await Task.Delay(1000).ConfigureAwait(false);
            await Task.Delay(1000); // blocking!!!!
        }
    }
}
