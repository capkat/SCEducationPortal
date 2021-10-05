using SCEducationPortal.Business.Commons.Models.EducationUserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.IEngines
{
    public interface IEducationUserEngine
    {
        bool IsUserRegisteredEducation(EducationUserRequest request);
        EducationUserResponse CreateEducationUser(EducationUserRequest request);
    }
}
