namespace EntityLayer.BlogApi.ViewModels.CategoryViewModels
{
    public class CategoryListVM
    {
        //Primary Key
        public int Id { get; set; }

        //Information
        public string CreatedDate { get; set; } = null!;
        public string? UpdatedDate { get; set; }

        //category section
        public string Name { get; set; } = null!;
    }
}
