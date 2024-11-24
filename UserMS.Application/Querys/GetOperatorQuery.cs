using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Commons.Dtos.Response;

namespace UserMS.Application.Querys
{
    public class GetOperatorQuery : IRequest<GetOperatorDto>
    {
        public Guid Id { get; set; }

        public GetOperatorQuery(Guid id)
        {
            Id = id;
        }
    }
}
