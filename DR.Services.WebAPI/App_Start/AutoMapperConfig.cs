using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DR.Services.WebAPI.Mappings;

namespace DR.Services.WebAPI
{
    //Auto mapper configurations
    public static class AutoMapperConfig
    {

        public static void Configure()
        {
            //Configure the mapping

            Mapper.Initialize(x =>
            {
                x.AddProfile<EntityToDTOsMappingProfile>();
                x.AddProfile<DTOsToEntityMappingProfile>();
            }
            );
        }
    }
}
