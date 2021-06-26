﻿using AutoMapper;
using Hackathon.Abstractions.Repositories;
using Hackathon.Abstractions.Services;
using Hackathon.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class PinTypesService: IPinTypesService
    {
        private readonly IPinTypesRepository _pinTypesRepository;
        private readonly IMapper _mapper;

        public PinTypesService()
        {
        }

        public PinTypesService(IPinTypesRepository pinTypesRepository, IMapper mapper)
        {
            _pinTypesRepository = pinTypesRepository;
            _mapper = mapper;
        }

        public async Task<List<PinTypesDto>> GetAllAsync()
        {
            var pinTypesList = await _pinTypesRepository.GetAllAsync();

            return _mapper.Map<List<PinTypesDto>>(pinTypesList);

        }
    }
}
