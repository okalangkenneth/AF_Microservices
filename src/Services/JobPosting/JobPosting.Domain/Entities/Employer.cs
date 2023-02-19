using JobPosting.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPosting.Domain.Entities
{
    public class Employer : EntityBase
    {
        public string CompanyName { get; set;}
        public string CompanyLocation { get; set; }
        public string Industry { get; set; }
        public string CompanyDescription { get; set; }
    }
}
