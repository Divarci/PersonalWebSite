using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.CertificateViewModel;
using EntityLayer.WebApplication.ViewModels.ResumeViewModel;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.Repository.Generic.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer._SharedFolder.Messages.ToastyNotification;
using ServiceLayer.WebApplication.Services.Abstract;

namespace ServiceLayer.WebApplication.Services.Concrete
{
    public class CertificateService : ICertificateService
    {
        //Dependancy Injections
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Certificate> _certificateRepository;
        private readonly IToastNotification _toasty;
        private readonly IGenericMessages _messages;

        public CertificateService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toasty, IGenericMessages messages)
        {
            _certificateRepository = unitOfWork.GetGenericRepository<Certificate>();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _toasty = toasty;
            _messages = messages;

        }


        //ADMIN SIDE SERVICES-----------------

        //Listing Method
        public async Task<IEnumerable<CertificateAdminListVM>> GetCertificateListAsync()
        {
            var certificates = await _certificateRepository.Where(x => x.IsEdited == true).Include(x => x.Resume).OrderBy(x => x.Priorty).ProjectTo<CertificateAdminListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return certificates;
        }

        //add Method
        public async Task AddCertificateAsync(CertificateAddVM request)
        {
            var editableResume = await _unitOfWork.GetGenericRepository<Resume>().Where(x => x.IsEdited == true).ProjectTo<ResumeIdVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            request.ResumeId = editableResume.Id;
            request.IsPublished = editableResume.IsPublished;

            var certificate = _mapper.Map<Certificate>(request);
            await _certificateRepository.AddAsync(certificate);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddSuccessToastMessage(_messages.Add(certificate.Title), new ToastrOptions { Title = "Congratulations!" });
        }

        //Delete Method
        public async Task DeleteCertificateAsync(int id)
        {
            var certificate = await _certificateRepository.GetEntityByIdAsync(id);
            _certificateRepository.Delete(certificate);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddWarningToastMessage(_messages.Delete(certificate.Title), new ToastrOptions { Title = "Congratulations!" });
        }

        //Update Method
        public async Task UpdateCertificateAsync(CertificateUpdateVM request)
        {
            var certificate = _mapper.Map<Certificate>(request);
            _certificateRepository.Update(certificate);
            var errorMessage = await _unitOfWork.CommitAsync();
            if (errorMessage != string.Empty)
            {
                _toasty.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Opps!" });
                return;
            }
            _toasty.AddInfoToastMessage(_messages.Update(certificate.Title), new ToastrOptions { Title = "Congratulations!" });
        }

        //Selecting Method
        public async Task<CertificateUpdateVM> GetCertificateByIdAsync(int id)
        {
            var certificate = await _certificateRepository.Where(x => x.Id == id).ProjectTo<CertificateUpdateVM>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            return certificate;
        }



        //ADMIN SIDE SERVICES-----------------

        //Listing method
        public async Task<IEnumerable<CertificateUserListVM>> GetCertificateForUserListAsync()
        {
            var certificateList = await _certificateRepository.Where(x => x.IsPublished == true).OrderBy(x => x.Priorty).ProjectTo<CertificateUserListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return certificateList;
        }
    }

}
