using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickAPI
{
    class ParametersReader
    {
        public static void ReadDefaultNames()
        {
            string contents = String.Empty;
            using (FileStream fs = File.Open("configs/defaultNames.config", FileMode.Open, FileAccess.ReadWrite))
            using (StreamReader reader = new StreamReader(fs))
            {
                contents = reader.ReadToEnd();
            }

            if (contents.Length > 0)
            {
                string[] lines = contents.Split(new char[] { '\n' });
                Dictionary<string, string> mysettings = new Dictionary<string, string>();
                foreach (string line in lines)
                {
                    try
                    {
                        string[] keyAndValue = line.Split(new char[] { '=' });
                        mysettings.Add(keyAndValue[0].Trim(), keyAndValue[1].Trim());
                    } catch(IndexOutOfRangeException e)
                    {
                        MessageBox.Show("Reading config file is failed. " + e.Message);
                    }
                }
                MainForm.productSKUValue = mysettings["PRODSKU"];
                MainForm.productNameValue = mysettings["PRODNAME"];
                MainForm.firstNameValue = mysettings["FIRSTNAME"];
                MainForm.lastNameValue = mysettings["LASTNAME"];
                MainForm.warehouseNameValue = mysettings["WAREHOUSENAME"];
                MainForm.shippingMethodNameValue = mysettings["SHIPMETHNAME"];
            }
        }

        public static void ReadDefaultCredentials()
        {
            string contents = String.Empty;
            using (FileStream fs = File.Open("configs/defaultCredentials.config", FileMode.Open, FileAccess.ReadWrite))
            using (StreamReader reader = new StreamReader(fs))
            {
                contents = reader.ReadToEnd();
            }

            if (contents.Length > 0)
            {
                string[] lines = contents.Split(new char[] { '\n' });
                Dictionary<string, string> mysettings = new Dictionary<string, string>();
                foreach (string line in lines)
                {
                    try
                    {
                        string[] keyAndValue = line.Split(new char[] { '=' });
                        mysettings.Add(keyAndValue[0].Trim(), keyAndValue[1].Trim());
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        MessageBox.Show("Reading config file is failed. " + e.Message);
                    }
                }
                GetTokenForm.loginValue = mysettings["DEFAULTLOGIN"];
                GetTokenForm.passwordValue = mysettings["DEFAULTPASS"];
            }
        }

        public static void ReadDefaultVariables()
        {
            string contents = String.Empty;
            using (FileStream fs = File.Open("configs/defaultVariables.config", FileMode.Open, FileAccess.ReadWrite))
            using (StreamReader reader = new StreamReader(fs))
            {
                contents = reader.ReadToEnd();
            }

            if (contents.Length > 0)
            {
                string[] lines = contents.Split(new char[] { '\n' });
                Dictionary<string, string> mysettings = new Dictionary<string, string>();
                foreach (string line in lines)
                {
                    try
                    {
                        string[] keyAndValue = line.Split(new char[] { '=' });
                        mysettings.Add(keyAndValue[0].Trim(), keyAndValue[1].Trim());
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        MessageBox.Show("Reading config file is failed. " + e.Message);
                    }
                }
                MainForm.productQuantityValue = mysettings["PRODQTY"];
                RequestsHandler.randomNumberLength = mysettings["RANDOMNUMBER"];
            }
        }


        public static void UpdateDefaultNames()
        {
            string contents = String.Empty;
            using (FileStream fs = File.Open("configs/defaultNames.config", FileMode.Open))
            using (StreamReader reader = new StreamReader(fs))
            {
                contents = reader.ReadToEnd();
            }
            contents = contents.Replace(MainForm.productSKUValue, MainForm.newProductSKUValue);
            contents = contents.Replace(MainForm.productNameValue, MainForm.newProductNameValue);
            contents = contents.Replace(MainForm.firstNameValue, MainForm.newFirstNameValue);
            contents = contents.Replace(MainForm.lastNameValue, MainForm.newLastNameValue);
            contents = contents.Replace(MainForm.warehouseNameValue, MainForm.newWarehouseNameValue);
            contents = contents.Replace(MainForm.shippingMethodNameValue, MainForm.newShippingMethodNameValue);

            File.WriteAllText("configs/defaultNames.config", contents);
        }

        public static void UpdateDefaultCredentials()
        {
            string contents = String.Empty;
            using (FileStream fs = File.Open("configs/defaultCredentials.config", FileMode.Open))
            using (StreamReader reader = new StreamReader(fs))
            {
                contents = reader.ReadToEnd();
            }
            contents = contents.Replace(GetTokenForm.loginValue, GetTokenForm.newLoginValue);
            contents = contents.Replace(GetTokenForm.passwordValue, GetTokenForm.newPasswordValue);

            File.WriteAllText("configs/defaultCredentials.config", contents);
        }

        public static void UpdateDefaultVariables()
        {
            string contents = String.Empty;
            using (FileStream fs = File.Open("configs/defaultVariables.config", FileMode.Open))
            using (StreamReader reader = new StreamReader(fs))
            {
                contents = reader.ReadToEnd();
            }

            contents = contents.Replace(MainForm.productQuantityValue, MainForm.newProductQuantityValue);
            contents = contents.Replace(RequestsHandler.randomNumberLength, RequestsHandler.newRandomNumberLength);

            File.WriteAllText("configs/defaultVariables.config", contents);
        }
    }
}
