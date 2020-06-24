using AutoMapper;
using Genpad.DTOs;
using Genpad.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genpad.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CardDTO, Card>();
            CreateMap<Card, CardDTO>();
        }
    }
}
