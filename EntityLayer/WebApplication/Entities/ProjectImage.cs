using CoreLayer.BaseEntity;

namespace EntityLayer.WebApplication.Entities
{
    public class ProjectImage : BaseEntity
    {
        //ProjectImage Section
        public string FileName { get; set; } = null!;   
        public string FileType { get; set; } = null!;

        //Relation with Project(parent)
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
       
    }
}
