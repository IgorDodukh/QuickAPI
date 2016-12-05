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

        private static string RandomString(int Size)
        {
            Random random = new Random();
            //abcdefghijklmnopqrstuvwxyz
            string input = "0123456789";
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < Size; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
        }

        private static void LoadJson()
        {
            List<String> jsonFilesList = new List<String>();
            jsonFilesList.Add("/product.json");
            jsonFilesList.Add("/warehouse.json");
            jsonFilesList.Add("/customer.json");

            using (StreamReader r = new StreamReader("json/" + jsonFilesList[entityTypeIndex]))
            {
                json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                json = array.ToString();
            }
        }

        private static void UpdateJson()
        {
            json = json.Replace("xxxxx", RandomString(5));
            json = json.Replace("PRODPRODSKU", QuickAPIMain.productSKUValue);
            json = json.Replace("PRODPRODNAME", QuickAPIMain.productNameValue);
            json = json.Replace("FIRSTNAME", QuickAPIMain.firstNameValue);
            json = json.Replace("LASTNAME", QuickAPIMain.lastNameValue);
            json = json.Replace("WHWHNAME", QuickAPIMain.warehouseNameValue);

        }
        public static void SendJson()
        {
            List<String> recourcesList = new List<String>();
            recourcesList.Add("/auth");
            recourcesList.Add("/products");
            recourcesList.Add("/warehouses");
            recourcesList.Add("/customers");

            List<String> requestsList = new List<String>();
            requestsList.Add("GET");
            requestsList.Add("POST");
            requestsList.Add("PUT");
            requestsList.Add("DELETE");
            

            string result = "";
            try
            {

                using (var client = new WebClient())
                {
                    url = recourcesList[entityTypeIndex + 1];
                    client.Headers.Add("x-freestyle-api-auth", ApiToken);

                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    if(requestTypeIndex == 0)
                    {
                        result = client.UploadString(selectedEnvironmentLink + url, requestsList[requestTypeIndex]);
                    }
                    else
                    {
                        LoadJson();
                        UpdateJson();

                        result = client.UploadString(selectedEnvironmentLink + url, requestsList[requestTypeIndex], json);
                    }
                }
                Console.WriteLine("--result: " + result);
                Console.WriteLine("--result JSON: " + json);
                url = url.Trim('/').TrimEnd('s');
                MessageBox.Show("Request completed.\nNew " + url + " has been created.");
            }
            catch (Exception e)
            {
                Console.WriteLine(result);
                MessageBox.Show("Request failed:\n" + e.Message + "\n" + result);
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
                UpdateJson();
                DATA = json;
            }

            request.Method = requestsList[requestTypeIndex];
            request.ContentType = "application/json";
            request.ContentLength = DATA.Length;
            
            try
            {
                StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
                Console.Out.WriteLine("---DATA: " + DATA);

                requestWriter.Write(DATA);
                requestWriter.Close();

                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                response = responseReader.ReadToEnd();
                Console.Out.WriteLine("----Response(try): " + response);
                ApiToken = response.Replace("{\"token\":\"", "").Replace("\"}", "");
                responseReader.Close();
                if (!url.Contains("auth"))
                {
                    url = url.Trim('/').TrimEnd('s');
                    MessageBox.Show("Request completed. New " + url+ " has been created.");
                }

            }
            catch (WebException e)
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
