using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.Mapping
{
    public abstract class AutoMapperService : IAutoMapperService
    {
        public IMapper Mapper
        {
            get { return ObjectMapper.Mapper; }
        }
    }

    public interface IAutoMapperService
    {
        IMapper Mapper { get; }
    }
}
