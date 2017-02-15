/*
 * Database activity classes Select, Insert, Update and Delete query to database.
 *
 * Checks:
 *    - If the database connection is open or not. 
 *    - If database connection is not open, then it opens the connection and performs 
 *      the database query. 
 *     
 * Results are to be received and being passing in Data Table in this class.
 *
 * Return boolean on success of operations
 * Takes the database setting from the web.config file so it’s really flexible to manage 
 * the database settings.
*/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LittleDwarfsAgency
{
    public class dbConnection
    {
        /* 
         * SqlDataAdapter provides the communication between the Dataset and the SQL database. 
         * SqlDataAdapter Object used in combination with Dataset Object. 
         *
         * (AZ)URE  Database Connection String: 
         * Server=tcp:geminiserver.database.windows.net,1433;Initial Catalog=LittleDwarfAgency;
         * Persist Security Info=False;User ID={your_username};Password={your_password};
         * MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;
         * Connection Timeout=30;
         */

        private SqlDataAdapter myAdapter;
        private SqlConnection conn;

        public dbConnection()
        {
            myAdapter = new SqlDataAdapter();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AZ"].ConnectionString);
        }

        /* 
         * Open Database Connection if Closed or Broken 
         */

        /*
         * Open connection to the database if current connection state:
         *  - Broken, The connection to the data source is broken. 
         *                  This can occur only after the connection has been opened. 
         *                  A connection in this state may be closed and then re-opened.
         *  - Closed, The connection is closed.
         */

        private SqlConnection openConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed || conn.State == System.Data.ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        /*
         * DataTable: A DataTable, which represents one table of in-memory relational data, 
         *                   can be created and used independently, or can be used by other .
         *                   NET Framework objects, most commonly as a member of a DataSet.
         * 
         * DataSet: The DataSet, which is an in-memory cache of data retrieved from a data source, 
         *                is a major component of the ADO.NET architecture. 
         *                The DataSet consists of a collection of DataTable objects that you can relate to 
         *                each other with DataRelation objects. 
         *                
         * .Fill: Method that adds rows in the DataSet to match those in the data source.                 
         *                
         * Method: executeSelectQuery
         * 
         *              Send SQL SELECT QUERY command and return a dataTable with the results.
         */

        public DataTable executeSelectQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: " + _query + " \nException: \n" + e.StackTrace.ToString());
                return null;
            }
            finally
            {

            }
            return dataTable;
        }

        /*
         *  Method: executeInsertQuery
         * 
         *              Send SQL INSERT QUERY command and return a boolean on success of operation.
         */
        public bool executeInsertQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeInsertQuery  - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            finally
            {

            }
            return true;
        }


        /*
         *  Method: executeUpdateQuery
         * 
         *              Send SQL UPDATE QUERY command and return a boolean on success of operation.
         */
        public bool executeUpdateQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeUpdateQuery  - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            finally
            {

            }
            return true;
        }

        /*
         *  Method: executeDeleteQuery
         * 
         *              Send SQL DELETE QUERY command and return a boolean on success of operation.
         */
        public bool executeDeleteQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.DeleteCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeDeleteQuery  - Query: " + _query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            finally
            {

            }
            return true;
        }
    }
}
 
 