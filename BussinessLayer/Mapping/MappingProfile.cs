using BussinessLayer.ViewModels;
using DataAccessLayer.Models;
using AutoMapper;

namespace BussinessLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CandidateVM, Candidate>().ReverseMap();
        }
    }
}
