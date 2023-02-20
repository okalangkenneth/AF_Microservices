using JobPosting.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobPosting.Application.Contracts.Persistence
{
    public interface IEmployerRepository : IAsyncRepository<Job_Posting>
    {
        Task<IEnumerable<Job_Posting>> GetEmployersByUserName(string userName);
    }
}
