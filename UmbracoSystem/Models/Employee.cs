using System;
using System.Collections.Generic;
using System.Text;

namespace UmbracoSystem.Models
{
    public class Employee
    {
        private static int idCount = 900;

        public int EmployeeId { get; }
        public string Name { get; set; }
        public bool Admin { get; set; }

        public Employee(string name, bool admin)
        {
            EmployeeId = idCount++;
            Name = name;
            Admin = admin;
        }

        /*        public Employee(int id, string name, bool admin)
                {
                    EmployeeId = id;
                    Name = name;
                    Admin = admin;
                }
                public Employee(string name, bool admin) :
                    this(idCount++, name, admin) 
                {
                }*/
        public Employee()
        {
            EmployeeId = idCount++;
        }

        public static void SetId(int id)
        {
            idCount = id;
        }
    }
}
