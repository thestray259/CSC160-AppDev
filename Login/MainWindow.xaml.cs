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

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_ClickCreateAccount(object sender, RoutedEventArgs e)
        {
            CreateAccount ca = new CreateAccount();
            ca.Show();
            this.Close(); 
        }

        private void Button_ClickLogin(object sender, RoutedEventArgs e)
        {
            Log login = new Log();
            login.Show();
            this.Close(); 
        }
    }
}
