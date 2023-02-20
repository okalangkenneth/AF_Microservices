using MediatR;
using System.Collections.Generic;

namespace JobPosting.Application.Features.JobPostings.Queries.GetJobPostingsList
{
    public class GetJobPostingsListQuery : IRequest<List<JobPostingsVm>>
    {
        public string UserName { get; set; }


        public GetJobPostingsListQuery(string userName)
        {
            UserName = userName;
        }
    }
}
