﻿using System.Text.Json.Serialization;

namespace My_API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product>? Products { get; set; }
    }
}
