using EntityLayer.BlogApi.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace EntityLayer.BlogApi.ViewModels.ArticleViewModels
{
    public class ArticleAddVM
    {
        //Article Section

        [DisplayName("Title")]
        public string Title { get; set; } = null!;

        [DisplayName("Content")]
        public string Content { get; set; } = null!;

        [DisplayName("Author")]
        public string Author { get; set; } = null!;

        [DisplayName("Youtube Url")]
        public string? YoutubeUrl { get; set; }

        //Photo Add
        public IFormFile Photo { get; set; } = null!;

        //category relation
        [DisplayName("Category")]
        public int? CategoryId { get; set; }
        public List<CategoryListVM>? Categories { get; set; }
    }
}
