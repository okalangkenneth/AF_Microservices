using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JobPosting.Application.Behaviours
{
    public class ValidationsBehaviour<TRequest, TResponse> : IPipelineBehavior<IRequest, TResponse>

    {
        public Task<TResponse> Handle(IRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
