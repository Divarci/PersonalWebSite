using CoreLayer.BaseEntity;

namespace EntityLayer.WebApplication.Entities
{
    public class Education : BaseEntity
    {
        //Education Section
        public string Title { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string Location { get; set; } = null!;
        public short Priorty { get; set; }

        //Status
        public bool IsPublished { get; set; }
        public bool IsEdited { get; set; }

        //Relation with Resume(parent)
        public int ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;

    }
}
