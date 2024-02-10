﻿

namespace LinkedSystems.BL.DTOs;

public class ProductAddDTO
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public string ImageURL { get; set; } = "";
}
