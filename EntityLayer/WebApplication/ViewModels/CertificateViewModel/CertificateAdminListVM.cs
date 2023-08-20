using EntityLayer.WebApplication.Entities;

namespace EntityLayer.WebApplication.ViewModels.CertificateViewModel
{
    public class CertificateAdminListVM
    {
        //Primary Key
        public int Id { get; set; }

        //Informaton
        public string CreatedDate { get; set; } = null!;
        public string? UpdatedDate { get; set; }

        //Status
        public bool IsPublished { get; set; }

        //Certificate Section
        public string Title { get; set; } = null!;  
        public string Date { get; set; } = null!;
        public string Location { get; set; } = null!;
        public short Priorty { get; set; }

    }
}
