namespace QuickAPI
{
    partial class QuickAPIMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.entityTypeComboBox = new System.Windows.Forms.ComboBox();
            this.requestTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.eventLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.environmentLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.entityTypeComboBox);
            this.groupBox1.Controls.Add(this.requestTypeComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request options";
            // 
            // entityTypeComboBox
            // 
            this.entityTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entityTypeComboBox.FormattingEnabled = true;
            this.entityTypeComboBox.Location = new System.Drawing.Point(154, 48);
            this.entityTypeComboBox.Name = "entityTypeComboBox";
            this.entityTypeComboBox.Size = new System.Drawing.Size(166, 24);
            this.entityTypeComboBox.TabIndex = 3;
            this.entityTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.entityTypeComboBox_SelectedIndexChanged);
            // 
            // requestTypeComboBox
            // 
            this.requestTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.requestTypeComboBox.FormattingEnabled = true;
            this.requestTypeComboBox.Location = new System.Drawing.Point(9, 48);
            this.requestTypeComboBox.Name = "requestTypeComboBox";
            this.requestTypeComboBox.Size = new System.Drawing.Size(105, 24);
            this.requestTypeComboBox.TabIndex = 2;
            this.requestTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.requestTypeComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Entity Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Request Type";
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.sendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sendButton.FlatAppearance.BorderSize = 0;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.ForeColor = System.Drawing.Color.White;
            this.sendButton.Location = new System.Drawing.Point(92, 235);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(208, 35);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Selected action:";
            // 
            // eventLabel
            // 
            this.eventLabel.AutoSize = true;
            this.eventLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.eventLabel.Location = new System.Drawing.Point(121, 60);
            this.eventLabel.Name = "eventLabel";
            this.eventLabel.Size = new System.Drawing.Size(46, 17);
            this.eventLabel.TabIndex = 5;
            this.eventLabel.Text = "action";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Selected environment: ";
            // 
            // environmentLabel
            // 
            this.environmentLabel.AutoSize = true;
            this.environmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.environmentLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.environmentLabel.Location = new System.Drawing.Point(165, 28);
            this.environmentLabel.Name = "environmentLabel";
            this.environmentLabel.Size = new System.Drawing.Size(76, 17);
            this.environmentLabel.TabIndex = 7;
            this.environmentLabel.Text = "Production";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(251, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "Сhange";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.environmentLabel);
            this.groupBox2.Controls.Add(this.eventLabel);
            this.groupBox2.Location = new System.Drawing.Point(22, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            // 
            // QuickAPIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(379, 285);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuickAPIMain";
            this.Text = "QuickAPIMain";
            this.Load += new System.EventHandler(this.QuickAPIMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox entityTypeComboBox;
        private System.Windows.Forms.ComboBox requestTypeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label eventLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label environmentLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}