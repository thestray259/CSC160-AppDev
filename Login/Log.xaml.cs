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
using System.Data; 
using System.Data.SqlClient; 

namespace Login
{
    /// <summary>
    /// Interaction logic for Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        public Log()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //DataTable dataTable = new DataTable();
            string username = tbUserNameLogin.Text.ToString();
            string password = tbPasswordLogin.Text.ToString(); 

            // if either textbox is empty, throw pop up that says invalid, both boxes have to be filled 
            if (tbUserNameLogin.Text == "" || tbPasswordLogin.Text == "") MessageBox.Show("One or more fields are empty. Please try again."); 

            // if the username is not in the database, pop up saying that username is invalid 
            // then if password is not in database, pop up saying that the password is invalid 

            // else (being that username and password exist) 
                // if username and password do not have the same ID, give pop up saying wrong username or password 
                // and if it is correct, then give pop up saying welcome [User's Name] and go back to main window 
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
