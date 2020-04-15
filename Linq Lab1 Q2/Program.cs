using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Lab1_Q2
{
    class Program
    {
        //Create list of employees based on given class then :
        //Write a program that will print the entire employee which in EB Department.
        //Write a program that will print all intersection employees from another employees list.
        //Write a program that will print all employees after the first three employees.
        //Write a program that will print all employees grouped by department name.
        static void Main(string[] args)
        {
            var emps = new List<Employee>
            {
                new Employee {Id = 1, Name = "Emp 1", Age = 21, Gender = Gender.Male, DeptId = 1},
                new Employee {Id = 2, Name = "Emp 2", Age = 22, Gender = Gender.Male, DeptId = 1},
                new Employee {Id = 3, Name = "Emp 3", Age = 23, Gender = Gender.Male, DeptId = 2},
                new Employee {Id = 4, Name = "Emp 4", Age = 24, Gender = Gender.Male, DeptId = 1},
                new Employee {Id = 5, Name = "Emp 5", Age = 25, Gender = Gender.Female, DeptId = 2}
            };
            var depts = new List<Department>
            {
                new Department{Id = 1, Name="EB"},
                new Department{Id = 2, Name = "SD"}
            };
            //a 
            var EBemp = emps.Where(emp => emp.DeptId == depts.First(dept => dept.Name == "EB").Id).ToList();
            Print(EBemp, "Employees in EB : ");
            //b
            var intersects = emps.Intersect(new List<Employee> { new Employee {Id = 3, Name = "Emp 3", Age = 23, Gender = Gender.Male, DeptId = 2},
                new Employee {Id = 4, Name = "Emp 4", Age = 24, Gender = Gender.Male, DeptId = 1}}).ToList();
            Print(intersects, "Employees resulting from Intersection : ");
            //c
            var skipped = emps.Skip(3).ToList();
            Print(skipped, "Employees after the first 3 Employee : ");
            //d
            var grouped = emps.GroupJoin(depts,
                                    emp => emp.DeptId,
                                    dept => dept.Id,
                                    (emp, dept) => new { dept, emp }
                                    ).GroupBy(i=>i.dept.First().Name).ToList();
            Console.WriteLine("Grouped Empoloyees :");
            foreach (var i in grouped)
            {
                var msg = i.Key;
                Console.WriteLine("  " + msg+" : ");
                
                foreach (var j in i)
                {
                    Console.WriteLine("    " + j.emp+"  "+j.dept.First());
                }
                Console.WriteLine();

            }

            Console.Write("\nPress any key to Exit");
            Console.ReadKey(true);

        }
        static void Print(List<Employee> list, string msg)
        {
            Console.WriteLine(msg);
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                Console.WriteLine("  " + item);
                
            }
            Console.WriteLine("");

        }

    }
}
