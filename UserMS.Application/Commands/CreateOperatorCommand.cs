using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Commons.Dtos.Request;

namespace UserMS.Application.Commands
{
    public class CreateOperatorCommand : IRequest<Guid>
    {
        public CreateOperatorDto Operator { get; set; }

        public CreateOperatorCommand(CreateOperatorDto op)
        {
            Operator = op;
        }
    }
}
