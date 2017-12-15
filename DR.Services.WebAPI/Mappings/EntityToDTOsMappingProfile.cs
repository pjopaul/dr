using AutoMapper;
using DR.Core.Entities;
using DR.Services.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DR.Services.WebAPI.Mappings
{
    public class EntityToDTOsMappingProfile : Profile
    {
        public EntityToDTOsMappingProfile()
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<EventNotification, NotificationDTO>()
            //                           .ForMember(destination => destination.NotificationType,
            //                                       opt => opt.MapFrom(source => Enum.GetName(typeof(EventNotificationType),
            //                                                           source.NotificationType))
            //                                      )
            //                           .ForMember(destination => destination.IsAutoResponded,
            //                           opt => opt.MapFrom(source => source.NotificationType == EventNotificationType.AutoResponded)
            //                           )

            //                 );

            this.CreateMap< User, UserDTO>()
                .ForMember(d => d.UserRole,
                           v => v.MapFrom(s => Enum.GetName(typeof(UserRole), s.UserRoleId)));

        }

        public override string ProfileName
        {
            get { return "EntityToDTOsMapping"; }
        }
    }
}