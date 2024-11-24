using UserMS.Application.Commands;
using UserMS.Application.Validators;
using UserMS.Core.Repositories;
using UserMS.Domain.Entities;
using MediatR;

namespace UserMS.Application.Handlers.Commands
{
    public class CreateOperatorCommandHandler : IRequestHandler<CreateOperatorCommand, Guid>
    {
        private readonly IOperatorRepository _operatorRepository;

        public CreateOperatorCommandHandler(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        public async Task<Guid> Handle(CreateOperatorCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOperatorValidator();
            await validator.ValidateRequest(request.Operator);

            var op = new Operator(
                //request.Operator.OperatorId,
                request.Operator.Name!,
                request.Operator.Age,
                request.Operator.State);
               

            await _operatorRepository.AddAsync(op);

            return op.OperatorId;
        }

    }
}
