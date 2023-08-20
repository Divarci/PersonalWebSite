using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.ProjectImageViewModel
{
    public class ProjectImageUpdateVM
    {
        //Primary Key
        public int Id { get; set; }

        //Check Constraint
        public byte[] RowVersion { get; set; } = null!;

        //ProjectImage Section
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;

        //Relation with Project(parent)
        public int ProjectId { get; set; }

        //Helper to pick file from cshtml
        [DisplayName("Project Photo")]
        public IFormFile Photo { get; set; } = null!;

        //Project information(Parent)
        public string Title { get; set; } = null!;
    }
}
