using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMS.Commons.Dtos.Request
{
    public record DeleteOperatorDto
    {
        public Guid OperatorId { get; set; }
    }
}
