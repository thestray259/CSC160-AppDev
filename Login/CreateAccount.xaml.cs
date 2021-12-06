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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Collections;

namespace Login
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        MainWindow mw = new MainWindow();

        private DataTableAdapters.UsersTableAdapter userTable = new DataTableAdapters.UsersTableAdapter(); 
        private Data data = new Data(); 

        public CreateAccount()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == "" || tbUsername.Text == "" || tbPassword.Text == "" || tbEmail.Text == "")
            {
                // pop up saying that one or more fields are empty 
                MessageBox.Show("One or more fields are empty. Please try again.");
            }
            // else if name contains numbers, messagebox saying name cannot include numbers 
            else if (tbName.Text.Contains((char)48) || tbName.Text.Contains((char)49) || tbName.Text.Contains((char)50) || tbName.Text.Contains((char)51) || tbName.Text.Contains((char)52) || tbName.Text.Contains((char)53) || tbName.Text.Contains((char)54) || tbName.Text.Contains((char)55) || tbName.Text.Contains((char)56) || tbName.Text.Contains((char)57))
            {
                MessageBox.Show("Name cannot contain numbers. Please try again.");
            }

            // else if (<if email is the same as one already entered>)
            // {
            //      pop up saying cannot create account due to a duplicate username or email 
            //      MessageBox.Show("Cannot create account due to that email already being in use.");
            // }
            else
            {
                Data.UsersRow row = (Data.UsersRow)data.Users.NewRow(); 

                string name = tbName.Text.ToString();
                string username = tbUsername.Text.ToString();
                string password = tbPassword.Text.ToString();
                string email = tbEmail.Text.ToString();

                /*                if (row.Name.Count() > 0) //<if username is the same as one already entered>  // doesn't quite work
                                {
                                    //pop up saying cannot create account due to a duplicate username or email 
                                    MessageBox.Show("Cannot create account due to that username already being in use.");
                                }*/

                // take the things entered in textboxes and move them to database 
                row.Name = name;
                row.Username = username;
                row.Password = password;
                row.Email = email;

                data.Users.AddUsersRow(row);
                userTable.Update(data); 

                // show account created and then go back to main window 
                MessageBox.Show("Account Created Successfully"); 
                MessageBox.Show("Name " + row.Name + " was added, Username " + row.Username + " was added, Password " + row.Password + " was added, Email " + row.Email + " was added."); 

                mw.Show();
                this.Close();
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            mw.Show();
            this.Hide(); 
        }
    }
}
