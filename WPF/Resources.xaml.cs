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

namespace WPF
{
    /// <summary>
    /// Interaction logic for Resources.xaml
    /// </summary>
    public partial class Resources : Window
    {
        public Resources()
        {
            InitializeComponent();

            btnResourceStatic.Content = FindResource("CompanyName");

            btnResourceStatic.Content = Properties.Settings.Default.String1; 

            Resources["AppString"] = "App String In Code";
            btnResourceStatic.Content = FindResource("AppString");

            // can create brand new Dtnamic resource on the fly, no declaration 
            Resources["Boogers"] = "boogers";
            btnResourceDynamic.Content = FindResource("Boogers"); 
        }

        private void btnChangeColor_Click(object sender, RoutedEventArgs e)
        {
            Resources["CompanyColor"] = new SolidColorBrush(Colors.Blue);
            // only dynamic will cange by changing resource lke binding 

            // static will change if you explicitly update the .Content of the button 
            Resources["CompanyName"] = "New Company";
            btnResourceStatic.Content = FindResource("CompanyName"); 
        }
    }
}
