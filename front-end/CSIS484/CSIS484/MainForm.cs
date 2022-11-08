using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text;
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

            // Set the form name
            Text = $"Inter-Store Transfer System: {storeId}";
            // Store the credentials
            this.storeId = storeId;
            this.encryptedPassword = encryptedPassword;

            // Get the outgoing requests and populate the view
            outgoing = getRequests("outgoing", "active");
            populateTransfers(outgoing, outgoingRequests);

            // Get the incoming requests and populate the view
            incoming = getRequests("incoming", "active");
            populateTransfers(incoming, incomingRequests);
        }

        // Gets the transfer requests of any type
        private Transfer[] getRequests(string type, string status)
        {
            // Create the URL to get the requests of the type and status specified
            string url = $"http://localhost:3030/v1/requests?storeId={storeId}&key={encryptedPassword}&type={type}&status={status}";

            // Make the HTTP request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                // Convert the result to a JObject
                JObject res = JObject.Parse(reader.ReadToEnd());
                Console.WriteLine(res);
                // If the result is valid
                if (res != null && (res["data"] as JArray)?.Count > 0)
                {
                    // Init transfers array
                    Transfer[] transfers = new Transfer[(res["data"] as JArray).Count];
                    // For each transfer
                    int index = 0;
                    foreach (JObject record in res["data"])
                    {
                        // Conver to Transfer object and add to the array
                        transfers[index] = new Transfer(record);
                        index++;
                    }
                    return transfers;
                }
                else
                {
                    return new Transfer[0];
                }
            }
        }

        // Populates a ListView with transfers
        private void populateTransfers(Transfer[] transfers, System.Windows.Forms.ListView list)
        {
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
                ViewTransferForm transferForm = new ViewTransferForm(transfer);
                transferForm.Show();
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
                ViewTransferForm transferForm = new ViewTransferForm(transfer);
                transferForm.Show();
            }
        }
    }
}
