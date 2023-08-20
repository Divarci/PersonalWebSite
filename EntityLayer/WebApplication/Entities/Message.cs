using CoreLayer.BaseEntity;

namespace EntityLayer.WebApplication.Entities
{
    public class Message : BaseEntity
    {
        //Message Section
        public string Sender { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Description { get; set; } = null!;

        //Status
        public bool IsEdited { get; set; }


        //Relation with Resume(parent)
        public int ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;
    }
}
