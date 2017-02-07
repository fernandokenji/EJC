namespace EJC2016.Forms
{
    partial class AudioReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.equipeReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.equipistasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.equipesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.equipistasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // equipeReportViewer
            // 
            this.equipeReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSetEquipistasFull";
            reportDataSource3.Value = this.equipistasBindingSource;
            this.equipeReportViewer.LocalReport.DataSources.Add(reportDataSource3);
            this.equipeReportViewer.LocalReport.ReportEmbeddedResource = "EJC2016.Report.EquipeReport.rdlc";
            this.equipeReportViewer.Location = new System.Drawing.Point(0, 0);
            this.equipeReportViewer.Margin = new System.Windows.Forms.Padding(2);
            this.equipeReportViewer.Name = "equipeReportViewer";
            this.equipeReportViewer.Size = new System.Drawing.Size(679, 608);
            this.equipeReportViewer.TabIndex = 0;
            // 
            // equipistasBindingSource
            // 
            this.equipistasBindingSource.DataSource = typeof(EJC2016.Model.EquipistasFullInfo);
            // 
            // equipesBindingSource
            // 
            this.equipesBindingSource.DataSource = typeof(EJC2016.Model.EquipesInfoFull);
            // 
            // AudioReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 608);
            this.Controls.Add(this.equipeReportViewer);
            this.Name = "AudioReport";
            this.Text = "Áudio Visual";
            this.Load += new System.EventHandler(this.EncontristasReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.equipistasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer equipeReportViewer;
        private System.Windows.Forms.BindingSource equipistasBindingSource;
        private System.Windows.Forms.BindingSource equipesBindingSource;
    }
}