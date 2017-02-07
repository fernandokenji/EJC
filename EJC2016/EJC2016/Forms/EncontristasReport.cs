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
    public partial class EncontristasReport : Form
    {
        public EncontristasReport()
        {
            InitializeComponent();
        }

        DataSet dsPessoa;

        private void EncontristasReport_Load(object sender, EventArgs e)
        {
            encontristasReportViewer.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = encontristasReportViewer.LocalReport;
            localReport.ReportPath = @"Report\EncontristasReport.rdlc";
            localReport.SubreportProcessing += LocalReport_SubreportProcessing;

            DataSet dsEncontrista = new DataSet("DataSetEncontristas");
            GetEncontristasData(ref dsEncontrista);
            dsPessoa = new DataSet("DataSetPessoa");
            GetEncontristasData(ref dsPessoa);

            localReport.DataSources.Clear();
            ReportDataSource rdsEncontrista = new ReportDataSource();
            rdsEncontrista.Name = "DataSetEncontristas";
            rdsEncontrista.Value = dsEncontrista.Tables["ECT_FOTO"];
            localReport.DataSources.Add(rdsEncontrista);

            ReportDataSource rdsPessoa = new ReportDataSource();
            rdsPessoa.Name = "DataSetPessoa";
            rdsPessoa.Value = dsPessoa.Tables["PES_NOME"];
            localReport.DataSources.Add(rdsPessoa);

            this.encontristasReportViewer.RefreshReport();
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            string customerId = e.Parameters["idEndereco"].Values[0];
            var expression = string.Format("PES_EDE_IDENTI = {0}", customerId.ToString());
            DataTable _newDataTable = dsPessoa.Tables["PES_EDE_IDENTI"].Select(expression, "PES_EDE_IDENTI DESC").CopyToDataTable();
            e.DataSources.Add(new ReportDataSource("DataSetPessoa", _newDataTable));
        }

        private void GetEncontristasData(ref DataSet dataSet)
        {
            string sqlEncontristas = @"
                SELECT ECT.ECT_FOTO, ECT_IDENTI,
                       PES.PES_NOME, PES.PES_IDADE, PES.PES_EMAIL, PES.PES_EDE_IDENTI,
                       EDE.EDE_DESCRI, EDE.EDE_NUMERO, EDE.EDE_BAIRRO, EDE.EDE_TEL1
                  FROM EJC_ENDERE EDE,
                       EJC_PESSOA PES,
                       EJC_ENCONT ECT
                 WHERE ECT.ECT_PES_IDENTI = PES.PES_IDENTI
                   AND PES.PES_EDE_IDENTI = EDE.EDE_IDENTI
                 ORDER BY PES.PES_NOME";

            string constr = @"Data Source=C:\Users\Fernando Kenji\Desktop\EJC2016\ejc.db;Version=3;";
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

                    using (SQLiteDataAdapter encontristasAdapter = new SQLiteDataAdapter(cmd))
                    {
                        encontristasAdapter.Fill(dataSet, "ECT_FOTO");
                        encontristasAdapter.Fill(dataSet, "PES_NOME");
                        encontristasAdapter.Fill(dataSet, "PES_IDADE");
                        encontristasAdapter.Fill(dataSet, "PES_EMAIL");
                        encontristasAdapter.Fill(dataSet, "PES_EDE_IDENTI");
                        encontristasAdapter.Fill(dataSet, "EDE_IDENTI");
                        encontristasAdapter.Fill(dataSet, "EDE_DESCRI");
                        encontristasAdapter.Fill(dataSet, "EDE_NUMERO");
                        encontristasAdapter.Fill(dataSet, "EDE_BAIRRO");
                        encontristasAdapter.Fill(dataSet, "EDE_TEL1");
                    }

                    dr.Close();
                    con.Close();
                }
            }

            return;
        }

        public EnderecoInfo GetEndereco(int idEndereco)
        {
            string constr = @"Data Source=C:\Users\Fernando Kenji\Desktop\EJC2016\ejc.db;Version=3;";

            EnderecoInfo endereco = null;
            string sqlEndereco = "SELECT * FROM EJC_ENDERE WHERE EDE_IDENTI = @ID";
            using (SQLiteConnection con = new SQLiteConnection(constr))
            {
                con.Open();
                SQLiteDataReader dr;
                using (SQLiteCommand cmd = new SQLiteCommand(sqlEndereco))
                {
                    cmd.Connection = con;
                    cmd.CommandText = sqlEndereco;
                    cmd.Parameters.AddWithValue("@ID", idEndereco);
                    dr = cmd.ExecuteReader();
                    DataTable dtb = new DataTable();
                    dtb.Load(dr);

                    foreach (DataRow row in dtb.Rows)
                    {
                        endereco = new EnderecoInfo();
                        endereco.Id = Convert.ToInt32(row["EDE_IDENTI"]);
                        endereco.Endereco = (string)row["EDE_DESCRI"];
                        endereco.Numero = Convert.ToInt32(row["EDE_NUMERO"]);
                        endereco.Bairro = (string)(row["EDE_BAIRRO"]);
                    }
                }

                dr.Close();
                con.Close();
            }

            return endereco;
        }
    }
}
