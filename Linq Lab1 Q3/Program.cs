using System;
using System.Collections.Generic;
using System.Linq;
namespace Linq_Lab1_Q3
{
    class Program
    {
        //Create list of Products based on given class then :
        //Write a program that will return a list of categories and how many products each have.
        //Write a program that will return min to get the cheapest price among each category's products.
        //Display all products grouped by category and ordered by price.
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product {Id=1, Name="coffee", Category = Category.Beverages, Price= 20 },
                new Product {Id=2, Name="pepper", Category = Category.Condiments, Price=10},
                new Product {Id=3, Name="pepsi", Category = Category.Beverages, Price= 5 },
                new Product {Id=4, Name="meat", Category = Category.Meat, Price= 200 },
                new Product {Id=5, Name="chicken", Category = Category.Poultry, Price= 300 },
            };
            //a
            var catagories = products.GroupBy(p => p.Category).Select(cat => new { cat = cat.Key, count = cat.Count() }).ToList();
            Console.WriteLine("Grouped Empoloyees :");
            foreach (var i in catagories)
            {
                Console.WriteLine($"  Catagory : {i.cat}\t  Count : {i.count}");
            }
            Console.WriteLine();
            //b
            var min = products.GroupBy(p => p.Category).Select(i => new
            {
                i.Key,
                product = i.Where(k => k.Price == i.Min(j => j.Price)).First()
            }).ToList();
            Console.WriteLine("Minimum in Catagories :");
            foreach (var i in min)
            {
                Console.WriteLine("  "+i.product);
            }
            Console.WriteLine();
            //c
            var orderedgroups = products.OrderBy(p=>p.Price).GroupBy(p => p.Category).ToList();
            Console.WriteLine("Ordered Catagories :");
            foreach (var i in orderedgroups)
            {
                Console.WriteLine("  "+i.Key+" : ");
                foreach (var j in i)
                {
                    Console.WriteLine("    "+j);
                }

            }
            Console.WriteLine();

            Console.Write("\nPress any key to Exit");
            Console.ReadKey(true);
        }
        
    }
}
