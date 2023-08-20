using CoreLayer.BaseEntity;

namespace EntityLayer.WebApplication.Entities
{
    public class Skill : BaseEntity
    {
        //Skill Section
        public string Title { get; set; } = null!;
        public byte Value { get; set; }

        //Status
        public bool IsPublished { get; set; }
        public bool IsEdited { get; set; }


        //Relation with Resume(parent)
        public int ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;
    }
}
