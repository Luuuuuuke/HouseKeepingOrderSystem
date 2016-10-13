using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Data;

namespace HousekeepingService1
{
    class WorkerOperation
    {
        public static Worker getWorkerByWorkerID(int workerID)
        {
            Worker worker = null;
            String sql = "select * from woker where workerID = ?workerID";
            DataSet ds = new DataSet();
            MySqlConnection conn = new DBDriver().getmysqlcon();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand = cmd;
            cmd.Parameters.Add("?workerID", MySqlDbType.Int16, 11).Value = workerID;
            adapter.Fill(ds);
            conn.Close();
            cmd.Dispose();
            worker = new Worker((int)ds.Tables[0].Rows[0]["workerID"], 
                                ds.Tables[0].Rows[0]["type"].ToString(),
                                ds.Tables[0].Rows[0]["name"].ToString(),
                                (int)ds.Tables[0].Rows[0]["companyID"],
                                (int)ds.Tables[0].Rows[0]["SSN"],
                                ds.Tables[0].Rows[0]["image"].ToString(),
                                ds.Tables[0].Rows[0]["availableTime"].ToString(), 
                                (float)ds.Tables[0].Rows[0]["price"], 
                                ds.Tables[0].Rows[0]["nationality"].ToString(),
                                ds.Tables[0].Rows[0]["introduction"].ToString(),
                                ds.Tables[0].Rows[0]["fitness"].ToString(),
                                ds.Tables[0].Rows[0]["gender"].ToString(),
                                (int)ds.Tables[0].Rows[0]["age"],
                                (int)ds.Tables[0].Rows[0]["hasMarried"],
                                ds.Tables[0].Rows[0]["language"].ToString(),
                                (int)ds.Tables[0].Rows[0]["hasCertificate"]);
            return worker;
        }
        public static List<Worker> getWorkersByType(String workerType)
        {
            String type = workerType;
            List<Worker> workerList = new List<Worker>();
            DataSet ds = new DataSet();

            //db operations, return result into ds
            String sql = "select * from woker where type = ?type";
            MySqlConnection conn = new DBDriver().getmysqlcon();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand = cmd;
            cmd.Parameters.Add("?type", MySqlDbType.VarChar, 45).Value = type;
            adapter.Fill(ds);
            conn.Close();
            cmd.Dispose();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                Worker worker = new Worker((int)ds.Tables[0].Rows[i]["workerID"],ds.Tables[0].Rows[i]["type"].ToString(),
                                            ds.Tables[0].Rows[i]["name"].ToString(),(int)ds.Tables[0].Rows[i]["companyID"],
                                            (int)ds.Tables[0].Rows[i]["SSN"],ds.Tables[0].Rows[i]["image"].ToString(),
                                            ds.Tables[0].Rows[i]["availableTime"].ToString(),(float)ds.Tables[0].Rows[i]["price"],
                                            ds.Tables[0].Rows[i]["nationality"].ToString(),ds.Tables[0].Rows[i]["introduction"].ToString(),
                                           ds.Tables[0].Rows[i]["fitness"].ToString(),
                                           ds.Tables[0].Rows[i]["gender"].ToString(),
                                            (int)ds.Tables[0].Rows[i]["age"],
                                            (int)ds.Tables[0].Rows[i]["hasMarried"],
                                            ds.Tables[0].Rows[i]["language"].ToString(),
                                            (int)ds.Tables[0].Rows[i]["hasCertificate"]
                                            );
                workerList.Add(worker);
            }
            return workerList;
        }

