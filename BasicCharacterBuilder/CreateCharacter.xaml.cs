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

namespace BasicCharacterBuilder
{
    /// <summary>
    /// Interaction logic for CreateCharacter.xaml
    /// </summary>
    public partial class CreateCharacter : Window
    {


        string[] names = new string[] { "Finnley", "Morgan", "Jessie", "Skylar", "Frankie", "Quinn", "Adrian", "Parker", "Arrow", 
                                          "Arden", "Valen", "Ziv", "Xen", "Vesper", "Sparrow", "Roux", "Reef", "Owen", "Orion", 
                                          "Sloan", "River", "Haven", "Ellis", "Ari", "Oakley", "Arlo", "Aspen", "Grey", "Delta", 
                                          "Celyn", "Yoltzin", "Ray" };
        public CreateCharacter()
        {
            InitializeComponent();
        }

        void Randomize()
        {
            
        }

        // Male
        private void btnRandomizeM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateM_Click(object sender, RoutedEventArgs e)
        {
            if (cmName.Text == "") MessageBox.Show("Name cannot be empty. Please try again. ");
            else if (cmName.Text.Contains((char)48) || cmName.Text.Contains((char)49) || cmName.Text.Contains((char)50) || cmName.Text.Contains((char)51) || cmName.Text.Contains((char)52) || cmName.Text.Contains((char)53) || cmName.Text.Contains((char)54) || cmName.Text.Contains((char)55) || cmName.Text.Contains((char)56) || cmName.Text.Contains((char)57)) MessageBox.Show("Name cannot contain numbers. Please try again.");
            else if (cmAge.Text != "" && (!cmAge.Text.Contains((char)48) || !cmAge.Text.Contains((char)49) || !cmAge.Text.Contains((char)50) || !cmAge.Text.Contains((char)51) || !cmAge.Text.Contains((char)52) || !cmAge.Text.Contains((char)53) || !cmAge.Text.Contains((char)54) || !cmAge.Text.Contains((char)55) || !cmAge.Text.Contains((char)56) || !cmAge.Text.Contains((char)57))) MessageBox.Show("Age must be a number"); 
            else
            {
                // enter information into database 
            }

        }

        // Female
        private void btnRandomizeF_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateF_Click(object sender, RoutedEventArgs e)
        {

        }

        // Other
        private void btnRandomizeO_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateO_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
