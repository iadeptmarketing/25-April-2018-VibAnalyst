using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServerCe.Client;
//using System.Data.SqlServerCe;
using Iadeptmain.GlobalClasses;
namespace Iadeptmain.GlobalClasses
{
    class SqlceClass
    {
        public static SqlCeConnection con;
        public static  void executequery(CommandType type, string commandtext)
        {
            try
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = commandtext;
                con = new SqlCeConnection("Data Source=" + PublicClass.finalpath);               
                cmd.Connection = con;
                if (type == CommandType.StoredProcedure)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                }
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                con.Close();
            }
        }

        public static DataTable getdata(CommandType type, string commandtext, string ConnStr)
        {
            SqlCeCommand cmd = new SqlCeCommand();
            SqlCeDataAdapter da = new SqlCeDataAdapter();
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
            con = new SqlCeConnection(ConnStr);
            cmd.Connection = con;
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
