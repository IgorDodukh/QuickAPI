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

        public static string productSKUValue;
        public static string productNameValue;
        public static string firstNameValue;
        public static string lastNameValue;
        public static string warehouseNameValue;

        public static string newProductSKUValue;
        public static string newProductNameValue;
        public static string newFirstNameValue;
        public static string newLastNameValue;
        public static string newWarehouseNameValue;


        public QuickAPIMain()
        {
            InitializeComponent();
            this.FormClosing += QuickAPIMain_FormClosing;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            ParametersReader.fileReader();
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
            ParametersReader.fileReader();

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

        public static DialogResult DefaultNamesInputBox()
        {
            ParametersReader.fileReader();

            Form form = new Form();
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            Label label4 = new Label();
            Label label5 = new Label();

            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            TextBox textBox3 = new TextBox();
            TextBox textBox4 = new TextBox();
            TextBox textBox5 = new TextBox();

            Button buttonSave = new Button();
            Button buttonCancel = new Button();

            form.Text = "Custom Default Names";
            label1.Text = "Product SKU";
            label2.Text = "Product Name";
            label3.Text = "Customer First Name";
            label4.Text = "Customer Last Name";
            label5.Text = "Warehouse Name";

            textBox1.Text = productSKUValue;
            textBox2.Text = productNameValue;
            textBox3.Text = firstNameValue;
            textBox4.Text = lastNameValue;
            textBox5.Text = warehouseNameValue;

            buttonSave.Text = "Save";
            buttonCancel.Text = "Cancel";
            buttonSave.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label1.SetBounds(10, 10, 100, 22);
            textBox1.SetBounds(110, 8, 250, 22);

            label2.SetBounds(10, 40, 100, 22);
            textBox2.SetBounds(110, 38, 250, 22);

            label3.SetBounds(10, 70, 100, 22);
            textBox3.SetBounds(110, 68, 250, 22);

            label4.SetBounds(10, 100, 100, 22);
            textBox4.SetBounds(110, 98, 250, 22);

            label5.SetBounds(10, 130, 100, 22);
            textBox5.SetBounds(110, 128, 250, 22);

            buttonSave.SetBounds(180, 160, 75, 23);
            buttonCancel.SetBounds(260, 160, 75, 23);

            textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;
            textBox2.Anchor = textBox2.Anchor | AnchorStyles.Right;
            textBox3.Anchor = textBox3.Anchor | AnchorStyles.Right;
            textBox4.Anchor = textBox4.Anchor | AnchorStyles.Right;
            textBox5.Anchor = textBox5.Anchor | AnchorStyles.Right;

            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(370, 200);
            form.Controls.AddRange(new Control[] { label1, label2, label3, label4, label5, textBox1, textBox2, textBox3, textBox4, textBox5, buttonSave, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label1.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonSave;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                newProductSKUValue = textBox1.Text;
                newProductNameValue = textBox2.Text;
                newFirstNameValue = textBox3.Text;
                newLastNameValue = textBox4.Text;
                newWarehouseNameValue = textBox5.Text;
                ParametersReader.fileWriter();
            }
            else Console.Out.WriteLine("Dialog cancelled");

            return dialogResult;

        }



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
            DefaultNamesInputBox();
        }
    }
}
