using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickAPI
{
    class ParametersReader
    {
        public static void fileReader()
        {
            string contents = String.Empty;
            using (FileStream fs = File.Open("defaultNames.txt", FileMode.Open))
            using (StreamReader reader = new StreamReader(fs))
            {
                contents = reader.ReadToEnd();
            }
            Console.Out.WriteLine("---contents" + contents);

            if (contents.Length > 0)
            {
                string[] lines = contents.Split(new char[] { '\n' });
                Dictionary<string, string> mysettings = new Dictionary<string, string>();
                foreach (string line in lines)
                {
                    string[] keyAndValue = line.Split(new char[] { '=' });
                    mysettings.Add(keyAndValue[0].Trim(), keyAndValue[1].Trim());
                    Console.Out.WriteLine("---mysettings" + mysettings);

                }
                string test = mysettings["USERID"]; // example of getting userid
                Console.Out.WriteLine("---USERID" + test);

            }
        }
    }
}
