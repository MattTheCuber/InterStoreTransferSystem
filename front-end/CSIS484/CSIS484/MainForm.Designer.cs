namespace CSIS484
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outgoingRequests = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.orderDate = new System.Windows.Forms.ColumnHeader();
            this.requested = new System.Windows.Forms.ColumnHeader();
            this.status = new System.Windows.Forms.ColumnHeader();
            this.itemId = new System.Windows.Forms.ColumnHeader();
            this.quantity = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.incomingRequests = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // outgoingRequests
            // 
            this.outgoingRequests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.orderDate,
            this.requested,
            this.status,
            this.itemId,
            this.quantity});
            this.outgoingRequests.FullRowSelect = true;
            this.outgoingRequests.Location = new System.Drawing.Point(12, 38);
            this.outgoingRequests.Name = "outgoingRequests";
            this.outgoingRequests.Size = new System.Drawing.Size(619, 265);
            this.outgoingRequests.TabIndex = 0;
            this.outgoingRequests.UseCompatibleStateImageBehavior = false;
            this.outgoingRequests.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "Id";
            this.id.Width = 40;
            // 
            // orderDate
            // 
            this.orderDate.Text = "Order Date";
            this.orderDate.Width = 160;
            // 
            // requested
            // 
            this.requested.Text = "Requested Store";
            this.requested.Width = 100;
            // 
            // status
            // 
            this.status.Text = "Status";
            this.status.Width = 120;
            // 
            // itemId
            // 
            this.itemId.Text = "Item ID";
            this.itemId.Width = 120;
            // 
            // quantity
            // 
            this.quantity.Text = "Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Outgoing Requests";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Incoming Requests";
            // 
            // incomingRequests
            // 
            this.incomingRequests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.incomingRequests.FullRowSelect = true;
            this.incomingRequests.Location = new System.Drawing.Point(12, 339);
            this.incomingRequests.Name = "incomingRequests";
            this.incomingRequests.Size = new System.Drawing.Size(619, 265);
            this.incomingRequests.TabIndex = 2;
            this.incomingRequests.UseCompatibleStateImageBehavior = false;
            this.incomingRequests.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Order Date";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Requested Store";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Item ID";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Quantity";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 618);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.incomingRequests);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outgoingRequests);
            this.Name = "MainForm";
            this.Text = "Inter-Store Transfer System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView outgoingRequests;
        private ColumnHeader id;
        private ColumnHeader requested;
        private ColumnHeader status;
        private ColumnHeader itemId;
        private ColumnHeader quantity;
        private ColumnHeader orderDate;
        private Label label1;
        private Label label2;
        private ListView incomingRequests;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}