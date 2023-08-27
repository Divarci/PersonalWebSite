using EntityLayer.BlogApi.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Http;

namespace EntityLayer.BlogApi.ViewModels.ArticleViewModels
{
    public class ArticleAddVM
    {
        //Article Section
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Author { get; set; } = null!;       

        //Photo Add
        public IFormFile Photo { get; set; } = null!;

        //category relation
        public int? CategoryId { get; set; }
        public List<CategoryListVM>? Categories { get; set; }
    }
}
