using System;
using System.Collections.Generic;
using System.Text;

namespace Linq_Lab1_Q3
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int Price { get; set; }
        public override string ToString()
        {
            return $"ID : {this.Id}\tName : {this.Name}\tCateogory : {this.Category}\tPrice : {this.Price}";
        }
    }

    enum Category
    {
        Beverages,
        Condiments,
        Meat,
        Poultry
    }
}
