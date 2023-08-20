using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.SkillViewModel
{
    public class SkillUpdateVM
    {
        //Primary key
        public int Id { get; set; }

        //Status
        public bool IsPublished { get; set; }
        public bool IsEdited { get; set; }

        //Check Constraint
        public byte[] RowVersion { get; set; } = null!;

        //Skill Section
        [DisplayName("Title")]
        public string Title { get; set; } = null!;
        [DisplayName("Value")]
        public byte Value { get; set; }

        //Relations with resume(Parent)
        public int ResumeId { get; set; }
    }
}
