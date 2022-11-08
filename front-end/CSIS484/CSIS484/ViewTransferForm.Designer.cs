namespace CSIS484
{
    partial class ViewTransferForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pbStatus = new System.Windows.Forms.ProgressBar();
            this.lblRequestingStore = new System.Windows.Forms.Label();
            this.lblRequestedStore = new System.Windows.Forms.Label();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblCompletedDate = new System.Windows.Forms.Label();
            this.lblItemId = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Requesting Store:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Requested Store:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Order Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Order Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Order Completed:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(12, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Item";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Item Id:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Quantity:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 267);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Status:";
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(12, 285);
            this.pbStatus.Maximum = 4;
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(224, 23);
            this.pbStatus.TabIndex = 9;
            // 
            // lblRequestingStore
            // 
            this.lblRequestingStore.AutoSize = true;
            this.lblRequestingStore.Location = new System.Drawing.Point(129, 9);
            this.lblRequestingStore.Name = "lblRequestingStore";
            this.lblRequestingStore.Size = new System.Drawing.Size(37, 15);
            this.lblRequestingStore.TabIndex = 10;
            this.lblRequestingStore.Text = "10000";
            // 
            // lblRequestedStore
            // 
            this.lblRequestedStore.AutoSize = true;
            this.lblRequestedStore.Location = new System.Drawing.Point(129, 34);
            this.lblRequestedStore.Name = "lblRequestedStore";
            this.lblRequestedStore.Size = new System.Drawing.Size(37, 15);
            this.lblRequestedStore.TabIndex = 11;
            this.lblRequestedStore.Text = "10001";
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Location = new System.Drawing.Point(129, 76);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(13, 15);
            this.lblOrderId.TabIndex = 12;
            this.lblOrderId.Text = "1";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(129, 102);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(65, 15);
            this.lblOrderDate.TabIndex = 13;
            this.lblOrderDate.Text = "01/01/2022";
            // 
            // lblCompletedDate
            // 
            this.lblCompletedDate.AutoSize = true;
            this.lblCompletedDate.Location = new System.Drawing.Point(129, 129);
            this.lblCompletedDate.Name = "lblCompletedDate";
            this.lblCompletedDate.Size = new System.Drawing.Size(22, 15);
            this.lblCompletedDate.TabIndex = 14;
            this.lblCompletedDate.Text = "---";
            // 
            // lblItemId
            // 
            this.lblItemId.AutoSize = true;
            this.lblItemId.Location = new System.Drawing.Point(129, 201);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(49, 15);
            this.lblItemId.TabIndex = 15;
            this.lblItemId.Text = "9999999";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(129, 225);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(13, 15);
            this.lblQuantity.TabIndex = 16;
            this.lblQuantity.Text = "1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(129, 267);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(66, 15);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "Completed";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(161, 327);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ViewTransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 362);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblItemId);
            this.Controls.Add(this.lblCompletedDate);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.lblOrderId);
            this.Controls.Add(this.lblRequestedStore);
            this.Controls.Add(this.lblRequestingStore);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ViewTransferForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private ProgressBar pbStatus;
        private Label lblRequestingStore;
        private Label lblRequestedStore;
        private Label lblOrderId;
        private Label lblOrderDate;
        private Label lblCompletedDate;
        private Label lblItemId;
        private Label lblQuantity;
        private Label lblStatus;
        private Button btnClose;
    }
}