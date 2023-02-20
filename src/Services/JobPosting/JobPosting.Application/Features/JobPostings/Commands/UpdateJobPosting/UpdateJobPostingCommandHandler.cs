using AutoMapper;
using JobPosting.Application.Contracts.Persistence;
using JobPosting.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace JobPosting.Application.Features.JobPostings.Commands.UpdateJobPosting
{
    public class UpdateJobPostingCommandHandler : IRequestHandler<UpdateJobPostingCommand>
    {
       
        
        private readonly IJobPostingRepository _jobPostingRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateJobPostingCommandHandler> _logger;


        public async Task  Handle(UpdateJobPostingCommand request, CancellationToken cancellationToken)
        {
            var jobPostingToUpdate = await _jobPostingRepository.GetByIdAsync(request.Id);
            if (jobPostingToUpdate == null)
            {
                _logger.LogError("Job Posting doesnt exist in the datbase");

                // throw new NotFoundException(nameof(Job_Posting),request.Id);
            }
            _mapper.Map(request, jobPostingToUpdate, typeof(UpdateJobPostingCommand), typeof(Job_Posting));

            await _jobPostingRepository.UpdateAsync(jobPostingToUpdate);

            _logger.LogInformation($" Job Posting{jobPostingToUpdate.Id} is successfully updated.");

            
        }
    }
    
}
