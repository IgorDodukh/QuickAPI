using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickAPI
{
    public partial class QuickAPIMain : Form
    {
        private static GetTokenForm getTokenForm = new GetTokenForm();
        public QuickAPIMain()
        {
            InitializeComponent();
            this.FormClosing += QuickAPIMain_FormClosing;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            TokenReceiver.requestTypeIndex = requestTypeComboBox.SelectedIndex;
            TokenReceiver.entityTypeIndex = entityTypeComboBox.SelectedIndex;
            /*
            string login = null;
            string password = null;
            TokenReceiver.CreateObject(login, password);*/

            TokenReceiver.SendJson();

        }

        private void QuickAPIMain_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> entityTypes = new Dictionary<string, string>();
            entityTypes.Add("Product", "Products");
            entityTypes.Add("Warehouse", "Warehouses");
            entityTypes.Add("Customer", "Customers");

            entityTypeComboBox.DataSource = new BindingSource(entityTypes, null);
            entityTypeComboBox.DisplayMember = "Key";
            entityTypeComboBox.ValueMember = "Value";
            entityTypeComboBox.SelectedIndex = 0;

            Dictionary<string, string> requestTypes = new Dictionary<string, string>();
//            requestTypes.Add("GET", "View");
            requestTypes.Add("POST", "Create");
            requestTypes.Add("PUT", "Update");
            requestTypes.Add("DELETE", "Remove");

            requestTypeComboBox.DataSource = new BindingSource(requestTypes, null);
            requestTypeComboBox.DisplayMember = "Key";
            requestTypeComboBox.ValueMember = "Value";
            requestTypeComboBox.SelectedIndex = 0;

            string requestValue = ((KeyValuePair<string, string>)requestTypeComboBox.SelectedItem).Value;
            string entityValue = ((KeyValuePair<string, string>)entityTypeComboBox.SelectedItem).Key;

            eventLabel.Text = requestValue + " " + entityValue;

            environmentLabel.Text = GetTokenForm.selectedEnvironmentKey;
        }

        private void QuickAPIMain_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public static DialogResult InputBox(string title, string promptText, string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox1 = new TextBox();

            textBox1.Width = 50;
            Button buttonSave = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox1.Text = value;

            buttonSave.Text = "Save";
            buttonCancel.Text = "Cancel";
            buttonSave.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox1.SetBounds(12, 36, 372, 20);
            buttonSave.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox1, buttonSave, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonSave;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox1.Text;
            Console.Out.WriteLine("Dialog results: " + value);
            return dialogResult;
        }
/*
        public static string DialogCombo(string text, DataTable comboSource, string DisplyMember, string ValueMember)
        {
            //comboSource = new DataTable();

            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 200;
            Label textLabel = new Label() { Left = 350, Top = 20, Text = text };
            TextBox textBox = new TextBox { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Confirm", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ShowDialog();

            return textBox.Text;
        }
        */
        private void entityTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(eventLabel.Text.Contains(" "))
            {
                string entityValue = ((KeyValuePair<string, string>)entityTypeComboBox.SelectedItem).Key;
                string value = eventLabel.Text;
                value = value.Remove(value.IndexOf(" "), value.Length - value.IndexOf(" "));
                eventLabel.Text = value + " " + entityValue;
            }
        }

        private void requestTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eventLabel.Text.Contains(" "))
            {
                string requestValue = ((KeyValuePair<string, string>)requestTypeComboBox.SelectedItem).Value;
                string value = eventLabel.Text;
                value = value.Remove(0, value.IndexOf(" ")+1);
                eventLabel.Text = requestValue + " " + value;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            getTokenForm.Show();
            TokenReceiver.ApiToken = null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void defaultNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogCombo("text", new DataTable(), "DisplyMember", "ValueMember");
            InputBox("Custom Names", "promptText", "value");
        }
    }
}
