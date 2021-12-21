namespace Komunikator
{
    partial class Form1
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
            this.Messages = new System.Windows.Forms.ListBox();
            this.TIP = new System.Windows.Forms.TextBox();
            this.ZIP = new System.Windows.Forms.TextBox();
            this.text = new System.Windows.Forms.TextBox();
            this.TPO = new System.Windows.Forms.NumericUpDown();
            this.ZPO = new System.Windows.Forms.NumericUpDown();
            this.wyslij = new System.Windows.Forms.Button();
            this.Polaczenie = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZPO)).BeginInit();
            this.SuspendLayout();
            // 
            // Messages
            // 
            this.Messages.FormattingEnabled = true;
            this.Messages.ItemHeight = 15;
            this.Messages.Location = new System.Drawing.Point(12, 75);
            this.Messages.Name = "Messages";
            this.Messages.Size = new System.Drawing.Size(776, 289);
            this.Messages.TabIndex = 0;
            // 
            // TIP
            // 
            this.TIP.Location = new System.Drawing.Point(99, 12);
            this.TIP.Name = "TIP";
            this.TIP.Size = new System.Drawing.Size(100, 23);
            this.TIP.TabIndex = 1;
            // 
            // ZIP
            // 
            this.ZIP.Location = new System.Drawing.Point(99, 46);
            this.ZIP.Name = "ZIP";
            this.ZIP.Size = new System.Drawing.Size(100, 23);
            this.ZIP.TabIndex = 2;
            // 
            // text
            // 
            this.text.Location = new System.Drawing.Point(12, 402);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(467, 23);
            this.text.TabIndex = 3;
            // 
            // TPO
            // 
            this.TPO.Location = new System.Drawing.Point(251, 12);
            this.TPO.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.TPO.Name = "TPO";
            this.TPO.Size = new System.Drawing.Size(44, 23);
            this.TPO.TabIndex = 4;
            this.TPO.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // ZPO
            // 
            this.ZPO.Location = new System.Drawing.Point(251, 46);
            this.ZPO.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ZPO.Name = "ZPO";
            this.ZPO.Size = new System.Drawing.Size(44, 23);
            this.ZPO.TabIndex = 5;
            this.ZPO.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // wyslij
            // 
            this.wyslij.Location = new System.Drawing.Point(713, 402);
            this.wyslij.Name = "wyslij";
            this.wyslij.Size = new System.Drawing.Size(75, 23);
            this.wyslij.TabIndex = 6;
            this.wyslij.Text = "Wyślij";
            this.wyslij.UseVisualStyleBackColor = true;
            this.wyslij.Click += new System.EventHandler(this.wyslij_Click);
            // 
            // Polaczenie
            // 
            this.Polaczenie.Location = new System.Drawing.Point(335, 27);
            this.Polaczenie.Name = "Polaczenie";
            this.Polaczenie.Size = new System.Drawing.Size(144, 23);
            this.Polaczenie.TabIndex = 7;
            this.Polaczenie.Text = "Nawiąż połączenie";
            this.Polaczenie.UseVisualStyleBackColor = true;
            this.Polaczenie.Click += new System.EventHandler(this.Polaczenie_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Twoje IP :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "IP Znajomego :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Port :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Port :";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(632, 402);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Dołącz plik";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Polaczenie);
            this.Controls.Add(this.wyslij);
            this.Controls.Add(this.ZPO);
            this.Controls.Add(this.TPO);
            this.Controls.Add(this.text);
            this.Controls.Add(this.ZIP);
            this.Controls.Add(this.TIP);
            this.Controls.Add(this.Messages);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZPO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox Messages;
        private System.Windows.Forms.TextBox TIP;
        private System.Windows.Forms.TextBox ZIP;
        private System.Windows.Forms.TextBox text;
        private System.Windows.Forms.NumericUpDown TPO;
        private System.Windows.Forms.NumericUpDown ZPO;
        private System.Windows.Forms.Button wyslij;
        private System.Windows.Forms.Button Polaczenie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
    }
}
