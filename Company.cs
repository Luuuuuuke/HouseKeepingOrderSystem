using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousekeepingService1
{
    class Company
    {
        private int companyID;
        private String name;
        private String foundTime;
        private String introduction;

        public Company(int companyID, String name, String foundTime, String introduction)
        {
            this.companyID = companyID;
            this.name = name;
            this.foundTime = foundTime;
            this.introduction = introduction;
        }
        public int getCompanyID()
        {
            return this.companyID;
        }
        public String getName()
        {
            return this.name;

        }

        public String getFoundTime()
        {
            return this.foundTime;
        }

        public String getIntroduction()
        {
            return this.introduction;
        }
    }
}
