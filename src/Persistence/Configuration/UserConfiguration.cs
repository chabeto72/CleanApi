using Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.UserId);
            entityTypeBuilder.Property(x => x.FirtsName).IsRequired();
            //entityTypeBuilder.Property(x => x.RolId);
            entityTypeBuilder.Property(x => x.Email);
            entityTypeBuilder.Property(x => x.NumberDocument).IsRequired();
            entityTypeBuilder.Property(x => x.Password);
            entityTypeBuilder.Property(x => x.Active);
            entityTypeBuilder.Property(x => x.Address);

            entityTypeBuilder.HasMany(x => x.Tasks).WithOne(x => x.User).HasForeignKey(x => x.UserTask);
            entityTypeBuilder.HasOne(x => x.Rol).WithMany(x => x.Users).HasForeignKey(x => x.RolUser).HasPrincipalKey(x => x.RolID);
        }
    }
}
