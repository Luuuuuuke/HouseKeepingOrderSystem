using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace HousekeepingService1
{
    class CompanyOperation
    {

        public static Company getCompanyByWorkerID(int workerID)
        {
            Company company = null;
            String sql = "select company.companyID, company.name, foundTime, company.introduction " + 
                        "from company, woker where " + 
                        "workerID = ?workerID and woker.companyID = company.companyID";
            DataSet ds = new DataSet();
            MySqlConnection conn = new DBDriver().getmysqlcon();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand = cmd;
            cmd.Parameters.Add("?workerID", MySqlDbType.Int16, 11).Value = workerID;
            adapter.Fill(ds);
            conn.Close();
            cmd.Dispose();
            company = new Company(Convert.ToInt16(ds.Tables[0].Rows[0]["companyID"]), ds.Tables[0].Rows[0]["name"].ToString(), ds.Tables[0].Rows[0]["foundTime"].ToString(), ds.Tables[0].Rows[0]["introduction"].ToString());
            return company;
        }
    }
}
