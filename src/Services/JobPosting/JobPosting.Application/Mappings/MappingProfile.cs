using AutoMapper;
using JobPosting.Application.Features.JobPostings.Commands.CreateJobPosting;
using JobPosting.Application.Features.JobPostings.Queries.GetJobPostingsList;
using JobPosting.Domain.Entities;

namespace JobPosting.Application.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Job_Posting,JobPostingsVm>().ReverseMap();
            CreateMap<Job_Posting, CreateJobPostingCommand>().ReverseMap();
        }

    }
}
