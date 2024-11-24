using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Application.Commands;
using UserMS.Core.Repositories;

namespace UserMS.Application.Handlers.Commands
{
    public class DeleteOperatorCommandHandler : IRequestHandler<DeleteOperatorCommand, Unit>
    {
        private readonly IOperatorRepository _operatorRepository;

        public DeleteOperatorCommandHandler(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        public async Task<Unit> Handle(DeleteOperatorCommand request, CancellationToken cancellationToken) {
             
            await _operatorRepository.DeleteAsync(request.OperatorId);
            return Unit.Value;
        }
    }
}
