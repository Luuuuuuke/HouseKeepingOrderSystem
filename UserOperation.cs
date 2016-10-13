using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace HousekeepingService1
{
    class UserOperation
    {
        public static Boolean addUser(User _newUser)
        {
            User newUser = _newUser;
            if (newUser == null)
            {
                return false;
            }
            String sql = "Insert into user (username, password, address, phone, registerTime) " + 
                "values (?username, ?password, ?address, ?phone, ?registerTime)";
            MySqlConnection conn = new DBDriver().getmysqlcon();
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("?username", MySqlDbType.VarChar, 45).Value = newUser.getUsername();
            command.Parameters.Add("?password", MySqlDbType.VarChar, 45).Value = newUser.getPassword();
            command.Parameters.Add("?address", MySqlDbType.VarChar, 100).Value = newUser.getAddress();
            command.Parameters.Add("?phone", MySqlDbType.VarChar, 45).Value = newUser.getPhone();
            command.Parameters.Add("?registerTime", MySqlDbType.DateTime).Value = newUser.getRegisterTime();
            int rowsAffected = command.ExecuteNonQuery();
            conn.Close();
            command.Dispose();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static User verifyUser(String username, String password)
        {
            User currentUser = null;
            String sql = "select * from user where userName = ?username and password = ?password";
            MySqlConnection conn = new DBDriver().getmysqlcon();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.SelectCommand = cmd;
                cmd.Parameters.Add("?username", MySqlDbType.VarChar, 45).Value = username;
                cmd.Parameters.Add("?password", MySqlDbType.VarChar, 45).Value = password;
                adapter.Fill(ds);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            int returnRows = ds.Tables[0].Rows.Count;
            conn.Close();
            cmd.Dispose();
            if (returnRows > 0)
            {
                currentUser = new User(ds.Tables[0].Rows[0]["username"].ToString(), ds.Tables[0].Rows[0]["password"].ToString(), ds.Tables[0].Rows[0]["address"].ToString(), ds.Tables[0].Rows[0]["phone"].ToString(), (DateTime)ds.Tables[0].Rows[0]["registerTime"]);
                currentUser.setUserID((int)ds.Tables[0].Rows[0]["userID"]);
            }
            return currentUser;
        }

        //check if the user exists
        public static Boolean isUserExists(String username)
        {
            String sql = "select * from user where username = ?username";
            MySqlConnection conn = new DBDriver().getmysqlcon();
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.SelectCommand = cmd;
                cmd.Parameters.Add("?username", MySqlDbType.VarChar, 45).Value = username;
                adapter.Fill(ds);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            int returnRows = ds.Tables[0].Rows.Count;

            conn.Close();
            cmd.Dispose();
            if (returnRows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




    }
}
