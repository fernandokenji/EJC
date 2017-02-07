using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJC2016.Model
{
    public class Utils
    {
        public static String NULL_SOAP_DATE = "0001-01-01T00:00:00";
        public static String NULL_SQLITE_DATE = "0001-01-01 00:00:00";

        public Utils()
        {
        }

        /**
         * Converte uma data vinda de um objecto SOAP para o formato SQLite, para gravação no banco de dados
         * @param soapDate Data no formato yyyy-MM-ddThh:mm:ss
         * @return Data no formato yyyy-MM-dd hh:mm:ss
         */
        public static String fromSOAPToSQLiteDate(String soapDate)
        {
            return soapDate.Replace("T", " ");
        }

        /**
         * Converte uma data vinda do SQLite, para o formato usado em objetos SOAP
         * @param sqliteDate Data no formato YYYY-MM-DD HH:MM:SS
         * @return Data no formato yyyy-MM-ddThh:mm:ss
         */
        public static String fromSQLiteToSOAPDate(String sqliteDate)
        {
            return sqliteDate.Replace(" ", "T");
        }


        /**
         * Retorna a data no formato utilizado pelo SQLite
         * @param date
         * @return Data no formato yyyy-MM-dd hh:mm:ss
         */
        public static String fromDateToSQLiteDate(String date)
        {
            if (date == null) return "";
            try
            {
                return String.Format("yyyy-MM-dd HH:mm:ss", date);
            }
            catch (Exception)
            {
                return null;
            }

        }

        /**
         * Retorna a data no formato utilizado pelo protocolo SOAP
         * @param date
         * @return Data no formato yyyy-MM-ddThh:mm:ss
         */
        public static String fromDateToSOAPDate(DateTime date)
        {
            if (date == null) return NULL_SOAP_DATE;
            try
            {
                return String.Format("yyyy-MM-dd'T'HH:mm:ss", date);
            }
            catch (Exception)
            {
                return null;
            }

        }

        /**
         * Verifica se o valor passado trata-se de uma data no formato SOAP
         * @param soapDate
         * @return
         */
        public static Boolean isSOAPDate(String soapDate)
        {
            if (soapDate == null) return false;
            if (soapDate.Trim().Length < 19) return false;
            try
            {
                String.Format("yyyy-MM-dd'T'HH:mm:ss", soapDate);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
