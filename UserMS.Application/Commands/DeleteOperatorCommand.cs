using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Commons.Dtos.Request;

namespace UserMS.Application.Commands
{
    public class DeleteOperatorCommand : IRequest<Unit>
    {
        //public DeleteOperatorDto OperatorDto { get; set; }
        public Guid OperatorId { get; set; }
        public DeleteOperatorCommand(Guid op)
        {
            OperatorId = op;
        }
    }
}
