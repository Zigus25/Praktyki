namespace Excel
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
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.Sava = new System.Windows.Forms.Button();
            this.Load = new System.Windows.Forms.Button();
            this.New = new System.Windows.Forms.Button();
            this.Komurka = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.AllowUserToDeleteRows = false;
            this.DataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.GridColor = System.Drawing.SystemColors.ControlText;
            this.DataGrid.Location = new System.Drawing.Point(0, 36);
            this.DataGrid.MinimumSize = new System.Drawing.Size(800, 600);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.RowTemplate.Height = 25;
            this.DataGrid.Size = new System.Drawing.Size(1086, 1002);
            this.DataGrid.TabIndex = 0;
            this.DataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellClick);
            // 
            // Sava
            // 
            this.Sava.Location = new System.Drawing.Point(12, 7);
            this.Sava.Name = "Sava";
            this.Sava.Size = new System.Drawing.Size(75, 23);
            this.Sava.TabIndex = 1;
            this.Sava.Text = "Zapisz";
            this.Sava.UseVisualStyleBackColor = true;
            this.Sava.Click += new System.EventHandler(this.Sava_Click);
            // 
            // Load
            // 
            this.Load.Location = new System.Drawing.Point(93, 7);
            this.Load.Name = "Load";
            this.Load.Size = new System.Drawing.Size(75, 23);
            this.Load.TabIndex = 2;
            this.Load.Text = "Wczytaj";
            this.Load.UseVisualStyleBackColor = true;
            // 
            // New
            // 
            this.New.Location = new System.Drawing.Point(174, 7);
            this.New.Name = "New";
            this.New.Size = new System.Drawing.Size(75, 23);
            this.New.TabIndex = 3;
            this.New.Text = "Nowy";
            this.New.UseVisualStyleBackColor = true;
            this.New.Click += new System.EventHandler(this.New_Click);
            // 
            // Komurka
            // 
            this.Komurka.AutoSize = true;
            this.Komurka.Location = new System.Drawing.Point(1044, 11);
            this.Komurka.Name = "Komurka";
            this.Komurka.Size = new System.Drawing.Size(21, 15);
            this.Komurka.TabIndex = 4;
            this.Komurka.Text = "A1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(980, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Komurka:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 1039);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Komurka);
            this.Controls.Add(this.New);
            this.Controls.Add(this.Load);
            this.Controls.Add(this.Sava);
            this.Controls.Add(this.DataGrid);
            this.MaximumSize = new System.Drawing.Size(1110, 1078);
            this.MinimumSize = new System.Drawing.Size(1110, 1078);
            this.Name = "Form1";
            this.Text = "ExCell";
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Button Sava;
        private System.Windows.Forms.Button Load;
        private System.Windows.Forms.Button New;
        private System.Windows.Forms.Label Komurka;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
