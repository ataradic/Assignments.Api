using System.Linq;
using AssignmentsAPI.DTOs;
using AssignmentsAPI.Entities;
using AutoMapper;

namespace AssignmentsAPI.Helpers

{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<CreateAssignmentDto, Assignment>();
                 CreateMap<Type, TypeDto>();
            CreateMap<Assignment, AssignmentDto>().ForMember(dest => dest.AssignmentType, opt => opt.MapFrom(src =>
                 src.AssignmentType.Name)) ;
      

        }
    }
}