using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.NewsFeedVM
{
    public class NewsFeedAdminListVM
    {
        //Primary Key
        public int Id { get; set; }

        //Information
        [DisplayName("Create Date")]
        public string CreatedDate { get; set; } = null!;
        [DisplayName("Update Date")]
        public string? UpdatedDate { get; set; }

        //NewsFeed Section
        [DisplayName("Title")]
        public string Title { get; set; } = null!;
        [DisplayName("Description")]
        public string Description { get; set; } = null!;
    }
}
