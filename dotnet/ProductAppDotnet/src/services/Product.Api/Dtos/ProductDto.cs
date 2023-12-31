﻿namespace Product.Api.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? PhotoPath { get; set; }
        public decimal Price { get; set; }
        public string? CategoryId { get; set; }
    }
}
