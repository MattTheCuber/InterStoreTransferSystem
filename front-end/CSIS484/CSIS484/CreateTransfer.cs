using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CSIS484
{
    // Create Transfer form
    public partial class CreateTransfer : Form
    {
        // Init variables
        string storeId;
        string encryptedPassword;
        string itemId;
        JObject res;

        // Main form takes in request credentials, item data, and store items data
        public CreateTransfer(string storeId, string encryptedPassword, string itemId, string itemName, JObject res)
        {
            InitializeComponent();

            // Store the credentials, item data, and store items data 
            this.storeId = storeId;
            this.encryptedPassword = encryptedPassword;
            this.itemId = itemId;
            this.res = res;

            // Update the view with the item data
            lblItemId.Text = itemId;
            lblItemName.Text = itemName;

            // Populate the list view
            populateListView();
        }

        // Populates the list view for this form
        private void populateListView()
        {
            // For each record in the store items data
            foreach (JObject record in res["data"])
            {
                // Create a list view item with the store id and quantity on hand
                ListViewItem item = new ListViewItem(Convert.ToString(record["StoreId"]));
                item.SubItems.Add(Convert.ToString(record["Quantity"]));
                // Add the item to the list view
                list.Items.Add(item);
            }
        }

        // On submit transfer request button clicked
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get the quantity requested
            int quantity = (int)numQuantity.Value;

            // If a store is selected in the list view
            if (list.SelectedItems.Count == 1)
            {
                // If the quantity on hand is less than the requested quantity
                if (Convert.ToInt16(list.SelectedItems[0].SubItems[1].Text) < quantity)
                {
                    // Alert the user that they cannot request more items than the store has in stock, then return
                    MessageBox.Show($"You cannot request more items than this store has on hand", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Get the requested store id
                string requestedStoreId = list.SelectedItems[0].Text;

                // Create a confirmation message
                string message = $"Are you sure you want to request {quantity}x {itemId} from Store #{requestedStoreId}";
                // Display a confirmation dialog
                DialogResult res = MessageBox.Show(message, "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                // If the user selects ok
                if (res == DialogResult.OK)
                {
                    // Create a transfer request
                    createTransfer(quantity, requestedStoreId);
                    // Close this form
                    this.Close();
                }
            }
            else
            {
                // Else alert the user that they must select a store
                MessageBox.Show($"Please select a store to transfer from", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Creates a transfer request
        private void createTransfer(int quantity, string requestedStoreId)
        {
            // Create the URL to create the request using supplied requested store id, item id, and quantity
            string parameters = $"?storeId={storeId}&key={encryptedPassword}&requestedStoreId={requestedStoreId}&itemId={itemId}&quantity={quantity}";
            string url = $"http://localhost:3030/v1/requests/create{parameters}";

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
            }
        }

        // On cancel button clicked
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close this form
            this.Close();
        }
    }
}
