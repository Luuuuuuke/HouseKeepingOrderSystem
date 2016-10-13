using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace HousekeepingService1
{
    class OrderOperation
    {
        //insert a new order into db
        public static Boolean addNewOrder(Order newOrder)
        {
            String sql = "Insert into 545pjcthskp.`order` (orderNumber, userID, workerID, orderState, serviceAddress, details, payment, orderTime, starDate, endDate) " +　
                                            "values (?orderNumber, ?userID, ?workerID, ?orderState,?serviceAddress, ?details, ?payment, ?orderTime, ?starDate, ?endDate)";
            MySqlConnection conn = new DBDriver().getmysqlcon();
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("?orderNumber", MySqlDbType.Int64, 11).Value = newOrder.getOrderNmb();
            command.Parameters.Add("?userID", MySqlDbType.Int64, 11).Value = newOrder.getUserID();
            command.Parameters.Add("?workerID", MySqlDbType.Int64, 11).Value = newOrder.getWorkerID();
            command.Parameters.Add("?orderState", MySqlDbType.VarChar, 45).Value = newOrder.getOrderStt();
            command.Parameters.Add("?serviceAddress", MySqlDbType.VarChar, 45).Value = newOrder.getSvcAddr();
            command.Parameters.Add("?details", MySqlDbType.VarChar, 45).Value = newOrder.getDetails();
            command.Parameters.Add("?payment", MySqlDbType.Float).Value = newOrder.getPayment();
            command.Parameters.Add("?orderTime", MySqlDbType.DateTime).Value = newOrder.getOrdTm();
            command.Parameters.Add("?starDate", MySqlDbType.DateTime).Value = newOrder.getStarDate();
            command.Parameters.Add("?endDate", MySqlDbType.DateTime).Value = newOrder.getEndDate();
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


        public static List<Order> getOrdersByUserID(int userID)
        {
            List<Order> orderList = new List<Order>();
            DataSet ds = new DataSet();
            String sql = "select * from 545pjcthskp.`order` where userID = ?userID";
            MySqlConnection conn = new DBDriver().getmysqlcon();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand = cmd;
            cmd.Parameters.Add("?userID", MySqlDbType.Int16, 11).Value = userID;
            adapter.Fill(ds);
            conn.Close();
            cmd.Dispose();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                Order order = new Order((int)ds.Tables[0].Rows[i]["orderID"],(int)ds.Tables[0].Rows[i]["orderNumber"],
                                        (int)ds.Tables[0].Rows[i]["userID"],
                                        (int)ds.Tables[0].Rows[i]["workerID"],
                                         ds.Tables[0].Rows[i]["orderState"].ToString(),
                                         ds.Tables[0].Rows[i]["serviceAddress"].ToString(),
                                         ds.Tables[0].Rows[i]["details"].ToString(),
                                        (float)ds.Tables[0].Rows[i]["payment"],
                                         (DateTime)ds.Tables[0].Rows[i]["orderTime"],
                                         (DateTime)ds.Tables[0].Rows[i]["starDate"],
                                         (DateTime)ds.Tables[0].Rows[i]["endDate"]
                                         );
                orderList.Add(order);
            }
            return orderList;
        }


        public static Boolean updateOrderState(int orderID, String newStatus)
        {
            String sql = "update 545pjcthskp.`order` set orderState = ?newStatus where orderID = ?orderID";
            MySqlConnection conn = new DBDriver().getmysqlcon();
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("?orderID", MySqlDbType.Int16, 11).Value = orderID;
            command.Parameters.Add("?newStatus", MySqlDbType.VarChar, 45).Value = newStatus;
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
    }
}
