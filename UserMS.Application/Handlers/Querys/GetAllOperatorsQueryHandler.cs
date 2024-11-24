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
    public class GetAllOperatorsQueryHandler : IRequestHandler<GetAllOperatorsQuery, List<GetAllOperatorsDto>>
    {
        private readonly IOperatorRepository _operatorRepository;

        public GetAllOperatorsQueryHandler(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        public async Task<List<GetAllOperatorsDto>> Handle(GetAllOperatorsQuery request, CancellationToken cancellationToken)
        {
            var operators = await _operatorRepository.GetAllOperatorsAsync();

            if (operators == null)
            {
                throw new OperatorNotFoundException("Operators not found.");

            }
            else
            {
                //como el handler debe retonar una lista de dto correspondiente se deben mapear los datos de las entidades a dto
                var operatorsDto = operators.Select(o => new GetAllOperatorsDto { 
                    OperatorId = o.OperatorId,
                    Name = o.Name,
                    Age = o.Age,
                    State = o.State,
                }).ToList();
                    
               return operatorsDto;
                
                
            }
        }
    }
}
