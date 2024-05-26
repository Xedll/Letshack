using Letshack.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Letshack.DataAccess;

public class AppDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
    }
    
    public DbSet<NeededRole> NeededTeamRole { get; set; }
    public DbSet<RelatedTopic> RelatedTopic { get; set; }
    public DbSet<Role> TeamRole { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<Team> Team { get; set; }
    public DbSet<TeamMember> TeamMember { get; set; }
    public DbSet<Technology> Technology { get; set; }
    public DbSet<UserTechnology> UserTechnology { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.UseSerialColumns();
    }
}