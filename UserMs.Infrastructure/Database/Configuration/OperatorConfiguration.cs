using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using UserMS.Domain.Entities;

namespace UserMs.Infrastructure.Database.Configuration
{
    public class OperatorConfiguration : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> builder)
        {
            builder.Property(s => s.OperatorId).IsRequired();
            builder.Property(s => s.Name).IsRequired().HasMaxLength(20);
            builder.Property(s => s.State).IsRequired();
            builder.Property(s => s.Age).IsRequired();
        }
    }
}
