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
                QuickAPIMain.productSKUValue = mysettings["PRODSKU"];
                QuickAPIMain.productNameValue = mysettings["PRODNAME"];
                QuickAPIMain.firstNameValue = mysettings["FIRSTNAME"];
                QuickAPIMain.lastNameValue = mysettings["LASTNAME"];
                QuickAPIMain.warehouseNameValue = mysettings["WAREHOUSENAME"];
                QuickAPIMain.shippingMethodNameValue = mysettings["SHIPMETHNAME"];
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


        public static void UpdateDefaultNames()
        {
            string contents = String.Empty;
            using (FileStream fs = File.Open("configs/defaultNames.config", FileMode.Open))
            using (StreamReader reader = new StreamReader(fs))
            {
                contents = reader.ReadToEnd();
            }
            contents = contents.Replace(QuickAPIMain.productSKUValue, QuickAPIMain.newProductSKUValue);
            contents = contents.Replace(QuickAPIMain.productNameValue, QuickAPIMain.newProductNameValue);
            contents = contents.Replace(QuickAPIMain.firstNameValue, QuickAPIMain.newFirstNameValue);
            contents = contents.Replace(QuickAPIMain.lastNameValue, QuickAPIMain.newLastNameValue);
            contents = contents.Replace(QuickAPIMain.warehouseNameValue, QuickAPIMain.newWarehouseNameValue);
            contents = contents.Replace(QuickAPIMain.shippingMethodNameValue, QuickAPIMain.newShippingMethodNameValue);

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
    }
}
