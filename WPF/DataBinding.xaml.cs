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
    /// Interaction logic for DataBinding.xaml
    /// </summary>
    public partial class DataBinding : Window
    {
        List<Student> lstStudents = new List<Student>(); 
        public DataBinding()
        {
            InitializeComponent();
            DataContext = this;

            Binding b = new Binding("Text");
            b.Source = txtValue;
            txtData.SetBinding(TextBlock.TextProperty, b);

            lstStudents.Add(new Student() { intID = 1, strName = "Rob1"});
            lstStudents.Add(new Student() { intID = 2, strName = "Bob1"});
            lstStudents.Add(new Student() { intID = 3, strName = "Wob1"});
            lbStudents.ItemsSource = lstStudents; 
        }

        private void btnUpdateSource_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression be = txtTitle.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource(); 
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int newId = lstStudents[lstStudents.Count - 1].intID + 1;
            lstStudents.Add(new Student() { intID = newId, strName = "Hob" + newId }); 
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbStudents.SelectedItem != null)
            {
                lstStudents.Remove((Student)lbStudents.SelectedItem); 
            }
        }
    }

    class Student 
    {
        public int intID;
        public string strName; 
    }
}
