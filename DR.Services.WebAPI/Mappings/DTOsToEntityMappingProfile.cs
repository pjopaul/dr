using AutoMapper;
using DR.Core.Entities;
using DR.Services.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DR.Services.WebAPI.Mappings
{
    public class DTOsToEntityMappingProfile : Profile
    {
        public DTOsToEntityMappingProfile()
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

            this.CreateMap<UserDTO, User>()
                .ForMember(d => d.UserRoleId,
                           v => v.MapFrom(s => (int)Enum.Parse(typeof(UserRole), s.UserRole, true)));

        }

        public override string ProfileName
        {
            get { return "DTOsToEntityMapping"; }
        }
    }
}