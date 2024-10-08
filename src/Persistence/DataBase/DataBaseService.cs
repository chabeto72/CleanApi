
using Application.DataBase;
using Domain.Entities;

//using Domain.Entities.Rol;
//using Domain.Entities.Task;
//using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Persistence.DataBase
{
    public class DataBaseService:DbContext,IDataBaseService
    {
        public DataBaseService(DbContextOptions options):base(options)
        {
            
        }

        //public DbSet<UserEntity> User { get; set; }
        //public DbSet<TaskEntity> Task { get; set; }
        //public DbSet<RolEntity> Rol { get; set; }
        //public virtual DbSet<Permission> Permission { get; set; }

        public virtual DbSet<Rol> Rol { get; set; }

        public virtual DbSet<RolePermissions> RolePermissions { get; set; }

        public virtual DbSet<TaskUser> TaskUser { get; set; }

        public virtual DbSet<User> User { get; set; }

        public async Task<bool> SaveAsync()
        {
            using (var transaction = new TransactionScope())
            {
                var result =  await SaveChangesAsync() > 0;
                transaction.Complete();
                return result;
            }
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //EntityConfiguration(modelBuilder);
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();
                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.RolName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RolePermissions>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.HasOne(d => d.PermissionNavigation).WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.Permission)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolePermissions_Permission");
            });

            modelBuilder.Entity<TaskUser>(entity =>
            {
                entity.HasKey(e => e.TaskID).HasName("PK_Task");

                entity.Property(e => e.TaskID).ValueGeneratedNever();
                entity.Property(e => e.DateTask).HasColumnType("datetime");
                entity.Property(e => e.Detail)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserTaskNavigation).WithMany(p => p.TaskUser)
                    .HasForeignKey(d => d.UserTask)
                    .HasConstraintName("FK_TaskUser_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.FirtsName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.NumberDocument)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.RolUserNavigation).WithMany(p => p.User)
                    .HasForeignKey(d => d.RolUser)
                    .HasConstraintName("FK_User_Rol");
            });
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            //new UserConfiguration(modelBuilder.Entity<UserEntity>());
            //new TaskConfiguration(modelBuilder.Entity<TaskEntity>());
            //new RolConfiguration(modelBuilder.Entity<RolEntity>());
        }
    }
}
