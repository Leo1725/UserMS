using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using UserMS.Domain.Entities;

namespace UserMS.Core.DataBase
{
    public interface IOperatorDbContext
    {
         
        DbContext DbContext { get; }

        DbSet<Operator> Operators { get; set; }

        IDbContextTransactionProxy BeginTransaction();

        void ChangeEntityState<TEntity>(TEntity entity, EntityState state);

        Task<bool> SaveEfContextChanges(string user, CancellationToken cancellationToken = default);
    }
}

