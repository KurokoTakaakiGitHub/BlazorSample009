using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorSample009.Shared
{
    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }
    }
}