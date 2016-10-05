using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousekeepingService1
{
    class User
    {
        private int userID;
        private String username;
        private String password;
        private String address;
        private String phone;
        private DateTime registerTime;

        public User(String username, String password, String address, String phone, DateTime registerTime)
        {
            this.username = username;
            this.password = password;
            this.address = address;
            this.phone = phone;
            this.registerTime = registerTime;
        }
        public int getUserID()
        {
            return this.userID;
        }

        public string getUsername()
        {
            return this.username;
        }

        public string getPassword()
        {
            return this.password;
        }

        public string getAddress()
        {
            return this.address;
        }

        public string getPhone()
        {
            return this.phone;
        }

        public DateTime getRegisterTime()
        {
            return this.registerTime;
        }

        public void setUserID(int userID)
        {
            this.userID = userID;
        }

    }
}
