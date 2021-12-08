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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Collections;

namespace BasicCharacterBuilder
{
    /// <summary>
    /// Interaction logic for ViewCharacter.xaml
    /// </summary>
    public partial class ViewCharacter : Window
    {
        MainWindow mw = new MainWindow();

        private CharactersTableAdapters.tblCharacterTableAdapter charTable = new CharactersTableAdapters.tblCharacterTableAdapter();
        private Characters chars = new Characters();

        private DataTable dt;
        private Hashtable ht = new Hashtable();
        private string sql;

        public ViewCharacter()
        {
            InitializeComponent();
        }

        private void btnMale_Click(object sender, RoutedEventArgs e)
        {
            sql = "Select * from tblCharacter Where Gender='Male'"; 
            dt = GetDataTable("AppDev", ht, sql);
            dg.ItemsSource = dt.DefaultView;
            dg.AutoGenerateColumns = true;
        }

        private void btnFemale_Click(object sender, RoutedEventArgs e)
        {
            sql = "Select * from tblCharacter Where Gender='Female'";
            dt = GetDataTable("AppDev", ht, sql);
            dg.ItemsSource = dt.DefaultView;
            dg.AutoGenerateColumns = true;
        }

        private void btnOther_Click(object sender, RoutedEventArgs e)
        {
            sql = "Select * from tblCharacter Where Gender='Other'";
            dt = GetDataTable("AppDev", ht, sql);
            dg.ItemsSource = dt.DefaultView;
            dg.AutoGenerateColumns = true;
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            sql = "Select * from tblCharacter";
            dt = GetDataTable("AppDev", ht, sql);
            dg.ItemsSource = dt.DefaultView;
            dg.AutoGenerateColumns = true;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            mw.Show();
            this.Close();
        }

        // Database stuff
        public bool OpenDBCommand(string strDB, ref SqlConnection dbConn, ref SqlCommand sqlcmd)
        {
            if (sqlcmd.Connection.State != ConnectionState.Open)
            {
                dbConn.ConnectionString = "data source=(local);initial catalog=" + strDB + ";Trusted_Connection=True";
                //dbConn.ConnectionString = "data source=(local);user id=admin;pwd=appdev;initial catalog=" + strDB;
                //sqlcmd.CommandTimeout = 50;
                sqlcmd.Connection.Open();
                return true;
            }
            else return false;
        }

        public DataTable GetDataTable(string strDB, Hashtable htParameters, string SQL)
        {
            SqlConnection dbConn = new SqlConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter myAdap;
            SqlCommand sqlCmd;

            sqlCmd = new SqlCommand(SQL, dbConn);

            foreach (DictionaryEntry hti in htParameters)
            {
                AddParam(ref sqlCmd, hti.Key.ToString(), hti.Value);
            }

            OpenDBCommand(strDB, ref dbConn, ref sqlCmd);
            myAdap = new SqlDataAdapter(sqlCmd);

            myAdap.Fill(dt);
            sqlCmd.Connection.Close();
            dbConn.Close();

            return dt;
        }

        public long ExecuteIt(string strdb, string strSQL, Hashtable htParameters)
        {
            SqlConnection dbconn = new SqlConnection();
            SqlCommand sqlCmd;
            long x;

            sqlCmd = new SqlCommand(strSQL, dbconn);
            OpenDBCommand(strdb, ref dbconn, ref sqlCmd);

            foreach (DictionaryEntry hti in htParameters)
                AddParam(ref sqlCmd, hti.Key.ToString(), hti.Value);

            x = sqlCmd.ExecuteNonQuery();
            sqlCmd.Connection.Close();
            dbconn.Close();

            return x;
        }

        public void AddParam(ref SqlCommand sqlCmd, string key, object value)
        {
            //key = Strings.Replace(key, " ", "_"); // parameters can't have spaces

            if (value == null)
                sqlCmd.Parameters.AddWithValue(key, System.DBNull.Value);
            else
                sqlCmd.Parameters.AddWithValue(key, value);
        }
    }
}
