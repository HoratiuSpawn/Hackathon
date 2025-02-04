﻿using AutoMapper;
using Hackathon.Models;
using Hackathon.Models.DTOs;

namespace Hackathon.Persistance.AutoMapper
{
    public class WorksMapper:Profile
    {
        public WorksMapper()
        {
            CreateMap<WorksDto, Works>()
                .ForMember(source => source.Id, option => option.Ignore())
                .ReverseMap();
        }
    }
}
