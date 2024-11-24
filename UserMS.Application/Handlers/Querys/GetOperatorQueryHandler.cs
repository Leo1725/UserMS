using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMs.Infrastructure.Exceptions;
using UserMS.Application.Querys;
using UserMS.Commons.Dtos.Response;
using UserMS.Core.Repositories;

namespace UserMS.Application.Handlers.Querys
{
    public class GetOperatorQueryHandler : IRequestHandler<GetOperatorQuery, GetOperatorDto>
    {
        private readonly IOperatorRepository _operatorRepository;

        public GetOperatorQueryHandler(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        public async Task<GetOperatorDto> Handle(GetOperatorQuery request, CancellationToken cancellationToken)
        {
            var op = await _operatorRepository.GetByIdAsync(request.Id);

            if (op == null)
                throw new OperatorNotFoundException("Operator not found.");
            //mapeando de la entidad al dto
            return new GetOperatorDto
            {
                OperatorId = op.OperatorId,
                Name = op.Name,
                Age = op.Age,
                State = op.State,

            };
        }
    }
}
