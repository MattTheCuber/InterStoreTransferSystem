using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSIS484
{
    // View Transfer Form
    public partial class ViewTransferForm : Form
    {
        // Init transfer variable
        Transfer transfer;

        // ViewTransferForm takes in a Transfer
        public ViewTransferForm(Transfer transfer)
        {
            InitializeComponent();
           
            // Set the variable
            this.transfer = transfer;
            // Set the form name
            Text = $"Transfer {this.transfer.getId()}";

            // Populate the view labels
            lblRequestingStore.Text = Convert.ToString(this.transfer.getRequestingStore());
            lblRequestedStore.Text = Convert.ToString(this.transfer.getRequestedStore());
            lblOrderId.Text = Convert.ToString(this.transfer.getId());
            lblOrderDate.Text = this.transfer.getOrderDate();
            lblItemId.Text = Convert.ToString(this.transfer.getItemId());
            lblQuantity.Text = Convert.ToString(this.transfer.getQuantity());
            lblStatus.Text = Convert.ToString(this.transfer.getStatus());
            // Set the progress bar to the transfer status
            pbStatus.Value = this.transfer.getStatusValue();
        }

        // On close button clicked
        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }
    }
}
