using Microsoft.Extensions.DependencyInjection;
using SCEducationPortal.Business.Engines;
using SCEducationPortal.Business.IEngines;
using SCEducationPortal.Data.Interfaces.CategoryInterfaces;
using SCEducationPortal.Data.Interfaces.EducationContentFileInterfaces;
using SCEducationPortal.Data.Interfaces.EducationContentInterfaces;
using SCEducationPortal.Data.Interfaces.EducationInterfaces;
using SCEducationPortal.Data.Interfaces.EducationUserInterfaces;
using SCEducationPortal.Data.Repositories.CategoryRepositories;
using SCEducationPortal.Data.Repositories.EducationContentFileRepositories;
using SCEducationPortal.Data.Repositories.EducationContentRepositories;
using SCEducationPortal.Data.Repositories.EducationRepositories;
using SCEducationPortal.Data.Repositories.EducationUserRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.DependencyResolver
{
    public static class WebDI
    {
        public static IServiceCollection RegisterServicesForWeb(this IServiceCollection services)
        {
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IEducationEngine, EducationEngine>();

            services.AddScoped<IEducationContentRepository, EducationContentRepository>();
            services.AddScoped<IEducationContentEngine, EducationContentEngine>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryEngine, CategoryEngine>();

            services.AddScoped<IEducationContentFileRepository, EducationContentFileRepository>();
            services.AddScoped<IEducationContentFileEngine, EducationContentFileEngine>();

            services.AddScoped<IEducationUserRepository, EducationUserRepository>();
            services.AddScoped<IEducationUserEngine, EducationUserEngine>();




            return services;
        }
    }
}
