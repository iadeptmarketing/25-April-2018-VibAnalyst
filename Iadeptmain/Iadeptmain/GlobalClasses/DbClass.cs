using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Data.Odbc;
using Iadeptmain.GlobalClasses;
namespace Iadeptmain.GlobalClasses
{
  public  class DbClass
  {
      private string strErrMsg = "";
      private string strParty;
      private string strorder;
     
         #region Insert,Update Record through Stored procedure
        public static void executequery(CommandType type, string commandtext, OdbcParameter[] para)
        {
           
            
            OdbcCommand cmd = new OdbcCommand();
         
            cmd.Connection = PublicClass.conn;
            if (type == CommandType.StoredProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                cmd.CommandType = CommandType.Text;
            }
            cmd.Parameters.AddRange(para);
            PublicClass.conn.Open();
            cmd.ExecuteNonQuery();
            PublicClass.conn.Close();
           
        }
        #endregion
        #region Insert,Update Record through Command
        public static void executequery(CommandType type, string commandtext)
        {
            try
            {
                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandText = commandtext;
                cmd.Connection = PublicClass.conn;
                if (type == CommandType.StoredProcedure)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                }
                PublicClass.conn.Open();
                cmd.ExecuteNonQuery();
                PublicClass.conn.Close();
            }
            catch
            {
                PublicClass.conn.Close();
            }
        }

        #endregion
        #region Get Record through Command with parameter
        public static DataTable getdata(CommandType type, string commandtext, OdbcParameter[] para)
        {
            OdbcCommand cmd = new OdbcCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
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
            cmd.Parameters.AddRange(para);
            cmd.Connection = PublicClass.conn;
            cmd.CommandTimeout = 99999;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        #endregion

        #region Get Record through Command
        public static DataTable getdata(CommandType type, string commandtext)        
        {          
            OdbcCommand  cmd = new OdbcCommand();
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
         
            cmd.Connection = PublicClass.conn;
            cmd.CommandTimeout = 1000000;
            //PublicClass.conn.Open();
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
            }
            catch { }
            return dt;
        }

        #endregion


      #region All Global Fucntions


        public string ApplicationConnectionString
        {
            get
            {                
                return System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
               
            }
        }

