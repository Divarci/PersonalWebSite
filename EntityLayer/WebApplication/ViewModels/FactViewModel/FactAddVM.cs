using System.ComponentModel;

namespace EntityLayer.WebApplication.ViewModels.FactViewModel
{
    public class FactAddVM
    {
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
