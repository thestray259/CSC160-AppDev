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

namespace BasicCharacterBuilder
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

        private void btnCreateCharacter_Click(object sender, RoutedEventArgs e)
        {
            CreateCharacter createCharacter = new CreateCharacter();
            createCharacter.Show();
            this.Close(); 
        }

        private void btnViewCharacter_Click(object sender, RoutedEventArgs e)
        {
            ViewCharacter viewCharacter = new ViewCharacter();
            viewCharacter.Show();
            this.Close(); 
        }
    }
}
