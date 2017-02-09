using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace EJC2016.Dal
{
    public class EquipeDal
    {
        string constr = @"Data Source=..\..\..\DataBase\ejc.db;Version=3;";

        public EquipeDal()
        {

        }

        public List<int> GetIdEquipes()
        {
            SQLiteConnection conn = new SQLiteConnection(constr);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteDataReader dr;

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT EQU_IDENTI FROM EJC_EQUIPE ORDER BY EQU_NOME";
            dr = cmd.ExecuteReader();
            DataTable dtb = new DataTable();
            dtb.Load(dr);

            List<int> lstIds = new List<int>();
            foreach (DataRow row in dtb.Rows)
            {
                int equipeId = Convert.ToInt32(row["EQU_IDENTI"]);
                lstIds.Add(equipeId);
            }

            dr.Close();
            conn.Close();
            return lstIds;
        }
    }
}
