using SCEducationPortal.Business.Commons.Models.EducationContentModels;
using SCEducationPortal.Business.IEngines;
using SCEducationPortal.Business.Mapping;
using SCEducationPortal.Data.Entities;
using SCEducationPortal.Data.Interfaces.EducationContentInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.Engines
{
    public class EducationContentEngine : AutoMapperService, IEducationContentEngine
    {
        private readonly IEducationContentRepository _educationContentRepository;
        public EducationContentEngine(IEducationContentRepository educationContentRepository)
        {
            _educationContentRepository = educationContentRepository;
        }

        public EducationContentResponse InsertEducationContent(EducationContentRequest request)
        {
            request.CreateDate = DateTime.Now;
            request.IsActive = true;
            var educationContent = Mapper.Map<EducationContent>(request);
            var data = _educationContentRepository.Add(educationContent);
            _educationContentRepository.SaveChanges();
            return Mapper.Map<EducationContentResponse>(educationContent);
        }

        public EducationContentResponse GetEducationContent(int id)
        {
            var data = _educationContentRepository.GeteducationContent(id);
            return Mapper.Map<EducationContentResponse>(data);
        }

        public EducationContentResponse UpdateEducationContent(EducationContentRequest request)
        {
            var oldEducationContent = _educationContentRepository.Get(request.Id);
            oldEducationContent.Title = request.Title;
            oldEducationContent.Description = request.Description;
            _educationContentRepository.SaveChanges();
            return Mapper.Map<EducationContentResponse>(oldEducationContent);
        }
    }
}
