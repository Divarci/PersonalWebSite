using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.CertificateViewModel;
using EntityLayer.WebApplication.ViewModels.EducationViewModel;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Exceptions.Filters;
using ServiceLayer.Services.WebApplication.Abstract;

namespace PortfolioWithBlog.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminObserverPolicy")]
    [Area("Admin")]
    public class CertificateController : Controller
    {
        private readonly ICertificateService _certificateService;
        private readonly IValidator<CertificateUpdateVM> _validatorUpdate;
        private readonly IValidator<CertificateAddVM> _validatorAdd;

        public CertificateController(ICertificateService certificateService, IValidator<CertificateUpdateVM> validatorUpdate, IValidator<CertificateAddVM> validatorAdd)
        {
            _certificateService = certificateService;
            _validatorUpdate = validatorUpdate;
            _validatorAdd = validatorAdd;
        }

        //List
        public async Task<IActionResult> CertificateList()
        {
            var certificates = await _certificateService.GetCertificateListAsync();
            return View(certificates);
        }

        //Add
        [HttpGet]
        public IActionResult CertificateAdd()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> CertificateAdd(CertificateAddVM request)
        {
            var resultCertificate = await _validatorAdd.ValidateAsync(request);
            if (resultCertificate.IsValid)
            {
                await _certificateService.AddCertificateAsync(request);
                return RedirectToAction("CertificateList", "Certificate", new { Area = ("Admin") });
            }
            else
            {
                resultCertificate.AddToModelState(this.ModelState);
                return View();
            }
        }
        
        //Update
        [ServiceFilter(typeof(GenericNotFoundFilter<Certificate>))]
        [HttpGet]
        public async Task<IActionResult> CertificateUpdate(int id)
        {
            var certificate = await _certificateService.GetCertificateByIdAsync(id);
            return View(certificate);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> CertificateUpdate(CertificateUpdateVM request)
        {
            var resultCertificate = await _validatorUpdate.ValidateAsync(request);
            if (resultCertificate.IsValid)
            {
                await _certificateService.UpdateCertificateAsync(request);
                return RedirectToAction("CertificateList", "Certificate", new { Area = ("Admin") });
            }
            else
            {
                resultCertificate.AddToModelState(this.ModelState);
                return View();
            }
        }

        //Delete
        [ServiceFilter(typeof(GenericNotFoundFilter<Certificate>))]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CertificateDelete(int id)
        {
            await _certificateService.DeleteCertificateAsync(id);
            return RedirectToAction("CertificateList", "Certificate", new { Area = ("Admin") });

        }
    }
}
