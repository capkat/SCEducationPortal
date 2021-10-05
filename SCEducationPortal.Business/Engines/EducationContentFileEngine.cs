using SCEducationPortal.Business.Commons.Models.EducationContentFileModels;
using SCEducationPortal.Business.IEngines;
using SCEducationPortal.Business.Mapping;
using SCEducationPortal.Data.Entities;
using SCEducationPortal.Data.Interfaces.EducationContentFileInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.Engines
{
    public class EducationContentFileEngine : AutoMapperService, IEducationContentFileEngine
    {
        private readonly IEducationContentFileRepository _educationContentFileRepository;
        public EducationContentFileEngine(IEducationContentFileRepository educationContentFileRepository)
        {
            _educationContentFileRepository = educationContentFileRepository;
        }

        public EducationContentFileResponse InsertEducationContentFile(EducationContentFileRequest request)
        {
            request.CreateDate = DateTime.Now;
            request.IsActive = true;
            var educationContentFile = Mapper.Map<EducationContentFile>(request);
            var data = _educationContentFileRepository.Add(educationContentFile);
            _educationContentFileRepository.SaveChanges();
            return Mapper.Map<EducationContentFileResponse>(educationContentFile);
        }



    }
}
