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

        public static string randomNumberLength;
        public static string newRandomNumberLength;

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
            json = json.Replace("xxxxx", RandomString(Convert.ToInt32(randomNumberLength)));
            json = json.Replace("PRODPRODSKU", MainForm.productSKUValue);
            json = json.Replace("PRODPRODNAME", MainForm.productNameValue);
            json = json.Replace("FIRSTFIRSTNAME", MainForm.firstNameValue);
            json = json.Replace("LASTLASTNAME", MainForm.lastNameValue);
            json = json.Replace("WHWHNAME", MainForm.warehouseNameValue);
            json = json.Replace("SHIPMETHNAME", MainForm.shippingMethodNameValue);
            json = json.Replace("11111", MainForm.productQuantityValue);

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
            recourcesList.Add("/orders");

            List<String> requestsList = new List<String>();
            requestsList.Add("GET");
            requestsList.Add("POST");
            requestsList.Add("PUT");
            requestsList.Add("DELETE");

            try
            {
                if (entityTypeIndex != 4)
                {
                    LoadJson();
                    UpdateJson();
                    GetEntityName(json);
                }

                url = recourcesList[entityTypeIndex + 1];

                using (var client = new WebClient())
                {
                    client.Headers.Add("x-freestyle-api-auth", ApiToken);

                    if (requestsList[requestTypeIndex] == "POST")
                    {
                        if(entityTypeIndex == 4)
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(selectedEnvironmentLink + url + "/" + MainForm.orderNumber);
                            request.Headers.Add("x-freestyle-api-auth", ApiToken);
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            Stream resStream = response.GetResponseStream();
                            StreamReader readStream = new StreamReader(resStream, Encoding.UTF8);
                            json = readStream.ReadToEnd();
                            Console.WriteLine("--Order json: " + json);
                            entityName = MainForm.orderNumber + "-" + RandomString(Convert.ToInt32(randomNumberLength));
                            json = json.Replace(MainForm.orderNumber, entityName);
                            json = json.Replace("+00:00", "");

                            
                            Console.WriteLine("--updated json: " + json);

                        }
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
                        string selectedListBoxItem = "";
                        string resourceName = "";

                        Form form = new Form();
                        ListBox listBox = new ListBox();
                        Label label1 = new Label();
                        Label label2 = new Label();
                        Button okButton = new Button();
                        Button deleteButton = new Button();

                        listBox.Height = 250;
                        listBox.Width = 200;
                        listBox.Anchor = listBox.Anchor | AnchorStyles.Right;

                        okButton.Text = "OK";
                        deleteButton.Text = "Delete Item";
                        okButton.DialogResult = DialogResult.OK;
                        deleteButton.DialogResult = DialogResult.Yes;

                        label1.SetBounds(10, 10, 250, 15);
                        label2.SetBounds(10, 35, 250, 15);
                        listBox.SetBounds(10, 60, 220, 200);
                        okButton.SetBounds(145, 270, 75, 23);
                        deleteButton.SetBounds(25, 270, 100, 23);

                        deleteButton.FlatStyle = FlatStyle.Flat;
                        deleteButton.BackColor = Color.FromArgb(255, 53, 53);
                        deleteButton.ForeColor = Color.White;
                        deleteButton.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
//                        deleteButton.Enabled = false;

                        form.ClientSize = new Size(240, 300);
                        form.Text = "Found elements list";
                        form.BackColor = System.Drawing.Color.White;
                        form.FormBorderStyle = FormBorderStyle.FixedDialog;
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.MinimizeBox = false;
                        form.MaximizeBox = false;
                        form.AcceptButton = okButton;
                        form.Controls.AddRange(new Control[] { label1, label2, listBox, okButton, deleteButton});


                        List<String> matchesNamesList = new List<String>();
                        matchesNamesList.Add("\"ProductName\"");
                        matchesNamesList.Add("\"WarehouseName\"");
                        matchesNamesList.Add("\"FirstName\"");
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
                        else if (url.Contains("products"))
                        {
                            addingIndex = 15;
                        }
                        else if (url.Contains("customers"))
                        {
                            addingIndex = 13;
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
                            listBox.Items.Add(returnedItemName);
                            returnedBody = returnedBody.Remove(0, returnedBody.IndexOf(returnedItemName) + returnedItemName.Length);
                            Console.WriteLine("--firstCharIndex: " + firstCharIndex);
                            Console.WriteLine("--returnedItemName: " + returnedItemName);
                        }
                        resourceName = url.Trim('/').TrimEnd('s');
                        listBox.SetSelected(0, true);

                        label1.Text = "Request completed (" + matches.Count + " elements found)";
                        label2.Text = "A list of " + resourceName + "s has been returned";
                        
                        form.ShowDialog();
                        if(form.DialogResult == DialogResult.Yes)
                        {
                            selectedListBoxItem = listBox.SelectedItem.ToString();
                            DeleteRequest(selectedListBoxItem, selectedEnvironmentLink + url);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Request failed:\n" + e.Message + "\n" + result);
            }
        }

        public static void DeleteRequest(string itemName, string resourceUrl)
        {
            Console.Out.WriteLine(itemName +", " + resourceUrl);

            string urlFiltering = "";
            string finalUrl = "";

            if (resourceUrl.Contains("warehouses"))
            {
                urlFiltering = string.Concat(resourceUrl, "?WarehouseName=" + itemName);
            }
            else if (resourceUrl.Contains("ShippingMethods"))
            {
                urlFiltering = string.Concat(resourceUrl, "?Name=" + itemName);
            }
            Console.Out.WriteLine(urlFiltering);

            int firstCharIndex;
            string returnedId = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlFiltering);
            request.Headers.Add("x-freestyle-api-auth", ApiToken);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(resStream, Encoding.UTF8);
            string returnedBody = readStream.ReadToEnd();
            Console.Out.WriteLine(returnedBody);

            returnedBody = returnedBody.Remove(0, 8);
            firstCharIndex = returnedBody.IndexOf("\"");
            if (firstCharIndex >= 0)
                returnedId = returnedBody.Remove(firstCharIndex, returnedBody.Length - firstCharIndex);

            Console.Out.WriteLine("final id: " + returnedId);
            finalUrl = resourceUrl + "/" + returnedId;

            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(finalUrl);
            request2.Method = ("DELETE");
            request2.Headers.Add("x-freestyle-api-auth", ApiToken);
            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();

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
