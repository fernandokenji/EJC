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
    public partial class AudioReport : Form
    {
        int equipeId = 0;
        public AudioReport(int equipeId)
        {
            InitializeComponent();
            this.equipeId = equipeId;
        }

        string constr = @"Data Source=..\..\..\DataBase\ejc.db;Version=3;";

        private void EncontristasReport_Load(object sender, EventArgs e)
        {
            equipeReportViewer.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = equipeReportViewer.LocalReport;
            localReport.ReportPath = @"Report\AudioReport.rdlc";

            DataSet dsEquipe = new DataSet("DataSetEquipe");
            GetEquipes(ref dsEquipe);
            ReportDataSource rdsEquipe = new ReportDataSource();
            rdsEquipe.Name = "DataSetEquipe";
            rdsEquipe.Value = dsEquipe.Tables["EQUIPE"];
            localReport.DataSources.Add(rdsEquipe);

            List<ReportParameter> parameters = new List<ReportParameter>();
            for (int i = 0; i < dsEquipe.Tables["EQUIPE"].Rows.Count; i++)
            {
                ReportParameter parameter = new ReportParameter("Nome", dsEquipe.Tables["EQUIPE"].Rows[i]["EQU_NOME"].ToString());
                parameters.Add(parameter);
                parameter = new ReportParameter("Frase", dsEquipe.Tables["EQUIPE"].Rows[i]["EQU_FRASE"].ToString());
                parameters.Add(parameter);
            }

            localReport.SetParameters(parameters);

            DataSet dsEquipistas = new DataSet("DataSetEquipistasFull");
            GetEquipistasData(ref dsEquipistas);

            ReportDataSource rdsEquipista = new ReportDataSource();
            rdsEquipista.Name = "DataSetEquipistasFull";
            rdsEquipista.Value = dsEquipistas.Tables["EQUIPISTA"];
            localReport.DataSources.Add(rdsEquipista);

            this.equipeReportViewer.RefreshReport();
        }

        private void GetEquipes(ref DataSet dataSet)
        {
            string sqlEquipe = @" SELECT EQU_NOME, EQU_FRASE FROM EJC_EQUIPE WHERE EQU_IDENTI = @ID";

            List<EquipesInfoFull> lstEquipesInfoFull = new List<EquipesInfoFull>();

            using (SQLiteConnection con = new SQLiteConnection(constr))
            {
                con.Open();
                SQLiteDataReader dr;
                using (SQLiteCommand cmd = new SQLiteCommand(sqlEquipe))
                {
                    cmd.Connection = con;
                    cmd.CommandText = sqlEquipe;
                    cmd.Parameters.Add(new SQLiteParameter("@ID", equipeId));
                    dr = cmd.ExecuteReader();
                    DataTable dtb = new DataTable();
                    dtb.Load(dr);

                    foreach (DataRow row in dtb.Rows)
                    {
                        EquipesInfoFull equipesFullInfo = new EquipesInfoFull();
                        equipesFullInfo.Equipe = (string)row["EQU_NOME"];
                        equipesFullInfo.FraseEquipe = (string)row["EQU_FRASE"];
                        lstEquipesInfoFull.Add(equipesFullInfo);
                    }

                    equipesBindingSource.DataSource = lstEquipesInfoFull;
                    equipesBindingSource.ResetBindings(false);

                    using (SQLiteDataAdapter encontristasAdapter = new SQLiteDataAdapter(cmd))
                    {
                        encontristasAdapter.Fill(dataSet, "EQUIPE");
                    }

                    dr.Close();
                    con.Close();
                }
            }

            return;
        }

        private void GetEquipistasData(ref DataSet dataSet)
        {
            string sqlEquipistas = @"
                SELECT PES.PES_NOME, PES.PES_EMAIL, PES.PES_DATNAS, EDE.EDE_TEL1, EDE.EDE_CEL1
                  FROM EJC_ENDERE EDE,
                       EJC_PESSOA PES,
                       EJC_EQUIPI EQP
                 WHERE EQP.EQP_PES_IDENTI = PES.PES_IDENTI
                   AND PES.PES_EDE_IDENTI = EDE.EDE_IDENTI
                   AND EQP.EQP_EQU_IDENTI = @ID
                 ORDER BY PES.PES_NOME";

            List<EquipistasFullInfo> lstEquipistasFullInfo = new List<EquipistasFullInfo>();

            using (SQLiteConnection con = new SQLiteConnection(constr))
            {
                con.Open();
                SQLiteDataReader dr;
                using (SQLiteCommand cmd = new SQLiteCommand(sqlEquipistas))
                {
                    cmd.Connection = con;
                    cmd.CommandText = sqlEquipistas;
                    cmd.Parameters.Add(new SQLiteParameter("@ID", equipeId));
                    dr = cmd.ExecuteReader();
                    DataTable dtb = new DataTable();
                    dtb.Load(dr);

                    foreach (DataRow row in dtb.Rows)
                    {
                        EquipistasFullInfo equipistasFullInfo = new EquipistasFullInfo();
                        equipistasFullInfo.Nome = (string)row["PES_NOME"];
                        equipistasFullInfo.DataNasc = DBNull.Value != row["PES_DATNAS"] ? (string)row["PES_DATNAS"] : "";
                        equipistasFullInfo.Email = DBNull.Value != row["PES_EMAIL"] ? (string)row["PES_EMAIL"] : "";
                        equipistasFullInfo.Telefone = DBNull.Value != row["EDE_CEL1"] ? (string)(row["EDE_CEL1"]) : string.Empty;
                        lstEquipistasFullInfo.Add(equipistasFullInfo);
                    }

                    equipistasBindingSource.DataSource = lstEquipistasFullInfo;
                    equipistasBindingSource.ResetBindings(false);

                    using (SQLiteDataAdapter encontristasAdapter = new SQLiteDataAdapter(cmd))
                    { 
                        encontristasAdapter.Fill(dataSet, "EQUIPISTA");
                    }

                    dr.Close();
                    con.Close();
                }
            }

            return;
        }
    }
}
