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
            entityTypeBuilder.Property(x => x.LastName).IsRequired();
            entityTypeBuilder.Property(x => x.NumberDocument).IsRequired();
            entityTypeBuilder.Property(x => x.Password).IsRequired();
            entityTypeBuilder.Property(x => x.Code).IsRequired();
        }
    }
}
