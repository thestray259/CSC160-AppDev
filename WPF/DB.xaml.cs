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

namespace WPF
{
    /// <summary>
    /// Interaction logic for DB.xaml
    /// </summary>
    public partial class DB : Window
    {
        private NamesTableAdapters.tblNamesTableAdapter adNames = new NamesTableAdapters.tblNamesTableAdapter(); // Names.xsd
        private Names dsNames = new Names(); 

        public DB()
        {
            InitializeComponent();
        }

        private void btnDoIt_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt;
            Hashtable ht = new Hashtable();
            string sql;

            /*ht.Add("@Name", "Louis");
            ht.Add("@Age", 41);
            ht.Add("@ID", 8); 
            //sql = "Insert into tblNames (Name, Age) Values (@Name, @Age)";
            //sql = "Update tblNames set Name=@Name, Age=@Age where ID=7"; 
            //sql = "Delete from tblNames where ID=@ID"; 
            //ExecuteIt("AppDev", sql, ht); 

            sql = "Select * from tblNames ";
            //ht.Add("@ID", 3);
            dt = GetDataTable("AppDev", ht, sql);
            dg.ItemsSource = dt.DefaultView;
            dg.AutoGenerateColumns = true;

            DataRow dr;
            dr = dt.Rows[0];
            //int intID;
            //intID = (int)dr["ID"];
            string s;
            s = (string)dr["Name"]; 
            //MessageBox.Show(intID.ToString()); 
            MessageBox.Show(s);*/

            // how to open a new window 
            /*            Panels window = new Panels();
                        window.Show();
                        this.Close(); */

            Names.tblNamesRow row = (Names.tblNamesRow)dsNames.tblNames.NewRow();

            row.Name = "Randall";
            row.Age = 75;

            dsNames.tblNames.AddtblNamesRow(row);
            adNames.Update(dsNames);

            MessageBox.Show("Name " + row.Name + " was added", "Added", MessageBoxButton.OK, MessageBoxImage.Information);

            MessageBox.Show(dsNames.tblNames.Rows.Count.ToString()); // shows how many in database 

/*            var s = (from NamesTable in dsNames.tblNames
                     where NamesTable.ID==3
                     select NamesTable.Name);*/

            //if (dsNames.tblNames.Rows.Count > 0)
            //MessageBox.Show(s.First()); 

        }

        public bool OpenDBCommand(string strDB, ref SqlConnection dbConn, ref SqlCommand sqlcmd)
        {
            if (sqlcmd.Connection.State != ConnectionState.Open)
            {
                //dbConn.ConnectionString = "data source=(local);initial catalog=" + strDB + ";Trusted_Connection=True";
                dbConn.ConnectionString = "data source=(local);user id=admin;pwd=appdev;initial catalog=" + strDB;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adNames.Fill(dsNames.tblNames);
            DataContext = dsNames.tblNames; 
        }
    }
}
