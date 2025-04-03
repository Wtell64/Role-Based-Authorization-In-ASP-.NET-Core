﻿using Authentication.Domain.Constants;
using Authentication.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<User>()
            .Property(u => u.FirstName).HasMaxLength(256);
        
        builder.Entity<User>()
            .Property(u => u.LastName).HasMaxLength(256);

        builder.Entity<IdentityRole<Guid>>()
            .HasData(new List<IdentityRole<Guid>>
            {
                new IdentityRole<Guid>()
                {
                    Id = IdentityRoleConstants.AdminRoleGuid,
                    Name = IdentityRoleConstants.Admin,
                    NormalizedName = IdentityRoleConstants.Admin.ToUpper()
                },
                new IdentityRole<Guid>()
                {
                    Id = IdentityRoleConstants.RegularEmployeeRoleGuid,
                    Name = IdentityRoleConstants.RegularEmployee,
                    NormalizedName = IdentityRoleConstants.RegularEmployee.ToUpper()
                },
                new IdentityRole<Guid>()
                {
                    Id = IdentityRoleConstants.HrManagerRoleGuid,
                    Name = IdentityRoleConstants.HrManager,
                    NormalizedName = IdentityRoleConstants.HrManager.ToUpper()
                }
            });
    }
}