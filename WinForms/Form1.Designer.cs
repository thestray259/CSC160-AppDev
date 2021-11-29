
namespace WinForms
{
    partial class InitialForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTop = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txt = new System.Windows.Forms.TextBox();
            this.btnGoToForm2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(327, 90);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(110, 20);
            this.lblTop.TabIndex = 0;
            this.lblTop.Text = "This is my label";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(339, 194);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 29);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(296, 136);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(162, 27);
            this.txt.TabIndex = 2;
            this.txt.Enter += new System.EventHandler(this.txt_Enter);
            this.txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btnGoToForm2
            // 
            this.btnGoToForm2.Location = new System.Drawing.Point(327, 297);
            this.btnGoToForm2.Name = "btnGoToForm2";
            this.btnGoToForm2.Size = new System.Drawing.Size(94, 29);
            this.btnGoToForm2.TabIndex = 3;
            this.btnGoToForm2.Text = "Form 2";
            this.btnGoToForm2.UseVisualStyleBackColor = true;
            this.btnGoToForm2.Click += new System.EventHandler(this.btnGoToForm2_Click);
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGoToForm2);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblTop);
            this.Name = "InitialForm";
            this.Text = "Initial Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Button btnGoToForm2;
    }
}

