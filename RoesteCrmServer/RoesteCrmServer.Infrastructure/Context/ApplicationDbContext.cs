using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoesteCrmServer.Domain.Abstract;
using RoesteCrmServer.Domain.Entities;

namespace RoesteCrmServer.Infrastructure.Context;

internal sealed class ApplicationDbContext : IdentityDbContext<
    AppUser,
    IdentityRole<Guid>,
    Guid>, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);

        builder.Ignore<IdentityUserLogin<Guid>>();
        builder.Ignore<IdentityUserToken<Guid>>();

        builder.Entity<IdentityUserRole<Guid>>()
             .HasKey(ur => new { ur.UserId, ur.RoleId });
    }
}
