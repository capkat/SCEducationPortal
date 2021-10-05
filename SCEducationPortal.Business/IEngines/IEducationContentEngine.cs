using SCEducationPortal.Business.Commons.Models.EducationContentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.IEngines
{
    public interface IEducationContentEngine
    {
        EducationContentResponse InsertEducationContent(EducationContentRequest request);
        EducationContentResponse GetEducationContent(int id);
        EducationContentResponse UpdateEducationContent(EducationContentRequest request);
    }
}
