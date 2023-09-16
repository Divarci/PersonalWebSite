using EntityLayer.BlogApi.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.BlogApi.ViewModels.ArticleViewModels
{
    public class ArticleUpdateVM
    {

        //Primary Key
        public int Id { get; set; }

        //Information
        public string? UpdatedDate { get; set; }

        //Check Constraint
        public byte[] RowVersion { get; set; } = null!;

        //Article Section
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string? YoutubeUrl { get; set; }


        //Photo Add
        public IFormFile? Photo { get; set; }

        //category relation
        public int CategoryId { get; set; }
        public List<CategoryListVM>? Categories { get; set; }
    }
}
