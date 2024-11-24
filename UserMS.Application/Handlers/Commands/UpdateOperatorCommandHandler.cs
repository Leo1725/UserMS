using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMs.Infrastructure.Exceptions;
using UserMS.Application.Commands;
using UserMS.Application.Validators;
using UserMS.Core.Repositories;

namespace UserMS.Application.Handlers.Commands
{
    public class UpdateOperatorCommandHandler : IRequestHandler<UpdateOperatorCommand, String>
    {
        private readonly IOperatorRepository _operatorRepository;
        public UpdateOperatorCommandHandler(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        public async Task<String> Handle(UpdateOperatorCommand request, CancellationToken cancellationToken) {
            
            //var validator = new CreateOperatorValidator();
            //await validator.ValidateRequest(request.Operator);

            //estoy guardando en opEntity la entidad operator que quiero actualizar
            var OpEntity = await _operatorRepository.GetByIdAsync(request.Op.OperatorId);

            //si no consigo al operador entonces lanza excepcion
            if (OpEntity == null) { throw new OperatorNotFoundException("Operator not found."); }

            //Ahora voy a ir comparando las propiedades que recibi del dto con la entidad que busque
            //es decir solo va a cambiar propiedades en la entidad que sean pasadas por el dto
            if (request.Op.Name != null) 
            { 
                OpEntity.Name = request.Op.Name; 
            }
            if (request.Op.Age.HasValue)
            {
                OpEntity.Age = request.Op.Age.Value;
            }
            if (request.Op.State.HasValue)
            {
                OpEntity.State = request.Op.State.Value;
            }

            //ahora llamo al metodo del repo que me actualiza y le paso la entidad que busque con los parametros pasados del dto
            await _operatorRepository.UpdateAsync(OpEntity);

            return "Operator Actualizado Correctamente";
        }
    }
}
