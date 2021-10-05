using SCEducationPortal.Business.Commons.Models.EducationModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.IEngines
{
    public interface IEducationEngine
    {
        List<EducationResponse> GetEducations();
        List<EducationResponse> GetEducations(int userId);
        EducationResponse GetEducationsDetail(int id);
        EducationResponse GetEducationsDetail(int id, int userId);

        EducationResponse InsertEducation(EducationRequest request);

        bool UpdateEducation(EducationRequest request);
        List<EducationResponse> GetEducations(int skip, int take);
        List<EducationResponse> GetEducations(int skip, int take, int categoryId);
        List<EducationResponse> TrainingsIAttended(int userId, int skip, int take);
    }
}