        public DataSet GetDataSet(string xSPName)
        {
            strErrMsg = "";
            OdbcCommand cmd = new OdbcCommand();
            DataSet lDs = new DataSet();
            try
            {
                cmd.Connection = new OdbcConnection(this.ApplicationConnectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = xSPName;
                //cmd.Parameters.Add(xSqlParameter1);
                cmd.Connection.Open();
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(lDs);
                return lDs;
            }
            catch (Exception Ex)
            {
                strErrMsg = Ex.Message;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
            return lDs;
        }

        public DataSet GetDataSet(string xSPName, OdbcParameter[] xArrPrm)
        {
            strErrMsg = "";
            OdbcCommand cmd = new OdbcCommand();
            DataSet lDs = new DataSet();
            try
            {
                cmd.Connection = new OdbcConnection(this.ApplicationConnectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = xSPName;
                //cmd.Parameters.Add(xSqlParameter1);
                foreach (OdbcParameter param in xArrPrm)
                {
                    cmd.Parameters.Add(param);
                }

                cmd.Connection.Open();
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(lDs);
                return lDs;
            }
            catch (Exception Ex)
            {
                strErrMsg = Ex.Message;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
            return lDs;
        }

        public DataSet GetDataSet(string xSPName, OdbcParameter xOdbcParameter1)
        {
            strErrMsg = "";
            OdbcCommand cmd = new OdbcCommand();
            DataSet lDs = new DataSet();
            try
            {
                cmd.Connection = new OdbcConnection(this.ApplicationConnectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = xSPName;
                cmd.Parameters.Add(xOdbcParameter1);
                cmd.Connection.Open();
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(lDs);
                return lDs;
            }
            catch (Exception Ex)
            {
                strErrMsg = Ex.Message;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
            return lDs;
        }

        public DataSet GetDataSet(string xSPName, OdbcParameter xOdbcParameter1, OdbcParameter xOdbcParameter2)
        {
            strErrMsg = "";
            OdbcCommand cmd = new OdbcCommand();
            DataSet lDs = new DataSet();
            try
            {
                cmd.Connection = new OdbcConnection(this.ApplicationConnectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = xSPName;
                cmd.Parameters.Add(xOdbcParameter1);
                cmd.Parameters.Add(xOdbcParameter2);
                cmd.Connection.Open();
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(lDs);
                return lDs;
            }
            catch (Exception Ex)
            {
                strErrMsg = Ex.Message;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
            return lDs;
        }

        public DataTable GetDataTable(string xCmdText, CommandType xCmdType)
        {
            strErrMsg = "";
            DataTable dt = new DataTable();
            try
            {
                OdbcCommand cmd = new OdbcCommand(xCmdText, new OdbcConnection(this.ApplicationConnectionString));
                cmd.CommandType = xCmdType;
                cmd.Connection.Open();
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(dt);
                cmd.Connection.Close();
                return dt;
            }
            catch (Exception Ex)
            {
                strErrMsg = Ex.Message;
            }
            return dt;
        }
        public DataTable GetDataTable(OdbcCommand xObjCmd)
        {
            strErrMsg = "";
            OdbcDataAdapter lDa = new OdbcDataAdapter();
            DataTable lDt = new DataTable();
            try
            {
                xObjCmd.Connection = new OdbcConnection(this.ApplicationConnectionString);
                xObjCmd.Connection.Open();
                lDa = new OdbcDataAdapter(xObjCmd);
                lDa.Fill(lDt);
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
            }
            finally
            {
                xObjCmd.Connection.Close();
                xObjCmd.Dispose();
                lDa.Dispose();
            }
            return lDt; ;
        }
        public DataSet GetDataSet(OdbcCommand xObjCmd, string con)
        {
            strErrMsg = "";
            OdbcDataAdapter lDa = new OdbcDataAdapter();
            DataSet lDs = new DataSet();
            try
            {
                xObjCmd.Connection = new OdbcConnection(con);
                xObjCmd.Connection.Open();
                lDa = new OdbcDataAdapter(xObjCmd);
                lDa.Fill(lDs);
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
            }
            finally
            {
                xObjCmd.Connection.Close();
                xObjCmd.Dispose();
                lDa.Dispose();
            }
            return lDs; ;
        }
        public DataSet GetDataSet(OdbcCommand xObjCmd)
        {
            strErrMsg = "";
            OdbcDataAdapter lDa = new OdbcDataAdapter();
            DataSet lDs = new DataSet();
            try
            {
                xObjCmd.Connection = new OdbcConnection(this.ApplicationConnectionString);
                xObjCmd.Connection.Open();
                lDa = new OdbcDataAdapter(xObjCmd);
                lDa.Fill(lDs);
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
            }
            finally
            {
                xObjCmd.Connection.Close();
                xObjCmd.Dispose();
                lDa.Dispose();
            }
            return lDs; ;
        }
        public DataSet GetDataSet(string xCmdText, CommandType xCmdType)
        {
            strErrMsg = "";
            OdbcDataAdapter lDa = new OdbcDataAdapter();
            DataSet lDs = new DataSet();
            try
            {
                OdbcCommand cmd = new OdbcCommand(xCmdText, new OdbcConnection(this.ApplicationConnectionString));
                cmd.CommandType = xCmdType;
                cmd.Connection.Open();
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(lDs);
                cmd.Connection.Close();
                return lDs;

            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
            }
            finally
            {
                // cmd.Connection.Close();
                // cmd.Dispose();
                lDa.Dispose();
            }
            return lDs; ;
        }


        public bool ExecuteNonQuery(OdbcCommand xObjCmd)
        {
            strErrMsg = "";
            int lRecEff = -1;
            try
            {
                xObjCmd.Connection = new OdbcConnection(this.ApplicationConnectionString);
                xObjCmd.Connection.Open();
                lRecEff = xObjCmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                lRecEff = -1;
            }
            finally
            {
                xObjCmd.Connection.Close();
                xObjCmd.Dispose();
            }
            return (lRecEff > 0) ? true : false;
        }
        public bool ExecuteNonQuery(string _CommandText, CommandType _Commandtype)
        {
            strErrMsg = "";
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd = new OdbcCommand(_CommandText, new OdbcConnection(this.ApplicationConnectionString));
                cmd.Connection.Open();
                cmd.CommandType = _Commandtype;
                cmd.CommandText = _CommandText;
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }
        }


        public bool ExecuteParmQry(string xSPName, OdbcParameter[] xArrPrm)
        {
            strErrMsg = "";
            OdbcCommand cmd = new OdbcCommand();
            DataSet lDs = new DataSet();
            try
            {
                cmd.Connection = new OdbcConnection(this.ApplicationConnectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = xSPName;
                foreach (OdbcParameter param in xArrPrm)
                {
                    cmd.Parameters.Add(param);
                }

                cmd.Connection.Open();
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(lDs);
                return true;
            }
            catch (Exception Ex)
            {
                strErrMsg = Ex.Message;
                return false;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }

        }
        public string ExecuteNonQueryDel(string xSPName, OdbcParameter xOdbcParameter1)
        {
            strErrMsg = "";
            OdbcCommand cmd;
            try
            {
                cmd = new OdbcCommand(xSPName, new OdbcConnection(this.ApplicationConnectionString));
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = xSPName;
                cmd.Parameters.Add(xOdbcParameter1);
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                strErrMsg = "OK";
            }
            catch (OdbcException ex)
            {
                strErrMsg = ex.HResult.ToString();
                if (strErrMsg == "547")
                {

                    strErrMsg = "547";
                }
                else
                {

                    strErrMsg = "NOT";
                }
                return strErrMsg;
            }
            finally
            {
            }
            return strErrMsg;
        }
        public bool ExecuteNonQuery(string _procedure, params OdbcParameter[] objParam)
        {
            strErrMsg = "";
            OdbcCommand cmd;
            try
            {
                cmd = new OdbcCommand(_procedure, new OdbcConnection(this.ApplicationConnectionString));
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = _procedure;
                for (int lLoop = 0; lLoop <= objParam.GetUpperBound(0); lLoop++)
                {
                    cmd.Parameters.Add(objParam[lLoop]);
                    //string a = objParam[lLoop].Value.ToString();
                }

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                strErrMsg = ex.Message;
                return false;
            }
            finally
            {
                //cmd.Dispose();
            }

        }


      #endregion


  }
}
