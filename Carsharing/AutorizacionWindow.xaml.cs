using Carsharing.ViewModel;
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
using System.Windows.Shapes;

namespace Carsharing
{
    /// <summary>
    /// Логика взаимодействия для AutorizacionWindow.xaml
    /// </summary>
    public partial class AutorizacionWindow : Window
    {
        public AutorizacionWindow()
        {
            InitializeComponent();
        }
        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Hide();

        }
    }
}
