using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EJC2016.Model;
using Microsoft.Reporting.WinForms;

namespace EJC2016.Forms
{
    public partial class EncontristasFullReport : Form
    {
        public EncontristasFullReport()
        {
            InitializeComponent();
        }

        string constr = @"Data Source=..\..\..\DataBase\ejc.db;Version=3;";

        private void EncontristasFullReport_Load(object sender, EventArgs e)
        {
            encontristasReportViewer.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = encontristasReportViewer.LocalReport;
            localReport.ReportPath = @"Report\EncontristasFullReport.rdlc";

            DataSet dsEncontrista = new DataSet("DataSetEncontristas");
            GetEncontristasData(ref dsEncontrista);

            ReportDataSource rdsEncontrista = new ReportDataSource();
            rdsEncontrista.Name = "DataSetEncontristas";
            rdsEncontrista.Value = dsEncontrista.Tables["ENCONTRISTA"];
            localReport.DataSources.Add(rdsEncontrista);
            this.encontristasReportViewer.RefreshReport();
        }

        private void GetEncontristasData(ref DataSet dataSet)
        {
            string sqlEncontristas = @"
                SELECT ECT.ECT_FOTO, ECT_IDENTI,
                       PES.PES_NOME, PES.PES_IDADE, PES.PES_EMAIL, PES.PES_EDE_IDENTI, PES.PES_DATNAS,
                       EDE.EDE_DESCRI, EDE.EDE_NUMERO, EDE.EDE_BAIRRO, EDE.EDE_TEL1, EDE.EDE_CEL1
                  FROM EJC_ENDERE EDE,
                       EJC_PESSOA PES,
                       EJC_ENCONT ECT
                 WHERE ECT.ECT_PES_IDENTI = PES.PES_IDENTI
                   AND PES.PES_EDE_IDENTI = EDE.EDE_IDENTI
                 ORDER BY PES.PES_NOME";

            using (SQLiteConnection con = new SQLiteConnection(constr))
            {
                con.Open();
                SQLiteDataReader dr;
                using (SQLiteCommand cmd = new SQLiteCommand(sqlEncontristas))
                {
                    cmd.Connection = con;
                    cmd.CommandText = sqlEncontristas;
                    dr = cmd.ExecuteReader();
                    DataTable dtb = new DataTable();
                    dtb.Load(dr);

                    List<EncontristasFullInfo> lstEncontristasFullInfo = new List<EncontristasFullInfo>();
                    foreach (DataRow row in dtb.Rows)
                    {
                        EncontristasFullInfo encontristasFullInfo = new EncontristasFullInfo();
                        encontristasFullInfo.Nome = (string)row["PES_NOME"];
                        encontristasFullInfo.Foto = DBNull.Value != row["ECT_FOTO"] ? (byte[])row["ECT_FOTO"] : null;
                        encontristasFullInfo.Endereco = DBNull.Value != row["EDE_DESCRI"] ? (string)row["EDE_DESCRI"] : string.Empty + DBNull.Value != row["EDE_NUMERO"] ? (" - Nº " + (string)(row["EDE_NUMERO"])) : "";
                        encontristasFullInfo.Bairro = DBNull.Value != row["EDE_BAIRRO"] ? (string)row["EDE_BAIRRO"] : string.Empty;
                        encontristasFullInfo.DataNasc = DBNull.Value != row["PES_DATNAS"] ? (string)row["PES_DATNAS"] : string.Empty;
                        encontristasFullInfo.Email = DBNull.Value != row["PES_EMAIL"] ? (string)row["PES_EMAIL"] : string.Empty;
                        encontristasFullInfo.Telefone = DBNull.Value != row["EDE_CEL1"] ? (string)(row["EDE_CEL1"]) : string.Empty + DBNull.Value != row["EDE_TEL1"] ? (" - Nº " + (string)(row["EDE_TEL1"])) : "";
                        lstEncontristasFullInfo.Add(encontristasFullInfo);
                    }

                    encontristasBindingSource.DataSource = lstEncontristasFullInfo;
                    encontristasBindingSource.ResetBindings(false);

                    using (SQLiteDataAdapter encontristasAdapter = new SQLiteDataAdapter(cmd))
                    {
                        encontristasAdapter.Fill(dataSet, "ENCONTRISTA");
                    }

                    dr.Close();
                    con.Close();
                }
            }

            return;
        }
    }
}
