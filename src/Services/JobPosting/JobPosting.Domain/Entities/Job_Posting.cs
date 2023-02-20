using JobPosting.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting.Domain.Entities
{
    public class Job_Posting : EntityBase
    {
        public string JobCategory { get; set;}
        public string JobCategoryDescription { get; set; }
        public ICollection<Job_Posting> JobPostings { get; set; }
    }
}
