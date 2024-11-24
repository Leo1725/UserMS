using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Commons.Dtos.Response;

namespace UserMS.Application.Querys
{
    public class GetAllOperatorsQuery : IRequest<List<GetAllOperatorsDto>>
    {
        public GetAllOperatorsQuery() { }
    }
}
