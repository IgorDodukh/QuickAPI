using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Drawing;

namespace QuickAPI
{

    public class RequestsHandler : GetTokenForm
    {
        public static int requestTypeIndex;
        public static int entityTypeIndex;
        public static string ApiToken;
        private static string json;
        private static string response;
        private static string url;
        private static string entityName;

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
            jsonFilesList.Add("/shippingMethod.json");
            
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
            json = json.Replace("FIRSTFIRSTNAME", QuickAPIMain.firstNameValue);
            json = json.Replace("LASTLASTNAME", QuickAPIMain.lastNameValue);
            json = json.Replace("WHWHNAME", QuickAPIMain.warehouseNameValue);
            json = json.Replace("SHIPMETHNAME", QuickAPIMain.shippingMethodNameValue);
        }

        private static void GetEntityName(string json)
        {
            int firstCharIndex;
            string firstNameTemp;
            string lastNameTemp;

            if (json.Contains("ProductSku"))
                entityName = json.Remove(0, 20);
            else if (json.Contains("WarehouseName"))
                entityName = json.Remove(0, 23);
            else if (json.Contains("CarrierDescription"))
                entityName = json.Remove(0, 14);
            else if (json.Contains("Salutation"))
            {
                firstNameTemp = json.Remove(0, 77);
                firstCharIndex = firstNameTemp.IndexOf("\"");
                firstNameTemp = firstNameTemp.Remove(firstCharIndex, firstNameTemp.Length - firstCharIndex);

                lastNameTemp = json.Remove(0, 40);
                firstCharIndex = lastNameTemp.IndexOf("\"");
                lastNameTemp = lastNameTemp.Remove(firstCharIndex, lastNameTemp.Length - firstCharIndex);

                entityName = firstNameTemp + " " + lastNameTemp;
            }
            firstCharIndex = entityName.IndexOf("\"");
            if (firstCharIndex >= 0)
                entityName = entityName.Remove(firstCharIndex, entityName.Length - firstCharIndex);
        }

        public static void SendJson()
        {
            string result = "";

            List<String> recourcesList = new List<String>();
            recourcesList.Add("/auth");
            recourcesList.Add("/products");
            recourcesList.Add("/warehouses");
            recourcesList.Add("/customers");
            recourcesList.Add("/ShippingMethods");

            List<String> requestsList = new List<String>();
            requestsList.Add("GET");
            requestsList.Add("POST");
            requestsList.Add("PUT");
            requestsList.Add("DELETE");

            try
            {
                LoadJson();
                UpdateJson();
                GetEntityName(json);

                url = recourcesList[entityTypeIndex + 1];

                using (var client = new WebClient())
                {
                    client.Headers.Add("x-freestyle-api-auth", ApiToken);

                    if (requestsList[requestTypeIndex] == "POST")
                    {
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        result = client.UploadString(selectedEnvironmentLink + url, requestsList[requestTypeIndex], json);
                        url = url.Trim('/').TrimEnd('s');
                        MessageBox.Show("Request completed.\nNew " + url + " '" + entityName + "' has been created.");
                    }
                    else if (requestsList[requestTypeIndex] == "GET")
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(selectedEnvironmentLink + url);
                        request.Headers.Add("x-freestyle-api-auth", ApiToken);
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        Stream resStream = response.GetResponseStream();
                        StreamReader readStream = new StreamReader(resStream, Encoding.UTF8);
                        string returnedBody = readStream.ReadToEnd();

                        int firstCharIndex;
                        int index;
                        string returnedItemName = "";
                        string namesList = "";
                        string matchesName = "";
                        int addingIndex = 0;

                        Form form = new Form();
                        TextBox textBox1 = new TextBox();
                        Label label1 = new Label();
                        Label label2 = new Label();
                        Button button1 = new Button();

                        textBox1.Multiline = true;
                        textBox1.Height = 250;
                        textBox1.Width = 200;
                        textBox1.ReadOnly = true;
                        textBox1.ScrollBars = ScrollBars.Vertical;
                        textBox1.Clear();
                        textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;

                        button1.Text = "OK";
                        button1.DialogResult = DialogResult.OK;

                        label1.SetBounds(10, 10, 250, 15);
                        label2.SetBounds(10, 35, 250, 15);
                        textBox1.SetBounds(10, 60, 220, 200);
                        button1.SetBounds(125, 270, 75, 23);

                        form.ClientSize = new Size(240, 300);
                        form.Text = "Found elements list";
                        form.BackColor = System.Drawing.Color.White;
                        form.FormBorderStyle = FormBorderStyle.FixedDialog;
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.MinimizeBox = false;
                        form.MaximizeBox = false;
                        form.AcceptButton = button1;
                        form.Controls.AddRange(new Control[] { label1, label2, textBox1, button1});


                        List<String> matchesNamesList = new List<String>();
                        matchesNamesList.Add("/products");
                        matchesNamesList.Add("\"WarehouseName\"");
                        matchesNamesList.Add("/customers");
                        matchesNamesList.Add("\"Name\"");

                        matchesName = matchesNamesList[entityTypeIndex];

                        if (url.Contains("warehouses"))
                        {
                            addingIndex = 17;
                        }
                        else if (url.Contains("ShippingMethods"))
                        {
                            addingIndex = 8;
                        }
                        StringBuilder sb = new StringBuilder();

                        var matches = Regex.Matches(returnedBody, matchesName);
                        foreach (var m in matches)
                        {
                            index = returnedBody.IndexOf(m.ToString());
                            returnedItemName = returnedBody.Remove(0, index + addingIndex);
                            firstCharIndex = returnedItemName.IndexOf("\"");
                            if (firstCharIndex >= 0)
                                returnedItemName = returnedItemName.Remove(firstCharIndex, returnedItemName.Length - firstCharIndex);
                            namesList += returnedItemName + "\n";

                            sb.AppendLine(returnedItemName);

                            returnedBody = returnedBody.Remove(0, returnedBody.IndexOf(returnedItemName) + returnedItemName.Length);
                            Console.WriteLine(firstCharIndex);
                            Console.WriteLine(returnedItemName);
                        }
                        url = url.Trim('/').TrimEnd('s');

                        label1.Text = "Request completed (" + matches.Count + " elements found)";
                        label2.Text = "A list of " + url + "s has been returned";
                        textBox1.Text += sb.ToString();
                        form.ShowDialog();
//                        MessageBox.Show("Request completed.\nA list of " + url + "s has been returned\n(" + matches.Count + " elements found):\n\n" + namesList);
                    }
                }

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
