using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSIS484
{
    public partial class MainForm : Form
    {
        string[] STATUS = {"Validating Stock", "Stock Verified", "Shipped", "Received", "Cancelled"};
        string storeId;
        string encryptedPassword;

        public MainForm(string storeId, string encryptedPassword)
        {
            InitializeComponent();

            this.Text = $"Inter-Store Transfer System: {storeId}";
            this.storeId = storeId;
            this.encryptedPassword = encryptedPassword;

            JObject outgoing = getRequests("outgoing", "active");
            Console.WriteLine(outgoing);
            if (outgoing != null && (outgoing["data"] as JArray)?.Count > 0)
            {
                foreach (JObject record in outgoing["data"])
                {
                    string id = (string)record["TransferId"];
                    string orderDate = (string)record["OrderDateTime"];
                    string requestedStore = (string)record["RequestedStoreId"];
                    string itemId = (string)record["ItemId"];
                    string quantity = (string)record["Quantity"];
                    int status = (int)record["TransferStatus"];
                    string completedDateTime = (string)record["CompletedDateTime"];

                    ListViewItem item = new ListViewItem(id);
                    item.SubItems.Add(orderDate);
                    item.SubItems.Add(requestedStore);
                    item.SubItems.Add(STATUS[status]);
                    item.SubItems.Add(itemId);
                    item.SubItems.Add(quantity);
                    outgoingRequests.Items.Add(item);
                }
            }
            else
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add("NONE");
                outgoingRequests.Items.Add(item);
            }

            JObject incoming = getRequests("incoming", "active");
            Console.WriteLine(incoming);
            if (incoming != null && (incoming["data"] as JArray)?.Count > 0)
            {
                foreach (JObject record in incoming["data"])
                {
                    string id = (string)record["TransferId"];
                    string orderDate = (string)record["OrderDateTime"];
                    string requestedStore = (string)record["RequestedStoreId"];
                    string itemId = (string)record["ItemId"];
                    string quantity = (string)record["Quantity"];
                    int status = (int)record["TransferStatus"];
                    string completedDateTime = (string)record["CompletedDateTime"];

                    ListViewItem item = new ListViewItem(id);
                    item.SubItems.Add(orderDate);
                    item.SubItems.Add(requestedStore);
                    item.SubItems.Add(STATUS[status]);
                    item.SubItems.Add(itemId);
                    item.SubItems.Add(quantity);
                    incomingRequests.Items.Add(item);
                }
            }
            else
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Add("NONE");
                incomingRequests.Items.Add(item);
            }
        }

        public JObject getRequests(string type, string status)
        {
            string url = $"http://localhost:3030/v1/requests?storeId={storeId}&key={encryptedPassword}&type={type}&status={status}";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return JObject.Parse(reader.ReadToEnd());
                }
        }
    }
}
