using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Xml;
using System.Web;
namespace DLibraryPro
{
    public class DataAccess
    {
        public OracleCommand m_Command;
        public OracleConnection m_Connection;

        public DataAccess()
        {
            m_Connection = new OracleConnection();
            m_Command = new OracleCommand();

            //read connection string from xml file
            //string str1 = "";


            //XmlTextReader xmlR = new XmlTextReader(MapPath("mycompany.xml") "connString.xml");
            //str1 = xmlR.GetAttribute("connstring");
            //str1 = System.Configuration.ConfigurationManager.AppSettings.Get("connString");
            //        XmlDocument doc = new XmlDocument();
            //doc.Load("~/App_Data/sample.xml");

            //XmlNode root = doc.DocumentElement;
            //str1 = root.SelectSingleNode("author").ChildNodes[0].Value;
            //string str1 = BDGovPayroll.Properties.Settings.Default.connString;

            string str1 = @"Data Source=(DESCRIPTION=
                                        (ADDRESS_LIST=
                                            (ADDRESS=
                                                (PROTOCOL=TCP)(HOST=soft-server)(PORT=1521)))
                                                    (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME= orcl)));
                                                        User Id=librarry;Password=softech;";
            ////////            string str1 = @" Data Source = (DESCRIPTION = 
            ////////                                (ADDRESS_LIST = 
            ////////                                    (ADDRESS = 
            ////////                                        (PROTOCOL = TCP)(HOST = soft1)(PORT = 1521)))(CONNECT_DATA = 
            ////////                                            (SERVER = DEDICATED)(SERVICE_NAME =  XE))); 
            ////////                                                User Id = payroll_db; Password = payroll;";

            //m_Connection.ConnectionString = @"Data Source=soft1;User Id=payroll_db;Password=payroll;";
            m_Connection.ConnectionString = str1;
            m_Command.Connection = m_Connection;
        }

        public void Dispose()
        {
            CloseConnection();
            GC.SuppressFinalize(this);
        }

        private void OpenConnection()
        {
            if (m_Connection.State == ConnectionState.Closed) m_Connection.Open();
        }

        public void CheckConnection()
        {
            if (m_Connection.State == ConnectionState.Closed) m_Connection.Open();
        }

        private void CloseConnection()
        {
            if (m_Connection.State == ConnectionState.Open) m_Connection.Close();
        }

        public OracleDataAdapter ExecuteAdapter(string strCommand)
        {
            return (ExecuteAdapter(strCommand, CommandType.StoredProcedure));
        }

        public OracleDataAdapter ExecuteAdapter(string strCommand, CommandType objType)
        {
            m_Command.CommandText = strCommand;
            m_Command.CommandType = objType;
            OpenConnection();
            OracleDataAdapter objAdapter = new OracleDataAdapter(m_Command);
            return (objAdapter);
        }

        public DataSet ExecuteDataSet(string strCommand, CommandType objType)
        {
            m_Command.CommandText = strCommand;
            m_Command.CommandType = objType;
            OpenConnection();
            OracleDataAdapter objAdapter = new OracleDataAdapter(m_Command);
            DataSet ds = new DataSet("ds_");
            objAdapter.Fill(ds);
            return ds;
        }

        public DataTable ExecuteDataTable(string strCommand, CommandType objType)
        {
            return (ExecuteDataSet(strCommand, objType).Tables[0]);
        }

        public void ExecuteNonQuery(string strCommand)
        {
           // return (ExecuteNonQuery(strCommand, CommandType.StoredProcedure));
            ExecuteNonQuery(strCommand, CommandType.StoredProcedure);
        }

        public void ExecuteNonQuery(string strCommand, CommandType objType)
        {
            m_Command.CommandText = strCommand;
            m_Command.CommandType = objType;
            OpenConnection();
            m_Command.ExecuteNonQuery();
            CloseConnection();
            //return (intReturn);
        }
        
        public OracleDataReader ExecuteReader(string strCommand)
        {
            return (ExecuteReader(strCommand, CommandType.StoredProcedure));
        }

        public OracleDataReader ExecuteReader(string strCommand, CommandType objType)
        {
            return (ExecuteReader(strCommand, objType, CommandBehavior.CloseConnection));
        }

        public OracleDataReader ExecuteReader(string strCommand, CommandType objType, CommandBehavior objBehaviour)
        {
            m_Command.CommandText = strCommand;
            m_Command.CommandType = objType;
            OpenConnection();
            OracleDataReader objReader = m_Command.ExecuteReader();
            return (objReader);
        }

        public object ExecuteScaler(string strCommand)
        {
            return (ExecuteScaler(strCommand, CommandType.StoredProcedure));
        }

        public object ExecuteScaler(string strCommand, CommandType objType)
        {
            m_Command.CommandText = strCommand;
            m_Command.CommandType = objType;
            OpenConnection();
            
            object objReturn = m_Command.ExecuteScalar();
            CloseConnection();
            return (objReturn);
        }

        public void AddParameter(string StrName, OracleType objType, ParameterDirection objDirection)
        {
            OracleParameter l_Param = new OracleParameter(StrName,objType);
            l_Param.ParameterName = StrName;
            l_Param.OracleType = objType;
            l_Param.Direction = objDirection;
            m_Command.Parameters.Add(l_Param);
        }

        public void AddParameter(string StrName, OracleType objType, ParameterDirection objDirection,int paramSize)
        {
            OracleParameter l_Param = new OracleParameter(StrName,objType,paramSize);
            l_Param.ParameterName = StrName;
            l_Param.Size = paramSize;
            l_Param.OracleType = objType;
            l_Param.Direction = objDirection;
            m_Command.Parameters.Add(l_Param);
        }

        public void AddParameter(string StrName, OracleType objType, ParameterDirection objDirection, int paramSize, object objValue)
        {
            OracleParameter l_Param = new OracleParameter(StrName, objType, paramSize);
            l_Param.ParameterName = StrName;
            l_Param.Size = paramSize;
            l_Param.OracleType = objType;
            l_Param.Direction = objDirection;
            m_Command.Parameters.Add(l_Param);
            ModifyParameter(StrName, objValue);
        }

        public void AddParameter(string StrName, OracleType objType,object objValue)
        {
            AddParameter(StrName, objType, ParameterDirection.Input);
            ModifyParameter(StrName, objValue);
        }
        
        public void AddParameter(string strName, OracleType objType, ParameterDirection objDirection, object objValue)
        {
            AddParameter(strName, objType, objDirection);
            ModifyParameter(strName, objValue);
        }

        public Object GetParameter(string strName)
        {

            //if (m_Command.Parameters.IndexOf(strName) != 0)
            //{

            return (m_Command.Parameters[strName].Value);

            // return (m_Command.Parameters[strName].Value);
            //}
            //else
            //{
            //return (null);
            //return (100);
            //}
        }

        public void ModifyParameter(string strName, object objValue)
        {
            //if (m_Command.Parameters[strName].OracleType == OracleType.)
            //{
            //    if (objValue.GetType() == typeof(System.String)) objValue = new System.Guid(objValue.ToString());
            //}
            m_Command.Parameters[strName].Value = objValue;
        }

        public void RemoveParameter(string strName)
        {
            if (m_Command.Parameters.IndexOf(strName) != 0) m_Command.Parameters.RemoveAt(m_Command.Parameters.IndexOf(strName));
        }
    }
}