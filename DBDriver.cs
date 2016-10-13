using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace HousekeepingService1
{
    class DBDriver
    {

        #region  construct db connection
        /// <summary> 
        /// construct db connection 
        /// </summary> 
        /// <returns>MySqlConnection</returns> 
        public MySqlConnection getmysqlcon()
        {
            string connectionStr = "server=localhost;user id=root;password=admin;database=545pjcthskp;charset=utf8";
            MySqlConnection conn = new MySqlConnection(connectionStr);
            return conn;
        }
        #endregion

        //connection string
        private static string connectionString = "Server=localhost;Uid=root;Pwd=admin;Database=545pjcthskp;Port=3306;charset=utf8";
        //execute sql, return dataSet
        public static DataSet Query(String sqlStr)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(sqlStr, connection);
                    command.Fill(ds);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }


        //return number of affected rows
        public static int executeSql(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

    }
}
