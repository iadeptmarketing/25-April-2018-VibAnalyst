using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iadeptmain.GlobalClasses
{
    public class Class1
    {
        private string strErrMsg = "";
        private string strParty;       
        private string strorder;
        public string ErrMsg
        {
            get
            {
                return strErrMsg;
            }
        }

        public string ApplicationConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];

            }
        }


        public DataSet GetDataSet(string xSPName, OdbcParameter[] xArrPrm)
        {
            
            String S = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
            
            strErrMsg = "";
            OdbcCommand cmd = new OdbcCommand();
            DataSet lDs = new DataSet();
            try
            {
                cmd.Connection = new OdbcConnection(S);
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


        public DataSet GetDataSet(string xSPName, OdbcParameter xSqlParameter1)
        {

            String S = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
            
            strErrMsg = "";
            OdbcCommand cmd = new OdbcCommand();
            DataSet lDs = new DataSet();
            try
            {
                cmd.Connection = new OdbcConnection(S);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = xSPName;
                cmd.Parameters.Add(xSqlParameter1);
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

        public DataSet GetDataSet(string xSPName, OdbcParameter xSqlParameter1, OdbcParameter xSqlParameter2)
        {
            DataSet lDs = new DataSet();

            String S = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
            
            strErrMsg = "";
            OdbcCommand cmd = new OdbcCommand();
            try
            {
                cmd.Connection = new OdbcConnection(S);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = xSPName;
                cmd.Parameters.Add(xSqlParameter1);
                cmd.Parameters.Add(xSqlParameter2);
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
            DataTable dt = new DataTable();

            String S = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
            
            String s = xCmdType.ToString();
            CommandType type = CommandType.Text;
            if (s.Contains(".Text"))
            {
                type = CommandType.Text;
            } if (s.Contains(".StoredProcedure"))
            {
                type = CommandType.StoredProcedure;
            } if (s.Contains(".TableDirect"))
            {
                type = CommandType.TableDirect;
            }
            strErrMsg = "";
            try
            {
                OdbcCommand cmd = new OdbcCommand(xCmdText, new OdbcConnection(S));
                cmd.CommandType = type;
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

            String S = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];

            OdbcDataAdapter lDa = new OdbcDataAdapter();
            DataTable lDt = new DataTable();
            try
            {
                xObjCmd.Connection = new OdbcConnection(S);
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

            String S = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
            
            strErrMsg = "";
            OdbcDataAdapter lDa = new OdbcDataAdapter();
            DataSet lDs = new DataSet();
            try
            {
                xObjCmd.Connection = new OdbcConnection(S);
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

            String S = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
           
            OdbcDataAdapter lDa = new OdbcDataAdapter();
            DataSet lDs = new DataSet();
            try
            {
                xObjCmd.Connection = new OdbcConnection(S);
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

            DataSet lDs = new DataSet();
            String s = xCmdType.ToString();
            CommandType type = CommandType.Text;
            if (s.Contains(".Text"))
            {
                type = CommandType.Text;
            } if (s.Contains(".StoredProcedure"))
            {
                type = CommandType.StoredProcedure;
            } if (s.Contains(".TableDirect"))
            {
                type = CommandType.TableDirect;
            }

            String S = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
           
            strErrMsg = "";
            OdbcDataAdapter lDa = new OdbcDataAdapter();
            try
            {
                OdbcCommand cmd = new OdbcCommand(xCmdText, new OdbcConnection(S));
                cmd.CommandType = type;
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

    }
}
