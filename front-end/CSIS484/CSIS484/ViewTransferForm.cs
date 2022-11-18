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
    // View Transfer Form
    public partial class ViewTransferForm : Form
    {
        // Init variables
        string storeId;
        string encryptedPassword;
        Transfer transfer;
        bool outgoing;

        // ViewTransferForm takes in a Transfer
        public ViewTransferForm(string storeId, string encryptedPassword, Transfer transfer, bool outgoing)
        {
            InitializeComponent();

            // Store the credentials
            this.storeId = storeId;
            this.encryptedPassword = encryptedPassword;
            // Set the variables
            this.transfer = transfer;
            this.outgoing = outgoing;
            // Set the form name
            Text = $"Transfer {this.transfer.getId()}";

            // Populate the view labels
            lblRequestingStore.Text = Convert.ToString(transfer.getRequestingStore());
            lblRequestedStore.Text = Convert.ToString(transfer.getRequestedStore());
            lblOrderId.Text = Convert.ToString(transfer.getId());
            lblOrderDate.Text = transfer.getOrderDate();
            lblItemId.Text = Convert.ToString(transfer.getItemId());
            lblQuantity.Text = Convert.ToString(transfer.getQuantity());
            lblStatus.Text = Convert.ToString(transfer.getStatus());
            // Set the progress bar to the transfer status
            pbStatus.Value = Math.Min(3, transfer.getStatusValue());

            if (transfer.getStatusValue() == 0)
            {
                btnUpdateTransfer.Visible = true;
                if (outgoing)
                {
                    btnUpdateTransfer.Text = "Cancel Request";
                }
                else
                {
                    btnUpdateTransfer.Text = "Validate Stock";
                }
            }
            else if (transfer.getStatusValue() == 1 && !outgoing)
            {
                btnUpdateTransfer.Visible = true;
                btnUpdateTransfer.Text = "Mark Shipped";
            }
            else if (transfer.getStatusValue() == 2 && outgoing)
            {
                btnUpdateTransfer.Visible = true;
                btnUpdateTransfer.Text = "Receive";
            }
        }

        // On close button clicked
        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }

        private void btnUpdateTransfer_Click(object sender, EventArgs e)
        {
            if (transfer.getStatusValue() == 0)
            {
                if (outgoing)
                {
                    updateTransfer(4);
                    transfer.setStatusValue(4);

                    btnUpdateTransfer.Visible = false;
                    lblCompletedDate.Text = transfer.getCompletedDateTime();
                }
                else
                {
                    updateTransfer(1);
                    transfer.setStatusValue(1);

                    btnUpdateTransfer.Text = "Mark Shipped";
                }
            }
            else if (transfer.getStatusValue() == 1 && !outgoing)
            {
                updateTransfer(2);
                transfer.setStatusValue(2);

                btnUpdateTransfer.Visible = false;
            }
            else if (transfer.getStatusValue() == 2 && outgoing)
            {
                updateTransfer(3);
                transfer.setStatusValue(3);

                btnUpdateTransfer.Visible = false;
                lblCompletedDate.Text = transfer.getCompletedDateTime();
            }

            lblStatus.Text = Convert.ToString(transfer.getStatus());
            pbStatus.Value = Math.Min(3, transfer.getStatusValue());
        }

        private void updateTransfer(int newStatus)
        {
            // Create the URL to get update with supplied status
            string url = $"http://localhost:3030/v1/requests/update/{newStatus}?storeId={storeId}&key={encryptedPassword}&transferId={transfer.getId()}";

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
    }
}
