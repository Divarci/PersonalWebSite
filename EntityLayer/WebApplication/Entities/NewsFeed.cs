using CoreLayer.BaseEntity;
using System.ComponentModel;

namespace EntityLayer.WebApplication.Entities
{
    public class NewsFeed : BaseEntity
    {
        //NewsFeed Section
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        //Picture section
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;
    }
}
