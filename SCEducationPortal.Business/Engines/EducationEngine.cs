using SCEducationPortal.Business.Commons.Models.EducationModels;
using SCEducationPortal.Business.Commons.Models.EducationUserModels;
using SCEducationPortal.Business.IEngines;
using SCEducationPortal.Business.Mapping;
using SCEducationPortal.Data.Entities;
using SCEducationPortal.Data.Interfaces.EducationInterfaces;
using SCEducationPortal.Data.Interfaces.EducationUserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCEducationPortal.Business.Engines
{
    class EducationEngine : AutoMapperService, IEducationEngine
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IEducationUserRepository _educationUserRepository;
        public EducationEngine(IEducationRepository educationRepository, IEducationUserRepository educationUserRepository)
        {
            _educationRepository = educationRepository;
            _educationUserRepository = educationUserRepository;
        }
        public List<EducationResponse> GetEducations()
        {
            var list = _educationRepository.GetEducations();
            return Mapper.Map<List<EducationResponse>>(list);
        }
        public EducationResponse GetEducationsDetail(int id)
        {
            var data = _educationRepository.GetEducationDetail(id);
            return Mapper.Map<EducationResponse>(data);
        }

        public EducationResponse GetEducationsDetail(int id, int userId)
        {
            var data = _educationRepository.GetEducationDetail(id);
            if(userId == data.UserId)
            {
                return Mapper.Map<EducationResponse>(data);
            }else
            {
                return null;
            }
            
        }

        public List<EducationResponse> GetEducations(int userId)
        {
            var list = _educationRepository.GetEducations(userId);
            return Mapper.Map<List<EducationResponse>>(list);
        }

        public List<EducationResponse> GetEducations(int skip, int take)
        {
            var list = _educationRepository.GetEducations(skip, take);
            return Mapper.Map<List<EducationResponse>>(list);
        }

        public List<EducationResponse> GetEducations(int skip, int take, int categoryId)
        {
            var list = _educationRepository.GetEducations(skip, take, categoryId);
            return Mapper.Map<List<EducationResponse>>(list);
        }

        public List<EducationResponse> TrainingsIAttended(int userId, int skip, int take)
        {
            var educationUserList = _educationUserRepository.TrainingsIAttended(userId,skip,take);
            List<int> educationIdList = educationUserList.Select(s => s.EducationId).ToList();
            var data = _educationRepository.GetEducations(educationIdList);

            return Mapper.Map<List<EducationResponse>>(data);
        }

        public EducationResponse InsertEducation(EducationRequest request)
        {
            request.CreateDate = DateTime.Now;
            request.IsActive = true;
            var education = Mapper.Map<Education>(request);
            var data = _educationRepository.Add(education);
            _educationRepository.SaveChanges();
            return Mapper.Map<EducationResponse>(education);
        }

        public bool UpdateEducation(EducationRequest request)
        {
            bool response = false;
            var oldEducation = _educationRepository.Get(request.Id);
            if(oldEducation.UserId == request.UserId)
            {
                try
                {
                    oldEducation.Title = request.Title;
                    oldEducation.CategoryId = request.CategoryId;
                    oldEducation.Quota = request.Quota;
                    oldEducation.Description = request.Description;
                    _educationRepository.SaveChanges();
                    response = true;
                }
                catch (Exception)
                {
                    response = false;
                }
            }
            return response;
        }
    }
}
