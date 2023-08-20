namespace EntityLayer.WebApplication.ViewModels.SkillViewModel
{
    public class SkillAdminListVM
    {
        //Primary Key
        public int Id { get; set; }

        //Information
        public string CreatedDate { get; set; } = null!;
        public string? UpdatedDate { get; set; } = null!;       

        //Status
        public bool IsPublished { get; set; }

        //Skill Section
        public string Title { get; set; } = null!;
        public byte Value { get; set; } 
    }
}
