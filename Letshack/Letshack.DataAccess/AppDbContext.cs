using Letshack.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Letshack.DataAccess;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
        
    }
    
    public DbSet<NeededRole> NeededRoles { get; set; }
    public DbSet<RelatedTopic> RelatedTopics { get; set; }
    public DbSet<Role> TeamRoles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamMember> TeamMembers { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<UserTag> UserTags { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.UseSerialColumns();

        // builder.Entity<IdentityUserClaim<Guid>>(b =>
        // {
        //     b.ToTable("UserClaims");
        // });
        //
        // builder.Entity<IdentityUserLogin<Guid>>(b =>
        // {
        //     b.ToTable("UserLogins");
        // });
        //
        // builder.Entity<IdentityUserToken<Guid>>(b =>
        // {
        //     b.ToTable("UserTokens");
        // });
        //
        // builder.Entity<IdentityRole<Guid>>(b =>
        // {
        //     b.ToTable("UserRoles");
        // });
        //
        // builder.Entity<IdentityRoleClaim<Guid>>(b =>
        // {
        //     b.ToTable("RoleClaims");
        // });
        //
        // builder.Entity<IdentityUserRole<Guid>>(b =>
        // {
        //     b.ToTable("UserRoles");
        // });
    }
}