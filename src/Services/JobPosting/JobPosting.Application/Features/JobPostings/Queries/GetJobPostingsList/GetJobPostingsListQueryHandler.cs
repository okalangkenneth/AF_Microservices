using AutoMapper;
using JobPosting.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JobPosting.Application.Features.JobPostings.Queries.GetJobPostingsList
{
    public class GetJobPostingsListQueryHandler : IRequestHandler<GetJobPostingsListQuery, List<JobPostingsVm>>
    {

        private readonly IJobPostingRepository _jobPostingRepository;
        private readonly IMapper _mapper;

        public GetJobPostingsListQueryHandler(IJobPostingRepository jobPostingRepository, IMapper mapper)
        {
            _jobPostingRepository = jobPostingRepository;
            this._mapper = mapper;
        }

        public async Task<List<JobPostingsVm>> Handle(GetJobPostingsListQuery request, CancellationToken cancellationToken)
        {

            var jobPostingList = await _jobPostingRepository.GetJobPostingsByUserName(request.UserName);
            return _mapper.Map<List<JobPostingsVm>>(jobPostingList);

        }
    }
}
