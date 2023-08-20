using CoreLayer.BaseEntity;

namespace EntityLayer.WebApplication.Entities
{
    public class HomePage : BaseEntity
    {
        //HomePage Section
        public string FullName { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
        public string Description { get; set; } = null!;

        //Status
        public bool IsPublished { get; set; }
        public bool IsEdited { get; set; }

        //Resume Picture Section
        public string ResumeCvFileName { get; set; } = null!;   
        public string ResumeCvFileType { get; set; } = null!;

        //Relation With Resume(Parent)
        public int ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;
    }
}
