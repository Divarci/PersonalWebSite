using Microsoft.AspNetCore.Mvc;
using ServiceLayer.WebApplication.Services.Abstract;

namespace PortfolioWithBlog.ViewComponents
{
    public class CertificateUserViewComponent : ViewComponent
    {
        private readonly ICertificateService _certificateService;

        public CertificateUserViewComponent(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var certificateList = await _certificateService.GetCertificateForUserListAsync();
            return View(certificateList);
        }
    }
}
