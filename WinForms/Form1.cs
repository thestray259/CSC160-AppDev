using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class InitialForm : Form
    {
        public InitialForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button Clicked"); 
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("Text Entered");
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
        }

        private void btnGoToForm2_Click(object sender, EventArgs e)
        {
            Containers2 form2 = new Containers2();
            form2.Show();
            this.Hide();
            //this.Close(); 
            Application.Exit(); 
        }
    }
}
