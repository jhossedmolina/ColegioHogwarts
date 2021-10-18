using AutoMapper;
using ColegioHogwarts.Core.DTOs;
using ColegioHogwarts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColegioHogwarts.Infraestructure.Mappings
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Candidate, CandidateDto>().ReverseMap();

            CreateMap<Security, SecurityDto>().ReverseMap();
        }
    }
}
