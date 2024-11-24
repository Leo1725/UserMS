using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Commons.Dtos.Request;

namespace UserMS.Application.Commands
{
    public class UpdateOperatorCommand : IRequest<string>
    {
        public UpdateOperatorDto Op { get; set; }

        public UpdateOperatorCommand(UpdateOperatorDto op)
        {
            Op = op;
        }
    }
}
