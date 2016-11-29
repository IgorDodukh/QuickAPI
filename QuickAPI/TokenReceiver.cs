using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace QuickAPI
{

    public class TokenReceiver : GetTokenForm
    {
        public static int requestTypeIndex;
        public static int entityTypeIndex;
        public static string ApiToken;
        private static string json;
        private static string response;
        private static string url;

        public static void LoadJson()
        {
            List<String> jsonFilesList = new List<String>();
            jsonFilesList.Add("/product.json");
            jsonFilesList.Add("/warehouse.json");
            jsonFilesList.Add("/customer.json");

            using (StreamReader r = new StreamReader("json/" + jsonFilesList[entityTypeIndex]))
            {
                Console.WriteLine("Selected json file: json/" + jsonFilesList[entityTypeIndex]);

                json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                json = array.ToString();
            }
        }

        public static void CreateObject(string login, string password)
        {
            List<String> recourcesList = new List<String>();
            recourcesList.Add("/auth");
            recourcesList.Add("/products");
            recourcesList.Add("/warehouses");
            recourcesList.Add("/customers");

            List<String> requestsList = new List<String>();
            requestsList.Add("POST");
            requestsList.Add("PUT");
            requestsList.Add("DELETE");

            if (ApiToken != null)
            {
                url = recourcesList[entityTypeIndex + 1];
                Console.Out.WriteLine("---url: " + url);
                LoadJson();
            }
            else url = recourcesList[0];
            //            login = "magentoClint@dydacomp.biz";
            //            password = "Password#1";
            string DATA = @"{""username"":""" + login + "\",\"Password\":\"" + password + "\"}";

            Console.Out.WriteLine("---URL: " + selectedEnvironmentLink + url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(selectedEnvironmentLink + url);

            if (url != recourcesList[0])
            {
                request.Headers.Add("x-freestyle-api-auth", ApiToken);
                DATA = json;
            }

            request.Method = requestsList[requestTypeIndex];
            request.ContentType = "application/json";
            request.ContentLength = DATA.Length;
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            Console.Out.WriteLine("---DATA: " + DATA);

            requestWriter.Write(DATA);
            requestWriter.Close();
            
            try
            {
                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                response = responseReader.ReadToEnd();
                Console.Out.WriteLine("----Response(try): " + response);
                ApiToken = response.Replace("{\"token\":\"", "");
                ApiToken = ApiToken.Replace("\"}", "");
                responseReader.Close();
                if (!url.Contains("auth"))
                {
                    url = url.Trim('/').TrimEnd('s');
                    MessageBox.Show("Request completed. New " + url+ " has been created.");
                }

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine("----Response(catch): " + response);
                Console.Out.WriteLine(e.Message);
                MessageBox.Show("Request failed:\n" + e.Message);
            }

            response = "";
        }
    }
}
