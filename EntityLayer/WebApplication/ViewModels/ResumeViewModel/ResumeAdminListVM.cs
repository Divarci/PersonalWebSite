namespace EntityLayer.WebApplication.ViewModels.ResumeViewModel
{
    public class ResumeAdminListVM
    {
        //Primary Key
        public int Id { get; set; }

        //Status
        public bool IsPublished { get; set; }
        public bool IsEdited { get; set; }

        //Resume Section
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
