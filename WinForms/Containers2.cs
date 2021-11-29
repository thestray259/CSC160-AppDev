using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Containers2 : Form
    {
        public Containers2()
        {
            InitializeComponent();
        }

        private void Containers2_Load(object sender, EventArgs e)
        {
            if (panel1.Contains(checkBox1))
            {
                MessageBox.Show("inside"); 
            }
        }
    }
}
