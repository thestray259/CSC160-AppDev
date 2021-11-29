using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberGuessingGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<Label> lblResults = new List<Label>();
        List<PictureBox> picResults = new List<PictureBox>();

        int answer = 0;
        int numGuess = 0;
        int randomMax = 0;

        private void InitializeGame()
        {
            lblResults.Add(label1);
            lblResults.Add(label2);
            lblResults.Add(label3);
            lblResults.Add(label4);
            lblResults.Add(label5);

            picResults.Add(pictureBox1);
            picResults.Add(pictureBox2);
            picResults.Add(pictureBox3);
            picResults.Add(pictureBox4);
            picResults.Add(pictureBox5);
        }

        private void ResetGame()
        {
            foreach (Label label in lblResults)
            {
                label.Text = "";
            }

            foreach (PictureBox pictureBox in picResults)
            {
                pictureBox.Image = null; 
            }

            txtGuess.Enabled = false;
            btnStart.Text = "Start";
            numGuess = 0; 
        }

        private void StartGame()
        {
            Random rand = new Random();
            answer = rand.Next(1, randomMax + 1); 
            txtGuess.Enabled = true;
            btnStart.Text = "Reset";
        }

        private void GameWon()
        {
            txtGuess.Enabled = false; 
        }

        private void GameLost()
        {
            txtGuess.Enabled = false; 
        }

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            ResetGame();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if ((btnStart.Text == "START") || (btnStart.Text == "Start"))
            {
                StartGame();
            }
            else
            {
                ResetGame();
            }
        }

        private void radBtnEasy_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                randomMax = 10; 
            }

        }

        private void radBtnMedium_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                randomMax = 20;
            }
        }

        private void radBtnHard_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                randomMax = 100;
            }
        }

        private void txtGuess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGuess_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string text = txtGuess.Text;
                int result = Int32.Parse(text); 
                if (!int.TryParse(text, out result))
                {
                    // You typed not a number 
                    return;
                }
                else 
                {
                    int.TryParse(text, out result); 
                    if (result == answer)
                    {
                        lblResults[numGuess].Text = text + " correct!";
                        lblResults[numGuess].ForeColor = Color.Green;
                        picResults[numGuess].Image = Properties.Resources.correct_icon;
                        GameWon(); 
                    }
                    else
                    {
                        string highLow; 
                        if (result > answer) highLow = "Too high";
                        else highLow = "Too low";

                        lblResults[numGuess].Text = highLow;
                        lblResults[numGuess].ForeColor = Color.Red;
                        picResults[numGuess].Image = Properties.Resources.incorrect_icon;
                    }
                    numGuess++;
                }
            }

            if (numGuess == 5) GameLost(); 
        }
    }
}
