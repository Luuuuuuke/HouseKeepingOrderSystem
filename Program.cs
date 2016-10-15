using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace HousekeepingService1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            dbTest();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }

        public static void dbTest()
        {
            //dataset ds = dbdriver.query("select * from company");
            //for (int i = 0; i <= ds.tables[0].rows.count - 1; i++)
            //{
            //    console.writeline(ds.tables[0].rows[i]["name"]);
            //}

            //List<Worker> workers = WorkerOperation.getWorkersByType("housekeeper");
            //foreach(Worker worker in workers){
            //    Console.WriteLine(worker.getAge());
            //}
            Random rd = new Random();
            Console.WriteLine(Application.StartupPath + " haha");

        }

    }
}
