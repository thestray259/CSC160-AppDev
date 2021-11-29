
namespace WinForms
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHello = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lbMovies = new System.Windows.Forms.ListBox();
            this.cbo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnHello
            // 
            this.btnHello.Location = new System.Drawing.Point(332, 139);
            this.btnHello.Name = "btnHello";
            this.btnHello.Size = new System.Drawing.Size(94, 29);
            this.btnHello.TabIndex = 0;
            this.btnHello.Text = "Hello";
            this.btnHello.UseVisualStyleBackColor = true;
            this.btnHello.Click += new System.EventHandler(this.btnHello_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(361, 221);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 20);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Info";
            // 
            // lbMovies
            // 
            this.lbMovies.FormattingEnabled = true;
            this.lbMovies.ItemHeight = 20;
            this.lbMovies.Items.AddRange(new object[] {
            "The Empire Strikes Back ",
            "The Matrix ",
            "The Princess Bride"});
            this.lbMovies.Location = new System.Drawing.Point(494, 139);
            this.lbMovies.Name = "lbMovies";
            this.lbMovies.Size = new System.Drawing.Size(180, 84);
            this.lbMovies.TabIndex = 2;
            // 
            // cbo
            // 
            this.cbo.FormattingEnabled = true;
            this.cbo.Location = new System.Drawing.Point(494, 243);
            this.cbo.Name = "cbo";
            this.cbo.Size = new System.Drawing.Size(180, 28);
            this.cbo.TabIndex = 3;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbo);
            this.Controls.Add(this.lbMovies);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnHello);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHello;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ListBox lbMovies;
        private System.Windows.Forms.ComboBox cbo;
    }
}