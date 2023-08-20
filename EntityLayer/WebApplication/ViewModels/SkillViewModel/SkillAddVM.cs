using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.SkillViewModel
{
    public class SkillAddVM
    {
        //Skill Section
        [DisplayName("Title")]
        public string Title { get; set; } = null!;
        [DisplayName("Value")]
        public byte Value { get; set; }    

        //Status
        public bool IsPublished { get; set; }

        //Relation with resume(Parent)
        public int ResumeId { get; set; }
    }
}
