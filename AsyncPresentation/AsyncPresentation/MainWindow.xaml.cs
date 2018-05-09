using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncPresentation
{
    using AsyncPresentation.Code;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MySimpleAsync mySimpleAsync = new MySimpleAsync();

        private MySimpleAsyncDecompiled mySimpleAsyncDecompiled = new MySimpleAsyncDecompiled();

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private async void ButtonClick(object sender, RoutedEventArgs e)
        {
            //var result = await this.mySimpleAsync.DoSomethingAsync(1);
            var result = await this.mySimpleAsyncDecompiled.DoSomethingAsync(1);

            this.Log.Text = result + Environment.NewLine;
        }
    }
}
