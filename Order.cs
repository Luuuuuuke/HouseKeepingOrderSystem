using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace HousekeepingService1
{
    class Order
    {
        private int orderID;
        private int orderNumber;
        private int userID;
        private int workerID;
        private string orderState;
        private string serviceAddress;
        private string details;
        private float payment;
        private DateTime orderTime;
        private DateTime starDate;
        private DateTime endDate;

        /* should we correct the datetime format here？ what datetime format do we need？
        using system.globalization;
        DateTime orderTime = dateTime.Now;      可以用默认，当前全部的时间 
        
        string format = "ddd MMM d YYYY";      星期3个字母，月份3个字母，日期2个数字无前导零，年份4个数字  
        */


        public Order(int orderNumber, int userID, int workerID, string orderState, string serviceAddress, string details, float payment, DateTime orderTime, DateTime starDate, DateTime endDate)
        {
            this.orderNumber = orderNumber;
            this.userID = userID;
            this.workerID = workerID;
            this.orderState = orderState;
            this.serviceAddress = serviceAddress;
            this.details = details;
            this.payment = payment;
            this.orderTime = orderTime;
            this.starDate = starDate;
            this.endDate = endDate;
        }

        public Order(int orderID, int orderNumber, int userID, int workerID, string orderState, string serviceAddress, string details, float payment, DateTime orderTime, DateTime starDate, DateTime endDate)
        {
            this.orderID = orderID;
            this.orderNumber = orderNumber;
            this.userID = userID;
            this.workerID = workerID;
            this.orderState = orderState;
            this.serviceAddress = serviceAddress;
            this.details = details;
            this.payment = payment;
            this.orderTime = orderTime;
            this.starDate = starDate;
            this.endDate = endDate;
        }

        public int getOrderID()
        {
            return this.orderID; /*自动+1*/
        }

        public int getOrderNmb()
        {
            return this.orderNumber;
            /*Random.Next(99999999999);  返回11位的随机数*/
        }

        public int getUserID()
        {
            return this.userID; /*触发自动get*/
        }

        public int getWorkerID()
        {
            return this.workerID; /*触发自动get*/
        }

        public string getOrderStt()
        {
            return this.orderState;
            /*
            ALTER TABLE `545pjcthskp`.`order` 
            CHANGE COLUMN `orderState` `orderState` VARCHAR(45) NOT NULL DEFAULT 'Not Paid' COMMENT '' ;
            触发自动get*/
        }

        public string getSvcAddr()
        {
            return this.serviceAddress;
        }

        public string getDetails()
        {
            return this.details;
        }

        public float getPayment()
        {
            return this.payment;
        }

        public DateTime getOrdTm()
        {
            return this.orderTime;
        }

        public DateTime getStarDate()
        {
            return this.starDate;
        }

        public DateTime getEndDate()
        {

            return this.endDate;
        }
    }
}
