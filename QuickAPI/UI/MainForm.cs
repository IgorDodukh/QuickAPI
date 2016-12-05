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
    public partial class MainForm : Form
    {
        private static GetTokenForm getTokenForm = new GetTokenForm();

        public static string productSKUValue;
        public static string productNameValue;
        public static string firstNameValue;
        public static string lastNameValue;
        public static string warehouseNameValue;
        public static string shippingMethodNameValue;

        public static string productQuantityValue;

        public static string newProductSKUValue;
        public static string newProductNameValue;
        public static string newFirstNameValue;
        public static string newLastNameValue;
        public static string newWarehouseNameValue;
        public static string newShippingMethodNameValue;

        public static string newProductQuantityValue;

        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += QuickAPIMain_FormClosing;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            ParametersReader.ReadDefaultNames();
            ParametersReader.ReadDefaultVariables();
            RequestsHandler.requestTypeIndex = requestTypeComboBox.SelectedIndex;
            RequestsHandler.entityTypeIndex = entityTypeComboBox.SelectedIndex;
            RequestsHandler.SendJson();

        }

        private void QuickAPIMain_Load(object sender, EventArgs e)
        {
            ParametersReader.ReadDefaultNames();

            Dictionary<string, string> entityTypes = new Dictionary<string, string>();
            entityTypes.Add("Product", "Products");
            entityTypes.Add("Warehouse", "Warehouses");
            entityTypes.Add("Customer", "Customers");
            entityTypes.Add("ShippingMethod", "ShippingMethods");

            entityTypeComboBox.DataSource = new BindingSource(entityTypes, null);
            entityTypeComboBox.DisplayMember = "Key";
            entityTypeComboBox.ValueMember = "Value";
            entityTypeComboBox.SelectedIndex = 0;

            Dictionary<string, string> requestTypes = new Dictionary<string, string>();
            requestTypes.Add("GET", "View");
            requestTypes.Add("POST", "Create");
            requestTypes.Add("PUT", "Update");
            requestTypes.Add("DELETE", "Remove");


            requestTypeComboBox.DataSource = new BindingSource(requestTypes, null);
            requestTypeComboBox.DisplayMember = "Key";
            requestTypeComboBox.ValueMember = "Value";
            requestTypeComboBox.SelectedIndex = 1;

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
            ParametersReader.ReadDefaultNames();

            Form form = new Form();
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            Label label4 = new Label();
            Label label5 = new Label();
            Label label6 = new Label();


            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            TextBox textBox3 = new TextBox();
            TextBox textBox4 = new TextBox();
            TextBox textBox5 = new TextBox();
            TextBox textBox6 = new TextBox();

            Button buttonSave = new Button();
            Button buttonCancel = new Button();

            form.Text = "Custom Default Names";
            form.BackColor = Color.White;
            label1.Text = "Product SKU";
            label2.Text = "Product Name";
            label3.Text = "Customer First Name";
            label4.Text = "Customer Last Name";
            label5.Text = "Warehouse Name";
            label6.Text = "Ship Method Name";

            textBox1.Text = productSKUValue;
            textBox2.Text = productNameValue;
            textBox3.Text = firstNameValue;
            textBox4.Text = lastNameValue;
            textBox5.Text = warehouseNameValue;
            textBox6.Text = shippingMethodNameValue;

            buttonSave.Text = "Save";
            buttonCancel.Text = "Cancel";

            buttonSave.ForeColor = Color.White;
            buttonSave.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.BackColor = Color.FromArgb(45, 177, 53);

            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.BackColor = Color.FromArgb(255, 53, 53);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);


            buttonSave.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label1.SetBounds(10, 10, 110, 22);
            textBox1.SetBounds(120, 8, 250, 22);

            label2.SetBounds(10, 40, 110, 22);
            textBox2.SetBounds(120, 38, 250, 22);

            label3.SetBounds(10, 70, 110, 22);
            textBox3.SetBounds(120, 68, 250, 22);

            label4.SetBounds(10, 100, 110, 22);
            textBox4.SetBounds(120, 98, 250, 22);

            label5.SetBounds(10, 130, 110, 22);
            textBox5.SetBounds(120, 128, 250, 22);

            label6.SetBounds(10, 160, 110, 22);
            textBox6.SetBounds(120, 158, 250, 22);

            buttonSave.SetBounds(210, 190, 75, 23);
            buttonCancel.SetBounds(290, 190, 75, 23);

            textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;
            textBox2.Anchor = textBox2.Anchor | AnchorStyles.Right;
            textBox3.Anchor = textBox3.Anchor | AnchorStyles.Right;
            textBox4.Anchor = textBox4.Anchor | AnchorStyles.Right;
            textBox5.Anchor = textBox5.Anchor | AnchorStyles.Right;
            textBox6.Anchor = textBox5.Anchor | AnchorStyles.Right;

            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(380, 220);
            form.Controls.AddRange(new Control[] { label1, label2, label3, label4, label5, label6,
            textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, buttonSave, buttonCancel });
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
                newShippingMethodNameValue = textBox6.Text;
                ParametersReader.UpdateDefaultNames();
            }
            else Console.Out.WriteLine("Dialog cancelled");

            return dialogResult;
        }

        private static void Number_Validating(object sender, CancelEventArgs e)
        {
            int val;
            TextBox tb = sender as TextBox;
            if (!int.TryParse(tb.Text, out val))
            {
                MessageBox.Show("Field value must be numeric.");
                tb.Undo();
                e.Cancel = true;
            }
        }

        public static DialogResult SystemVariablesInputBox()
        {
            ParametersReader.ReadDefaultVariables();

            Form form = new Form();
            Label label1 = new Label();
            Label label2 = new Label();

            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();

            Button buttonSave = new Button();
            Button buttonCancel = new Button();

            form.Text = "System Variables";
            form.BackColor = Color.White;
            label1.Text = "Default Product Qty:";
            label2.Text = "Random number contains digit(s):";

            textBox1.Text = productQuantityValue;
            textBox2.Text = RequestsHandler.randomNumberLength;

            buttonSave.Text = "Save";
            buttonCancel.Text = "Cancel";
            buttonSave.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label1.SetBounds(10, 10, 170, 22);
            textBox1.SetBounds(180, 8, 30, 22);

            label2.SetBounds(10, 40, 170, 22);
            textBox2.SetBounds(180, 38, 30, 22);

            buttonSave.SetBounds(50, 70, 75, 23);
            buttonCancel.SetBounds(130, 70, 75, 23);

            textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;
            textBox2.Anchor = textBox2.Anchor | AnchorStyles.Right;

            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            buttonSave.ForeColor = Color.White;
            buttonSave.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.BackColor = Color.FromArgb(45, 177, 53);

            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.BackColor = Color.FromArgb(255, 53, 53);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);

            form.ClientSize = new Size(225, 105);
            form.Controls.AddRange(new Control[] { label1, label2, textBox1, textBox2, buttonSave, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label1.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonSave;
            form.CancelButton = buttonCancel;

            textBox1.Validating += new CancelEventHandler(Number_Validating);
            textBox2.Validating += new CancelEventHandler(Number_Validating);

            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                newProductQuantityValue = textBox1.Text;
                RequestsHandler.newRandomNumberLength = textBox2.Text;
                ParametersReader.UpdateDefaultVariables();
            }
            else Console.Out.WriteLine("Dialog cancelled");

            return dialogResult;
        }


        private void entityTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(eventLabel.Text.Contains(" "))
            {
                string entityValue = ((KeyValuePair<string, string>)entityTypeComboBox.SelectedItem).Key;
                string requestValue = ((KeyValuePair<string, string>)requestTypeComboBox.SelectedItem).Value;
                string value = eventLabel.Text;
                value = value.Remove(value.IndexOf(" "), value.Length - value.IndexOf(" "));
                eventLabel.Text = value + " " + entityValue;
                /*
                if (entityValue.Contains("Shipping") && requestValue.Contains("Create"))
                {
                    label5.Text = "Shipping Service:";
                    label6.Text = "UPS Ground";
                } else if (!requestValue.Contains("Create"))
                {
                    label5.Text = "";
                    label6.Text = "";
                }*/
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
                /*
                if (requestValue.Contains("View"))
                {
                    label5.Text = "Supported:";
                    label6.Text = "WH and Ship Methods";
                }
                else
                {
                    label5.Text = "";
                    label6.Text = "";
                }*/
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            getTokenForm.Show();
            RequestsHandler.ApiToken = null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void defaultNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefaultNamesInputBox();
        }

        private void systemVariablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemVariablesInputBox();
        }
    }
}