        //find worker with multiple conditions
        public static List<Worker> getWorkersByConditions(String workerType, String age, String gender, String price, String workTime)
        {
            List<Worker> workerList = new List<Worker>();
            int min_age = 0;
            int max_age = 0;
            float min_price = 0;
            float max_price = 0;
            DataSet ds = new DataSet();
            //prepare the sql and command parameters
            String sql = "select * from woker where type = ?workerType";
            if (age != null)
            {
                min_age = Convert.ToInt16(age.Split('-')[0]);
                max_age = Convert.ToInt16(age.Split('-')[1]);
                sql += " and age >= ?min_age and age <= ?max_age";
            }
            if (gender != null)
            {
                sql += " and gender = ?gender";
            }
            if (price != null)
            {
                min_price = Convert.ToInt16(price.Split('-')[0]);
                max_price = Convert.ToInt16(price.Split('-')[1]);
                sql += " and price >= ?min_price and price <= ?max_price";
            }
            MySqlConnection conn = new DBDriver().getmysqlcon();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand = cmd;
            cmd.Parameters.Add("?workerType", MySqlDbType.VarChar, 45).Value = workerType;
            cmd.Parameters.Add("?min_age", MySqlDbType.Int16, 11).Value = min_age;
            cmd.Parameters.Add("?max_age", MySqlDbType.Int16, 11).Value = max_age;
            cmd.Parameters.Add("?gender", MySqlDbType.VarChar, 45).Value = gender;
            cmd.Parameters.Add("?min_price", MySqlDbType.Float).Value = min_price;
            cmd.Parameters.Add("?max_price", MySqlDbType.Float).Value = max_price;
            adapter.Fill(ds);
            conn.Close();
            cmd.Dispose();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                Worker worker = new Worker((int)ds.Tables[0].Rows[i]["workerID"],
                                            ds.Tables[0].Rows[i]["type"].ToString(),
                                            ds.Tables[0].Rows[i]["name"].ToString(),
                                            (int)ds.Tables[0].Rows[i]["companyID"],
                                            (int)ds.Tables[0].Rows[i]["SSN"],
                                            ds.Tables[0].Rows[i]["image"].ToString(),
                                            ds.Tables[0].Rows[i]["availableTime"].ToString(),
                                            (float)ds.Tables[0].Rows[i]["price"],
                                            ds.Tables[0].Rows[i]["nationality"].ToString(),
                                           ds.Tables[0].Rows[i]["introduction"].ToString(),
                                           ds.Tables[0].Rows[i]["fitness"].ToString(),
                                           ds.Tables[0].Rows[i]["gender"].ToString(),
                                            (int)ds.Tables[0].Rows[i]["age"],
                                            (int)ds.Tables[0].Rows[i]["hasMarried"],
                                            ds.Tables[0].Rows[i]["language"].ToString(),
                                            (int)ds.Tables[0].Rows[i]["hasCertificate"]
                                            );
                workerList.Add(worker);
            }
            return workerList;
        }

        //get worker by orderID
        public static Worker getWorkerByOrderID(int orderID)
        {
            Worker worker;
            String sql = "select woker.workerID, type, name, companyID, SSN, image, availableTime, price, nationality, introduction, fitness, gender, age, hasMarried, language, hasCertificate" +
                " from woker, 545pjcthskp.`order` where woker.workerID = order.workerID and orderID = ?orderID";
            DataSet ds = new DataSet();
            MySqlConnection conn = new DBDriver().getmysqlcon();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand = cmd;
            cmd.Parameters.Add("?orderID", MySqlDbType.Int16, 11).Value = orderID;
            adapter.Fill(ds);
            conn.Close();
            cmd.Dispose();
            worker = new Worker((int)ds.Tables[0].Rows[0]["workerID"],
                                ds.Tables[0].Rows[0]["type"].ToString(),
                                ds.Tables[0].Rows[0]["name"].ToString(),
                                (int)ds.Tables[0].Rows[0]["companyID"],
                                (int)ds.Tables[0].Rows[0]["SSN"],
                                ds.Tables[0].Rows[0]["image"].ToString(),
                                ds.Tables[0].Rows[0]["availableTime"].ToString(),
                                (float)ds.Tables[0].Rows[0]["price"],
                                ds.Tables[0].Rows[0]["nationality"].ToString(),
                                ds.Tables[0].Rows[0]["introduction"].ToString(),
                                ds.Tables[0].Rows[0]["fitness"].ToString(),
                                ds.Tables[0].Rows[0]["gender"].ToString(),
                                (int)ds.Tables[0].Rows[0]["age"],
                                (int)ds.Tables[0].Rows[0]["hasMarried"],
                                ds.Tables[0].Rows[0]["language"].ToString(),
                                (int)ds.Tables[0].Rows[0]["hasCertificate"]);
            return worker;
        }
    }
}
