using AutoMapper;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config => {
                config.AddProfile(new EntityToViewModelMappingProfile());
                config.AddProfile(new ViewModelToEntityMappingProfile());
            });
        }
    }
}
