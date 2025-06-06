﻿namespace SistemaInventario.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product() { }

        public Product(int id, string name, int quantity, decimal price, string category)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Category = category;
        }
    }
}
