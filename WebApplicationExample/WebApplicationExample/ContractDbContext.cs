using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationExample.Entities;

namespace WebApplicationExample
{
    public class ContractDbContext : DbContext
    {
        public ContractDbContext(DbContextOptions<ContractDbContext> options) : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<TypeTemplate> TypeTemplates { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Organization
            builder.Entity<Organization>()
                .ToTable("organization");

            builder.Entity<Organization>()
                .HasKey(k => k.OrganizationId);

            builder.Entity<Organization>()
                .Property(k => k.OrganizationId)
                .HasColumnName("organization_id")
                .IsRequired();

            builder.Entity<Organization>()
                .Property(k => k.Name)
                .HasColumnName("name");
            #endregion

            #region TypeTemplate
            builder.Entity<TypeTemplate>()
                .ToTable("type_template");

            builder.Entity<TypeTemplate>()
                .HasKey(k => new { k.TypeId, k.OrganizationId } );

            builder.Entity<TypeTemplate>()
                .Property(k => k.TypeId)
                .HasColumnName("type_id")
                .IsRequired();

            builder.Entity<TypeTemplate>()
                .Property(k => k.OrganizationId)
                .HasColumnName("organization_id")
                .IsRequired();

            builder.Entity<TypeTemplate>()
                .Property(k => k.Name)
                .HasColumnName("name");

            builder.Entity<TypeTemplate>()
                .HasMany(k => k.Contracts)
                .WithOne(g => g.TypeTemplate);
            #endregion

            #region Contracts
            builder.Entity<Contract>()
                .ToTable("contract");

            builder.Entity<Contract>()
                .HasKey(k => k.CorrelationId);

            builder.Entity<Contract>()
                .Property(k => k.NameContract)
                .HasColumnName("name_contract")
                .IsRequired();

            builder.Entity<Contract>()
                .Property(k => k.OrganizationId)
                .HasColumnName("organization_id")
                .IsRequired();

            builder.Entity<Contract>()
                .Property(k => k.TypeId)
                .HasColumnName("type_id")
                .IsRequired();

            builder.Entity<Contract>()
               .HasOne(k => k.TypeTemplate)
               .WithMany(k => k.Contracts)
               .HasForeignKey(k => new { k.TypeId, k.OrganizationId });
            #endregion
        }
    }
}
