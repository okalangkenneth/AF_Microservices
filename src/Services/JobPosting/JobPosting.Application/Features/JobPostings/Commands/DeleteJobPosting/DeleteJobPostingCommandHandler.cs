﻿using AutoMapper;
using JobPosting.Application.Contracts.Persistence;
using JobPosting.Application.Exceptions;
using JobPosting.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace JobPosting.Application.Features.JobPostings.Commands.DeleteJobPosting
{
    public class DeleteJobPostingCommandHandler : IRequestHandler<DeleteJobPostingCommand>
    {
        private readonly IJobPostingRepository _jobPostingRepository;
        private readonly ILogger<DeleteJobPostingCommandHandler> _logger;
        private readonly IMapper _mapper;



        public DeleteJobPostingCommandHandler(IJobPostingRepository jobPostingRepository, IMapper mapper, ILogger<DeleteJobPostingCommandHandler> logger)
        {
            _jobPostingRepository = jobPostingRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task  Handle(DeleteJobPostingCommand request, CancellationToken cancellationToken)
        {
            var jobPostingToDelete = await _jobPostingRepository.GetByIdAsync(request.Id);
            if (jobPostingToDelete == null)
            {
                

                throw new NotFoundException(nameof(Job_Posting),request.Id);
            }


            await _jobPostingRepository.DeleteAsync(jobPostingToDelete);
            _logger.LogInformation($" Job Posting{jobPostingToDelete.Id} is successfully deleted.");


            

        }
    }
}
