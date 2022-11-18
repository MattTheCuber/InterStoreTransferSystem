using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSIS484
{
    // Main form
    public partial class MainForm : Form
    {
        // Init variables
        string storeId;
        string encryptedPassword;
        Transfer[] outgoing;
        Transfer[] incoming;

        // Main form takes in request credentials
        public MainForm(string storeId, string encryptedPassword)
        {
            InitializeComponent();

            // For debugging
            //txtSearch.Text = "50002";

            // Set the form name
            Text = $"Inter-Store Transfer System: {storeId}";
            // Store the credentials
            this.storeId = storeId;
            this.encryptedPassword = encryptedPassword;

            // Load the active transfer
            refresh();
        }

        // Makes a request to the URL and returns a JObject of the data
        private JObject request(string url)
        {
            // Make the HTTP request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                // Convert and return the result as a JObject
                JObject res = JObject.Parse(reader.ReadToEnd());
                Console.WriteLine(res);
                return res;
            }
        }

        // Gets the transfer requests of any type
        private Transfer[] getRequests(string type, string status)
        {
            // Create the URL to get the requests of the type and status specified
            string url = $"http://localhost:3030/v1/requests?storeId={storeId}&key={encryptedPassword}&type={type}&status={status}";

            // Make the request
            JObject res = request(url);
            // If the result is valid
            if (res != null && (res["data"] as JArray)?.Count > 0)
            {
                // Init transfers array
                Transfer[] transfers = new Transfer[(res["data"] as JArray).Count];
                // For each transfer
                int index = 0;
                foreach (JObject record in res["data"])
                {
                    // Convert to Transfer object and add to the array
                    transfers[index] = new Transfer(record);
                    index++;
                }
                return transfers;
            }
            else
            {
                // Else return an empty array
                return new Transfer[0];
            }
        }

        // Populates a ListView with transfers
        private void populateTransfers(Transfer[] transfers, System.Windows.Forms.ListView list)
        {
            // Clear the items from the view
            list.Items.Clear();

            // If the list is valid
            if (transfers != null && transfers.Length > 0)
            {
                // For each transfer
                foreach (Transfer transfer in transfers)
                {
                    // Create a list item with the necessary information
                    ListViewItem item = new ListViewItem(Convert.ToString(transfer.getId()));
                    item.SubItems.Add(transfer.getOrderDate());
                    item.SubItems.Add(Convert.ToString(transfer.getRequestedStore()));
                    item.SubItems.Add(transfer.getStatus());
                    item.SubItems.Add(Convert.ToString(transfer.getItemId()));
                    item.SubItems.Add(Convert.ToString(transfer.getQuantity()));
                    // Add the item to the view
                    list.Items.Add(item);
                }
            }
        }

        // On open outgoing transfer button click
        private void btnOpenOutgoingTransfer_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (outgoingRequests.SelectedItems.Count == 1)
            {
                // Get the request id
                int id = Convert.ToInt32(outgoingRequests.SelectedItems[0].Text);

                // Find the transfer
                Transfer transfer = outgoing.SingleOrDefault(t => t.getId() == id);
                // Create and show a transfer form
                ViewTransferForm transferForm = new ViewTransferForm(storeId, encryptedPassword, transfer, true);
                transferForm.ShowDialog();
                // Refresh the active transfers
                refresh();
            }
        }

        // On open incoming transfer button click
        private void btnOpenIncomingTransfer_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (incomingRequests.SelectedItems.Count == 1)
            {
                // Get the request id
                int id = Convert.ToInt32(incomingRequests.SelectedItems[0].Text);

                // Find the transfer
                Transfer transfer = incoming.SingleOrDefault(t => t.getId() == id);
                // Create and show a transfer form
                ViewTransferForm transferForm = new ViewTransferForm(storeId, encryptedPassword, transfer, false);
                transferForm.ShowDialog();
                // Refresh the active transfers
                refresh();
            }
        }

        // On search item button click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the search text
            string search = txtSearch.Text;
            // Set the item id and name to null
            string itemId = null;
            string itemName = null;

            // If the search text is empty
            if (search == "")
            {
                // Show the error and return
                lvlInvalidSearch.Visible = true;
                return;
            }

            // Requests the items endpoint
            string itemsUrl = $"http://localhost:3030/v1/items?storeId={storeId}&key={encryptedPassword}";
            JObject itemRes = request(itemsUrl);

            // If the items data is valid
            if (itemRes != null && (itemRes["data"] as JArray)?.Count > 0)
            {
                // For each item
                foreach (JObject record in itemRes["data"])
                {
                    // If the search is an item id
                    if (int.TryParse(search, out int value))
                    {
                        // If the item id = the search id
                        if ((string)record["ItemId"] == search)
                        {
                            // Set the item id and item name then break the loop
                            itemId = (string)record["ItemId"];
                            itemName = (string)record["ItemName"];
                            break;
                        }
                    }
                    // Else the search is a text search
                    else
                    {
                        // Format the item name and convert to lower case
                        string testItemName = Regex.Replace((string)record["ItemName"], @"\\", "").ToLower();
                        // Test if the item name contains the lower case search text
                        if (testItemName.Contains(search.ToLower()))
                        {
                            // Set the item id and item name then break the loop
                            itemId = (string)record["ItemId"];
                            itemName = (string)record["ItemName"];
                            break;
                        }
                    }
                }
            }

            // If the item id was never found
            if (itemId == null)
            {
                // Show the error and return
                lvlInvalidSearch.Visible = true;
                return;
            }

            // Hide the error message
            lvlInvalidSearch.Visible = false;

            // Request the store items endpoint
            string url = $"http://localhost:3030/v1/items/{itemId}?storeId={storeId}&key={encryptedPassword}";
            JObject res = request(url);

            // If the data is invalid
            if (res == null || (res["data"] as JArray)?.Count < 1)
            {
                // Alert that there are no stores that have this item in stock
                MessageBox.Show($"The item {itemName} was not found in any stores", "Item Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Create a transfer request form passing in the credentials, item data, and the items endpoint data
                CreateTransfer createTransfer = new CreateTransfer(storeId, encryptedPassword, itemId, itemName, res);
                // Show the dialog and pause this form until that form is closed
                createTransfer.ShowDialog();
                // Refresh the active transfers
                refresh();
            }
        }

        // Refreshes the active request views
        private void refresh()
        {
            // Get the outgoing requests and populate the view
            outgoing = getRequests("outgoing", "active");
            populateTransfers(outgoing, outgoingRequests);

            // Get the incoming requests and populate the view
            incoming = getRequests("incoming", "active");
            populateTransfers(incoming, incomingRequests);
        }

        // On refresh button clicked
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Refresh the active transfer
            refresh();
        }
    }
}
