namespace QuickAPI
{
    partial class GetTokenForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.environmentComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customEnvorinmentCheckBox = new System.Windows.Forms.CheckBox();
            this.environmentTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(83, 332);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Login";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(11, 48);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(255, 22);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(48, 154);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(276, 165);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authorization";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(11, 105);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(255, 22);
            this.textBox3.TabIndex = 6;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // environmentComboBox
            // 
            this.environmentComboBox.DisplayMember = "POST Product";
            this.environmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.environmentComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.environmentComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.environmentComboBox.FormattingEnabled = true;
            this.environmentComboBox.Location = new System.Drawing.Point(19, 38);
            this.environmentComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.environmentComboBox.Name = "environmentComboBox";
            this.environmentComboBox.Size = new System.Drawing.Size(145, 24);
            this.environmentComboBox.Sorted = true;
            this.environmentComboBox.TabIndex = 7;
            this.environmentComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Freestyle environment";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // customEnvorinmentCheckBox
            // 
            this.customEnvorinmentCheckBox.AutoSize = true;
            this.customEnvorinmentCheckBox.Location = new System.Drawing.Point(192, 39);
            this.customEnvorinmentCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customEnvorinmentCheckBox.Name = "customEnvorinmentCheckBox";
            this.customEnvorinmentCheckBox.Size = new System.Drawing.Size(109, 21);
            this.customEnvorinmentCheckBox.TabIndex = 8;
            this.customEnvorinmentCheckBox.Text = "Custom URL";
            this.customEnvorinmentCheckBox.UseVisualStyleBackColor = true;
            this.customEnvorinmentCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // environmentTextBox
            // 
            this.environmentTextBox.Location = new System.Drawing.Point(19, 80);
            this.environmentTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.environmentTextBox.Name = "environmentTextBox";
            this.environmentTextBox.Size = new System.Drawing.Size(316, 22);
            this.environmentTextBox.TabIndex = 9;
            this.environmentTextBox.Text = "https://apiqa03.freestylecommerce.info/V2";
            this.environmentTextBox.Visible = false;
            this.environmentTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.environmentTextBox);
            this.groupBox2.Controls.Add(this.environmentComboBox);
            this.groupBox2.Controls.Add(this.customEnvorinmentCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(349, 124);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Environment";
            // 
            // GetTokenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(373, 379);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetTokenForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Get API Token";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox environmentComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox customEnvorinmentCheckBox;
        private System.Windows.Forms.TextBox environmentTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}