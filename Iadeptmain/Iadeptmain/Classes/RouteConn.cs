using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iadeptmain.Classes
{
    class RouteConn
    {
        static OdbcConnection conn = new OdbcConnection("DRIVER= {MySQL ODBC 3.51 Driver}; server= localhost; Database= route; User=root; password=1234");
     // static OdbcConnection conn = new OdbcConnection("DRIVER= {MySQL ODBC 3.51 Driver}; server= localhost; Database= route; User=root");
       //static OdbcConnection conn = new OdbcConnection("DRIVER= {MySQL ODBC 5.3 ANSI Driver}; server= localhost; Database= route; User=root; password=1234");
       //static OdbcConnection conn = new OdbcConnection("DRIVER= {MySQL ODBC 5.3 ANSI Driver}; server= localhost; Database= route; User=root; password=1234");
     

        public static void executequery(CommandType type, string commandtext)
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandText = commandtext;
                cmd.Connection = conn;
                if (type == CommandType.StoredProcedure)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                }
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
            }
        }

        public static  DataTable getdata(CommandType type, string commandtext)
        {
            OdbcCommand cmd = new OdbcCommand();
            OdbcDataAdapter da = new OdbcDataAdapter();
            DataTable dt = new DataTable();
            if (type == CommandType.StoredProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                cmd.CommandType = CommandType.Text;
            }
            cmd.CommandText = commandtext;
            cmd.Connection = conn;
            cmd.CommandTimeout = 1000000;
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
            }
            catch { }
            return dt;
        }

    }
}
