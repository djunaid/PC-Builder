using Application.Common.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PCBuilder.Domain.Entities;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<PCComponent> PCComponent => Set<PCComponent>();

        //public DbSet<PCComponentTag> PCComponentTag => Set<PCComponentTag>();

        public DbSet<PriceComponent> PriceComponents => Set<PriceComponent>();

        public DbSet<Tag> Tag => Set<Tag>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            

            base.OnModelCreating(builder);
        }
    }
}
