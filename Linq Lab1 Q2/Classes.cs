using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Linq_Lab1_Q2
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DeptId { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public override string ToString()
        {
            return $"ID : {this.Id}   Name : {this.Name}   Age : {this.Age}   Gender : {this.Gender}   DeptId : {this.DeptId}";
        }
        public override bool Equals(object obj)
        {
            // If the passed object is null
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Employee))
            {
                return false;
            }
            return (this.Id == ((Employee)obj).Id);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
   
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public override string ToString()
        {
            return$"Dept Name : {this.Name}";
        }

    }

    public enum Gender
    {
        Male, Female
    }
}
