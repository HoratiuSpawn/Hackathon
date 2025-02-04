﻿using AutoMapper;
using Hackathon.Models;
using Hackathon.Models.DTOs;

namespace Hackathon.Persistance.AutoMapper
{
    public class StatusMapper: Profile
    {
        public StatusMapper()
        {
            CreateMap<StatusDto, Status>()
                .ForMember(source => source.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}
