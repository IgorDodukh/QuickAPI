using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickAPI
{
    class ParametersReader
    {
        private static void GrantAccess(string file)
        {
            bool exists = System.IO.Directory.Exists(file);
            if (!exists)
            {
                DirectoryInfo di = System.IO.Directory.CreateDirectory(file);
                Console.WriteLine("The Folder is created Sucessfully");
            }
            else
            {
                Console.WriteLine("The Folder already exists");
            }
            DirectoryInfo dInfo = new DirectoryInfo(file);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);

        }

        public static void fileReader()
        {
            string contents = String.Empty;
            GrantAccess("configs/defaultNames.config");
            using (FileStream fs = File.Open("configs/defaultNames.config", FileMode.Open, FileAccess.ReadWrite))
            using (StreamReader reader = new StreamReader(fs))
            {
                contents = reader.ReadToEnd();
            }
            Console.Out.WriteLine("---contents:\n" + contents);

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
                        Console.Out.WriteLine("---mysettings: " + mysettings);
                    } catch(IndexOutOfRangeException e)
                    {
                        MessageBox.Show("Reading config file is failed.");
                    }
                }
                QuickAPIMain.productSKUValue = mysettings["PRODSKU"];
                QuickAPIMain.productNameValue = mysettings["PRODNAME"];
                QuickAPIMain.firstNameValue = mysettings["FIRSTNAME"];
                QuickAPIMain.lastNameValue = mysettings["LASTNAME"];
                QuickAPIMain.warehouseNameValue = mysettings["WAREHOUSENAME"];
            }
        }

        public static void fileWriter()
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

            File.WriteAllText("configs/defaultNames.config", contents);

        }
    }
}
