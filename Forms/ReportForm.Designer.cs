namespace eventmanagementsystem.Forms
{
    partial class ReportForm
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
            this.lblEvents = new System.Windows.Forms.Label();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.lblBookings = new System.Windows.Forms.Label();
            this.lblPayments = new System.Windows.Forms.Label();
            this.lblVendors = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVenues = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEvents
            // 
            this.lblEvents.AutoSize = true;
            this.lblEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvents.Location = new System.Drawing.Point(29, 138);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Size = new System.Drawing.Size(128, 24);
            this.lblEvents.TabIndex = 0;
            this.lblEvents.Text = "Total Events:0";
            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomers.Location = new System.Drawing.Point(29, 193);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(161, 24);
            this.lblCustomers.TabIndex = 1;
            this.lblCustomers.Text = "Total Customers:0";
            // 
            // lblBookings
            // 
            this.lblBookings.AutoSize = true;
            this.lblBookings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookings.Location = new System.Drawing.Point(29, 247);
            this.lblBookings.Name = "lblBookings";
            this.lblBookings.Size = new System.Drawing.Size(149, 24);
            this.lblBookings.TabIndex = 2;
            this.lblBookings.Text = "Total Bookings:0";
            // 
            // lblPayments
            // 
            this.lblPayments.AutoSize = true;
            this.lblPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayments.Location = new System.Drawing.Point(29, 300);
            this.lblPayments.Name = "lblPayments";
            this.lblPayments.Size = new System.Drawing.Size(153, 24);
            this.lblPayments.TabIndex = 3;
            this.lblPayments.Text = "Total Payments:0";
            // 
            // lblVendors
            // 
            this.lblVendors.AutoSize = true;
            this.lblVendors.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendors.Location = new System.Drawing.Point(29, 350);
            this.lblVendors.Name = "lblVendors";
            this.lblVendors.Size = new System.Drawing.Size(143, 24);
            this.lblVendors.TabIndex = 4;
            this.lblVendors.Text = "Total Vendors:0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(33, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 59);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report Summary";
            // 
            // lblVenues
            // 
            this.lblVenues.AutoSize = true;
            this.lblVenues.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVenues.Location = new System.Drawing.Point(29, 397);
            this.lblVenues.Name = "lblVenues";
            this.lblVenues.Size = new System.Drawing.Size(128, 24);
            this.lblVenues.TabIndex = 6;
            this.lblVenues.Text = "Total Venue:0";
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "Customer Report",
            "Active Customer Report",
            "Event Report",
            "Booking Report",
            "Payment Report",
            "Vendor Report",
            "Venue Report",
            "Customer Booking Report",
            "Event Booking Report",
            "Venue Capacity Report"});
            this.cmbReportType.Location = new System.Drawing.Point(318, 38);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(121, 21);
            this.cmbReportType.TabIndex = 7;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(397, 72);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(146, 25);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(240, 116);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(725, 355);
            this.dgvReport.TabIndex = 10;
            this.dgvReport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReport_CellContentClick);
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.Location = new System.Drawing.Point(790, 35);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(125, 34);
            this.btnExportPDF.TabIndex = 11;
            this.btnExportPDF.Text = "Export as PDF";
            this.btnExportPDF.UseVisualStyleBackColor = true;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 495);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.lblVenues);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblVendors);
            this.Controls.Add(this.lblPayments);
            this.Controls.Add(this.lblBookings);
            this.Controls.Add(this.lblCustomers);
            this.Controls.Add(this.lblEvents);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEvents;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.Label lblBookings;
        private System.Windows.Forms.Label lblPayments;
        private System.Windows.Forms.Label lblVendors;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVenues;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnExportPDF;
    }
}