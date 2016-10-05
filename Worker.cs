using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousekeepingService1
{
    class Worker
    {
        private int workerID;
        private String type;
        private String name;
        private int companyID;
        private int SSN;
        private String image;
        private String availableTime;
        private float price;
        private String nationality;
        private String introduction;
        private String fitness;
        private String gender;
        private int age;
        private int hasMarried;
        private String language;
        private int hasCertificate;

        public Worker(int workerID, String type, String name, int companyID, int SSN, String image, String availableTime, float price,
            String nationality, String introduction, String fitness, String gender, int age, int hasMarried, String language, int hasCertificate)
        {
            this.workerID = workerID;
            this.type = type;
            this.name = name;
            this.companyID = companyID;
            this.SSN = SSN;
            this.image = image;
            this.availableTime = availableTime;
            this.price = price;
            this.nationality = nationality;
            this.introduction = introduction;
            this.fitness = fitness;
            this.gender = gender;
            this.age = age;
            this.hasMarried = hasMarried;
            this.language = language;
            this.hasCertificate = hasCertificate;
        }

        public int getWorkerID()
        {
            return this.workerID;
        }

        public String getType()
        {
            return this.type;
        }
        public String getName()
        {
            return this.name;
        }
        //TODO
        public int getCompanyID()
        {
            return this.companyID;
        }
        public int getSSN()
        {
            return this.SSN;
        }
        public String getImage()
        {
            return this.image;
        }
        public String getAvailableTime()
        {
            return this.availableTime;
        }
        public float getPrice()
        {
            return this.price;
        }
        public String getNationality()
        {
            return this.nationality;
        }
        public String getIntroduction()
        {
            return this.introduction;
        }

        public String getFitness()
        {
            return this.fitness;
        }

        public String getGender()
        {
            return this.gender;
        }

        public int getAge()
        {
            return this.age;
        }

        public int getHasMarried()
        {
            return this.hasMarried;
        }

        public String getLanguage()
        {
            return this.language;
        }
        public int getHasCertificate()
        {
            return this.hasCertificate;
        }

    }
}
