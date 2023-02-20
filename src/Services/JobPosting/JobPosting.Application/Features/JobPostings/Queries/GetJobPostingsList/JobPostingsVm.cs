using JobPosting.Domain.Entities;
using System.Collections.Generic;

namespace JobPosting.Application.Features.JobPostings.Queries.GetJobPostingsList
{
    public class JobPostingsVm
    {
        public int Id { get; set; }
        public string JobCategory { get; set; }
        public string JobCategoryDescription { get; set; }
        public ICollection<Job_Posting> JobPostings { get; set; }
    }
}

