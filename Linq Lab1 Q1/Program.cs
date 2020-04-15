using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Lab1_Q1
{
    class Program
    {
        //Given the following list of integers {5,3,45,89,8,9,81,72,3,88,1} :
        //Write a program that will print all the even numbers in the list
        //Write a program that will print the list sorted from the largest to smallest
        //Write a program that will print out the common elements with the list {72, 8, 12, 89, 84}
        //Write a program that will print out the element squared
        //Write a program that will print out the elements grouped by even and odd numbers. 
        //      (Each group has sorted items, and groups are order by its key from small to big 'the first group is 0 and second is 1').
        static void Main(string[] args)
        {
            List<int> nums = new List<int> { 5, 3, 45, 89, 8, 9, 81, 72, 3, 88, 1 };
            //a
            var evens = nums.Where(n => n % 2 == 0).ToList();
            Print(evens, "Even Numbers :");
            //b
            var sorted = nums.OrderBy(n => n).ToList();
            Print(sorted, "List Sorted :");
            //c
            var commons = nums.Intersect(new List<int> { 72, 8, 12, 89, 84 }).ToList();
            Print(commons, "Common Numbers :");
            //d
            var squared = nums.Select(n => n * n).ToList();
            Print(squared, "Squared Numbers :");
            //e
            var groups = nums.OrderBy(n=>n).GroupBy(n => n % 2 == 0).OrderBy(gr => gr.Key);
            Console.WriteLine("Grouped List");
            foreach (var i in groups)
            {
                var msg = i.Key ? "Even List :" : "Odd List"; 
                Console.WriteLine("  "+msg);
                Console.Write("  ");
                foreach (var j in i)
                {
                    Console.Write("  " + j);
                    if (j != i.Last())
                    {
                        Console.Write(" ,");
                    }
                }
                Console.WriteLine();
                    
            }

            Console.Write("\nPress any key to Exit");
            Console.ReadLine();
        }
        static void Print(List<int> list,string msg)
        {
            Console.WriteLine(msg);
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                Console.Write("  "+item);
                if(i != list.Count-1)
                {
                    Console.Write("  ,");
                }
            }
            Console.WriteLine("");

        }
        
    }
    
}
