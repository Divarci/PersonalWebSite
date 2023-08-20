using EntityLayer.WebApplication.ViewModels.CertificateViewModel;
using EntityLayer.WebApplication.ViewModels.EducationViewModel;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface ICertificateService
    {
        //ADMIN SIDE SERVICES-----------------

        //Signatures for methods
        Task<IEnumerable<CertificateAdminListVM>> GetCertificateListAsync();
        Task AddCertificateAsync(CertificateAddVM request);
        Task DeleteCertificateAsync(int id);
        Task UpdateCertificateAsync(CertificateUpdateVM request);
        Task<CertificateUpdateVM> GetCertificateByIdAsync(int id);


        //USER SIDE SERVICES-------------------

        //Signatures for methods
        Task<IEnumerable<CertificateUserListVM>> GetCertificateForUserListAsync();
    }
}
