using JobPosting.Domain.Common;
using JobPosting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace JobPosting.Infrastructure.Persistence
{
    public class JobPostingContext :DbContext
    {
        public JobPostingContext(DbContextOptions<JobPostingContext> options): base(options)
        {

        }
        public DbSet<Job_Posting> Job_Postings { get; set; }

        public override Task<int> SaveChangesAsync (CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.JobCategory = "Programming";
                        entry.Entity.JobCategoryDescription = "Python,C#, JavaScript";
                        break;
                    case EntityState.Modified:
                        entry.Entity.JobCategory = "Programming";
                        entry.Entity.JobCategoryDescription = "Python,C#, JavaScript";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);



           
        }


    }
}
