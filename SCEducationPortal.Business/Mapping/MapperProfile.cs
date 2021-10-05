using AutoMapper;
using SCEducationPortal.Business.Commons.Models.CategoryModels;
using SCEducationPortal.Business.Commons.Models.EducationContentFileModels;
using SCEducationPortal.Business.Commons.Models.EducationContentModels;
using SCEducationPortal.Business.Commons.Models.EducationModels;
using SCEducationPortal.Business.Commons.Models.EducationUserModels;
using SCEducationPortal.Business.Commons.Models.UserModels;
using SCEducationPortal.Data.Authentication;
using SCEducationPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //User
            CreateMap<AppUser, UserResponse>();

            //Education
            CreateMap<Education, EducationResponse>();
            CreateMap<EducationRequest, Education>();

            //EducationContent
            CreateMap<EducationContent, EducationContentResponse>();
            CreateMap<EducationContentRequest, EducationContent>();

            //EducationContentFile
            CreateMap<EducationContentFile, EducationContentFileResponse>();
            CreateMap<EducationContentFileRequest, EducationContentFile>();

            //Category
            CreateMap<Category, CategoryResponse>();
            CreateMap<Category, CategoryListResponse>();

            //EducationUser
            CreateMap<EducationUser, EducationUserResponse>();
            CreateMap<EducationUserRequest, EducationUser>();
        }
    }

    public class ObjectMapper
    {
        public static IMapper Mapper
        {
            get { return mapper.Value; }
        }

        public static IConfigurationProvider Configuration
        {
            get { return config.Value; }
        }

        public static Lazy<IMapper> mapper = new Lazy<IMapper>(() =>
        {
            var mapper = new Mapper(Configuration);
            return mapper;
        });

        public static Lazy<IConfigurationProvider> config = new Lazy<IConfigurationProvider>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            return config;
        });
    }
}
