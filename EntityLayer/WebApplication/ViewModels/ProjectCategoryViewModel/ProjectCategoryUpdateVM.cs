using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.ProjectCategoryViewModel
{
    public class ProjectCategoryUpdateVM
    {
        //Primary Key
        public int Id { get; set; }
              
        //Check Constraint
        public byte[] RowVersion { get; set; } = null!;

        //Project Category Section
        [DisplayName("Title")]
        public string Title { get; set; } = null!;
        [DisplayName("Description")]
        public string Description { get; set; } = null!;

        //Status
        public bool IsPublished { get; set; }
        public bool IsEdited { get; set; }

        //Relation with Resume(parent)
        public int ResumeId { get; set; }


    }
}
