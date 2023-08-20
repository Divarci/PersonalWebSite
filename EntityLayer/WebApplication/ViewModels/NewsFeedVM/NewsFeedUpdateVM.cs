using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.NewsFeedVM
{
    public class NewsFeedUpdateVM
    {
        //Primary Key
        public int Id { get; set; }

        //Check Constraint
        public byte[] RowVersion { get; set; } = null!;

        //NewsFeed Section
        [DisplayName("Title")]
        public string Title { get; set; } = null!;
        [DisplayName("Description")]
        public string Description { get; set; } = null!;

        //Picture Section
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;

        //Helper to pick file from cshtml
        [DisplayName("Photo")]
        public IFormFile? Photo { get; set; }
    }
}
