using AutoMapper;
using Lw.Domain.Entities;
using Lw.DTO.DTOs;
using Lw.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw.DTO.Mappings
{
    /// <summary>
    /// MappingProfiles
    /// </summary>
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Mapping profiles constructor
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<TranslationDTO, Translation>();
            CreateMap<Translation, TranslationDTO>()
                 .ForMember(destination => destination.LanguageISO,
                 opt => opt.MapFrom(source => Enum.GetName(typeof(LanguageEnum), source.LanguageId)));
        }
    } 
}