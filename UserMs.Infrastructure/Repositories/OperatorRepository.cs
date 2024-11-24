using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using UserMs.Infrastructure.Database;
using UserMs.Infrastructure.Exceptions;
using UserMS.Core.Repositories;
using UserMS.Domain.Entities;

namespace UserMs.Infrastructure.Repositories
{
    public class OperatorRepository : IOperatorRepository
    {
        private readonly OperatorDbContext _dbContext;

        public OperatorRepository(OperatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Operator?> GetByIdAsync(Guid operatorId)
        {
            return await _dbContext.Operators.FirstOrDefaultAsync(a => a.OperatorId == operatorId);
        }

        public async Task AddAsync(Operator op)
        {
            await _dbContext.Operators.AddAsync(op);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Operator>?> GetAllOperatorsAsync() {

            return await _dbContext.Operators.ToListAsync();
        }

        public async Task DeleteAsync(Guid OperatorId) {
            var operatorEntity = await _dbContext.Operators.FindAsync(OperatorId);
            if (operatorEntity == null) 
            { 
                throw new OperatorNotFoundException("Operator not found.");
            }

            //al parecer cuando elimino no necesito agregar el await para ese metodo en espcifico  
            _dbContext.Operators.Remove(operatorEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> UpdateAsync(Operator op) {
             _dbContext.Operators.Update(op);
            await _dbContext.SaveChangesAsync();
            return "Operador actualizado correctamente";
        }
    }
}
