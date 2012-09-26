using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWebRest.Areas.API.Models
{
    public class Client
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public int Age { get; set; }

        public Client()
        {
            this.ID = 0;
            this.Name = "";
            this.Surname = "";
            this.Age = 0;
        }

        public Client(int id, string name, string surname, int age)
        {
            this.ID = id;
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }
    }
}