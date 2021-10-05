using SCEducationPortal.Business.Commons.Models.EducationContentFileModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.IEngines
{
    public interface IEducationContentFileEngine
    {
        EducationContentFileResponse InsertEducationContentFile(EducationContentFileRequest request);
    }
}
