using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using UserMS.Domain.Entities;

namespace UserMS.Core.Repositories
{
    public interface IOperatorRepository
    {
        Task<Operator?> GetByIdAsync(Guid operatorId);
        Task<List<Operator>?> GetAllOperatorsAsync();
        Task AddAsync(Operator op);
        Task DeleteAsync(Guid operatorId);

        Task<string> UpdateAsync(Operator op);
    }
}
