using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.FactViewModel
{
    public class FactUpdateVM
    {
        //Primary Key
        public int Id { get; set; }
               
        //Check Constraint
        public byte[] RowVersion { get; set; } = null!;

        //Fact Section
        [DisplayName("Days Of Study")]
        public int DaysOfStudy { get; set; }
        [DisplayName("Project")]
        public int Project { get; set; }
        [DisplayName("Coding Language")]
        public int CodingLanguage { get; set; }
        [DisplayName("Certificate")]
        public int Certificate { get; set; }
    }
}
