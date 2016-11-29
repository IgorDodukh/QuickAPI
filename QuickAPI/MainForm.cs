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

            string login = null;
            string password = null;
            TokenReceiver.CreateObject(login, password);

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
    }
}
