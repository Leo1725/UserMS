using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMS.Commons.Enums;

namespace UserMS.Commons.Dtos.Request
{
    public record UpdateOperatorDto
    {
        public Guid OperatorId { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public OpState? State { get; set; }
    }
}
