using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSIS484
{
    // Transfer class used to convert JSON objects to easy-to-use objects.
    public class Transfer
    {
        // Status variable to store list of status types
        string[] STATUS = { "Validating Stock", "Stock Verified", "Shipped", "Received", "Cancelled" };

        // Init variables
        int id;
        string orderDate;
        int requestingStore;
        int requestedStore;
        int itemId;
        int quantity;
        int statusValue;
        string status;
        string completedDateTime;

        // Constructor takes in JObject from HTTP requests
        public Transfer(JObject transferData)
        {
            // Pull and convert data from the JObject
            id = Convert.ToInt32(transferData["TransferId"]);
            orderDate = (string)transferData["OrderDateTime"];
            requestingStore = Convert.ToInt32(transferData["RequestingStoreId"]);
            requestedStore = Convert.ToInt32(transferData["RequestedStoreId"]);
            itemId = Convert.ToInt32(transferData["ItemId"]);
            quantity = Convert.ToInt32(transferData["Quantity"]);
            statusValue = Convert.ToInt32(transferData["TransferStatus"]);
            status = STATUS[statusValue];
            completedDateTime = (string)transferData["CompletedDateTime"];
        }

        // Public getters and setters
        public int getId()
        {
            return id;
        }
        public string getOrderDate()
        {
            return orderDate;
        }
        public int getRequestingStore()
        {
            return requestingStore;
        }
        public int getRequestedStore()
        {
            return requestedStore;
        }
        public int getItemId()
        {
            return itemId;
        }
        public int getQuantity()
        {
            return quantity;
        }
        public string getStatus()
        {
            return status;
        }
        public int getStatusValue()
        {
            return statusValue;
        }
        public string getCompletedDateTime()
        {
            return completedDateTime;
        }

        // Sets the status
        public void setStatusValue(int newStatus)
        {
            // Sets the status value and string
            this.statusValue = newStatus;
            this.status = STATUS[newStatus];

            // If the new status is completed
            if (newStatus == 3 || newStatus == 4)
            {
                // Set the completed date to now
                this.completedDateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            }
        }
    }
}
