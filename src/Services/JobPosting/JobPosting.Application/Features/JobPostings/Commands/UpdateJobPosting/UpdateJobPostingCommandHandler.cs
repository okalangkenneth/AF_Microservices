using AutoMapper;
using JobPosting.Application.Contracts.Persistence;
using JobPosting.Application.Exceptions;
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
        private readonly ILogger<UpdateJobPostingCommandHandler> _logger;
        private readonly IMapper _mapper;
     

        public UpdateJobPostingCommandHandler(IJobPostingRepository jobPostingRepository, IMapper mapper, ILogger <UpdateJobPostingCommandHandler> logger)
        {
            _jobPostingRepository = jobPostingRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task <Unit>  Handle(UpdateJobPostingCommand request, CancellationToken cancellationToken)
        {
            var jobPostingToUpdate = await _jobPostingRepository.GetByIdAsync(request.Id);
            if (jobPostingToUpdate == null)
            {
               

                 throw new NotFoundException(nameof(Job_Posting),request.Id);
            }
            _mapper.Map(request, jobPostingToUpdate, typeof(UpdateJobPostingCommand), typeof(Job_Posting));

            await _jobPostingRepository.UpdateAsync(jobPostingToUpdate);

            _logger.LogInformation($" Job Posting{jobPostingToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
    
}
