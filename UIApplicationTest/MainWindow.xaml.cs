using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ThreadReentranceProblem;

namespace UIApplicationTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Cache<int> cachedInt;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            cachedInt = new Cache<int>(
                async () =>
                {
                    //simulate some work
                    await Task.Delay(2000);
                    return 1;
                });
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(await cachedInt.Value);
            Console.WriteLine(await cachedInt.Value);
            Console.WriteLine(await cachedInt.Value);
        }
    }
}
