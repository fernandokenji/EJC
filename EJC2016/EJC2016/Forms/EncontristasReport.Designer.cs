namespace EJC2016.Forms
{
    partial class EncontristasReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.encontristasReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // encontristasReportViewer
            // 
            this.encontristasReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetEncontrista";
            reportDataSource1.Value = null;
            this.encontristasReportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.encontristasReportViewer.LocalReport.ReportEmbeddedResource = "EJC2016.Report.EncontristasReport.rdlc";
            this.encontristasReportViewer.Location = new System.Drawing.Point(0, 0);
            this.encontristasReportViewer.Margin = new System.Windows.Forms.Padding(2);
            this.encontristasReportViewer.Name = "encontristasReportViewer";
            this.encontristasReportViewer.Size = new System.Drawing.Size(679, 608);
            this.encontristasReportViewer.TabIndex = 0;
            // 
            // EncontristasReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 608);
            this.Controls.Add(this.encontristasReportViewer);
            this.Name = "EncontristasReport";
            this.Text = "EncontristasReport";
            this.Load += new System.EventHandler(this.EncontristasReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer encontristasReportViewer;
    }
}