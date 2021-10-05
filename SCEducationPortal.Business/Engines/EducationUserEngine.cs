using SCEducationPortal.Business.Commons.Models.EducationUserModels;
using SCEducationPortal.Business.IEngines;
using SCEducationPortal.Business.Mapping;
using SCEducationPortal.Data.Entities;
using SCEducationPortal.Data.Interfaces.EducationUserInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.Engines
{
    public class EducationUserEngine : AutoMapperService, IEducationUserEngine
    {
        private readonly IEducationUserRepository _educationUserRepository;
        public EducationUserEngine(IEducationUserRepository educationUserRepository)
        {
            _educationUserRepository = educationUserRepository;
        }

        public bool IsUserRegisteredEducation(EducationUserRequest request)
        {
            var response = false;
            var data = _educationUserRepository.GetEducationUser(request.UserId, request.EducationId);
            if(data != null)
            {
                response = true;
            }
            return response;
        }

        public EducationUserResponse CreateEducationUser(EducationUserRequest request)
        {
            var data = _educationUserRepository.GetEducationUser(request.UserId, request.EducationId);
            if(data != null)
            {
                return Mapper.Map<EducationUserResponse>(data);
            }
            else
            {
                var dbRequest = Mapper.Map<EducationUser>(request);
                dbRequest.Createdate = DateTime.Now;
                var response = _educationUserRepository.Add(dbRequest);
                _educationUserRepository.SaveChanges();
                return Mapper.Map<EducationUserResponse>(response);
            }
        }
    }
}
