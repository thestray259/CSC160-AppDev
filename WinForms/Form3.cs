using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Form3 : Form
    {
        BindingList<string> lstMovies = new BindingList<string>()
        {
            "Beverly Hills Chihuahua 3", 
            "Air Bud", 
            "Space Jam"
        };

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Button btnGoodbye = new Button();
            btnGoodbye.Location = new Point(100, 100);
            btnGoodbye.Text = "Goodbye";
            btnGoodbye.Size = new Size(200, 100);
            Controls.Add(btnGoodbye);
            //btnGoodbye.Click += btnGoodbye_Click; 
            btnGoodbye.Click += new System.EventHandler(this.btnGoodbye_Click);

            lbMovies.DataSource = lstMovies;
            cbo.DataSource = lstMovies;
        }

        private void btnHello_Click(object sender, EventArgs e)
        {

        }

        private void btnGoodbye_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Size = new Size(btn.Size.Width + 100, btn.Size.Height + 100);
            lblInfo.Text = btn.Text;

            lbMovies.Items.Add("Cloudy With A Chance Of Meatballs");
            lbMovies.Items.Add("Spaceballs");

        }
    }
}
