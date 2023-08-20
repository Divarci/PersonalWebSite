using EntityLayer.WebApplication.Entities;

namespace EntityLayer.WebApplication.ViewModels.MessageViewModel
{
    public class MessageAdminListVM
    {
        //Primary Key
        public int Id { get; set; }

        //Information
        public string CreatedDate { get; set; } = null!;

        //Message Section
        public string Sender { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Email { get; set; } = null!;

        //Relation with Resume(parent)
        public Resume Resume { get; set; } = null!; 
    }
}
