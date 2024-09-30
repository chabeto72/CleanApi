using Domain.Entities.Rol;
using Domain.Entities.Task;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class RolConfiguration
    {
        public RolConfiguration(EntityTypeBuilder<RolEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.RolID);
            entityTypeBuilder.Property(x => x.RolName).IsRequired();
            entityTypeBuilder.Property(x => x.Code);
          

            entityTypeBuilder.HasMany(x => x.Users).WithOne(x => x.Rol).HasForeignKey(x => x.UserId);
        }
    }
}
