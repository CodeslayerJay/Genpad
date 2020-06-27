using AutoMapper;
using Genpad.Data.DTO;
using Genpad.Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genpad.Services.Configurations
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Card, CardDTO>();
            CreateMap<CardDTO, Card>();
        }
    }
}
