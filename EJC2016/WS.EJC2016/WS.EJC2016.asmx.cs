using System;
using System.Data.SQLite;
using System.Text;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Collections.Generic;
using System.Data;
using EJC2016.Model;

namespace WS.EJC2016
{
    /// <summary>
    /// Summary description for Mobile
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class EJC : System.Web.Services.WebService
    {
        String strConn = @"Data Source=C:\Users\Fernando Kenji\Desktop\EJC2016\ejc.db";

        [WebMethod]
        public string HelloWorld()
        {
            return "Bem Vindo!";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EnviaEquipes(String str_equipes)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            SQLiteConnection conn = new SQLiteConnection(strConn);
            SQLiteCommand cmd = new SQLiteCommand();

            conn.Open();
            cmd.Connection = conn;

            ListSincronize sync = default(ListSincronize);
            sync = js.Deserialize<ListSincronize>(str_equipes);

            for (int i = 0; i < sync.lstEquipes.Count; i++)
            {
                SQLiteDataReader dr;
                cmd.CommandText = "INSERT INTO EJC_EQUIPE (EQU_IDENTI, EQU_NOME, EQU_FRASE, EQU_DATCRI, EQU_DATALT) VALUES (@EQU_IDENTI, @EQU_NOME, @EQU_FRASE, @EQU_DATCRI, @EQU_DATALT)";
                cmd.Parameters.AddWithValue("@EQU_IDENTI", sync.lstEquipes[0].getId());
                cmd.Parameters.AddWithValue("@EQU_NOME", sync.lstEquipes[0].getNome());
                cmd.Parameters.AddWithValue("@EQU_FRASE", sync.lstEquipes[0].getFrase());
                cmd.Parameters.AddWithValue("@EQU_DATCRI", sync.lstEquipes[0].getCreateDate());
                cmd.Parameters.AddWithValue("@EQU_DATALT", sync.lstEquipes[0].getUpdateDate());
                dr = cmd.ExecuteReader();
                dr.Close();
            }
            conn.Close();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EnviaEquipistas(String str_equipistas)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            SQLiteConnection conn = new SQLiteConnection(strConn);
            SQLiteCommand cmd = new SQLiteCommand();

            conn.Open();
            cmd.Connection = conn;

            ListSincronize sync = default(ListSincronize);
            sync = js.Deserialize<ListSincronize>(str_equipistas);

            for (int i = 0; i < sync.lstEquipistas.Count; i++)
            {
                SQLiteDataReader dr;
                cmd.CommandText = "UPDATE MOB_CONTA SET CON_COD_PAG = @CON_COD_PAG, CON_DATALT = @CON_DATALT WHERE CON_PED_ID = @CON_PED_ID AND CON_SERIAL_DEVICE = @CON_SERIAL_DEVICE";
                //cmd.Parameters.AddWithValue("@CON_ID", sync.lstEquipistas[0].getOrderId());
                //cmd.Parameters.AddWithValue("@CON_TOTAL", sync.lstEquipistas[0].getTotal());
                //cmd.Parameters.AddWithValue("@CON_DATALT", sync.lstEquipistas[0].getUpdateDateTime());
                //cmd.Parameters.AddWithValue("@CON_PED_ID", sync.lstEquipistas[0].getOrderId());
                //cmd.Parameters.AddWithValue("@CON_COD_PAG", sync.lstEquipistas[0].getCodePayment());
                //cmd.Parameters.AddWithValue("@CON_SERIAL_DEVICE", sync.lstEquipistas[0].getSerialDevice());
                dr = cmd.ExecuteReader();
                dr.Close();
            }
            conn.Close();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void EnviaEncontristas(String str_encontristas)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            SQLiteConnection conn = new SQLiteConnection(strConn);
            SQLiteCommand cmd = new SQLiteCommand();

            conn.Open();
            cmd.Connection = conn;

            ListSincronize sync = default(ListSincronize);
            sync = js.Deserialize<ListSincronize>(str_encontristas);

            for (int i = 0; i < sync.lstEncontristas.Count; i++)
            {
                SQLiteDataReader dr;
                cmd.CommandText = "UPDATE MOB_CONTA SET CON_COD_PAG = @CON_COD_PAG, CON_DATALT = @CON_DATALT WHERE CON_PED_ID = @CON_PED_ID AND CON_SERIAL_DEVICE = @CON_SERIAL_DEVICE";
                //cmd.Parameters.AddWithValue("@CON_ID", sync.lstEncontristas[0].getOrderId());
                //cmd.Parameters.AddWithValue("@CON_TOTAL", sync.lstEncontristas[0].getTotal());
                //cmd.Parameters.AddWithValue("@CON_DATALT", sync.lstEncontristas[0].getUpdateDateTime());
                //cmd.Parameters.AddWithValue("@CON_PED_ID", sync.lstEncontristas[0].getOrderId());
                //cmd.Parameters.AddWithValue("@CON_COD_PAG", sync.lstEncontristas[0].getCodePayment());
                //cmd.Parameters.AddWithValue("@CON_SERIAL_DEVICE", sync.lstEncontristas[0].getSerialDevice());
                dr = cmd.ExecuteReader();
                dr.Close();
            }
            conn.Close();
        }


    }
}