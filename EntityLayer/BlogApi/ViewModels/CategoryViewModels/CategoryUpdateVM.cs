﻿namespace EntityLayer.BlogApi.ViewModels.CategoryViewModels
{
    public class CategoryUpdateVM
    {
        //Primary Key
        public int Id { get; set; }

        //category section
        public string Name { get; set; } = null!;

        //Information
        public string? UpdatedDate { get; set; }

        //Check Constraint       
        public byte[] RowVersion { get; set; } = null!;
    }
}
