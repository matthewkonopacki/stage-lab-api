using Microsoft.EntityFrameworkCore;
using StageLabApi.Models;

namespace StageLabApi.Data;

using Action = StageLabApi.Models.Action;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Action> Action { get; set; }
    public DbSet<ActionRole> ActionRole { get; set; }
    public DbSet<Event> Event { get; set; }
    public DbSet<EventUser> EventUser { get; set; }
    public DbSet<Location> Location { get; set; }
    public DbSet<Project> Project { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Action>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder
            .Entity<Action>()
            .HasData(
                new Action
                {
                    Id = 1,
                    Description = "Allows users to create event records",
                    Name = "CreateEvent",
                },
                new Action
                {
                    Id = 2,
                    Description = "Allows users to delete their own event record",
                    Name = "DeleteOwnEvent",
                },
                new Action
                {
                    Id = 3,
                    Description = "Allows users to delete any event record",
                    Name = "DeleteAnyEvent",
                },
                new Action
                {
                    Id = 4,
                    Description = "Allows users to edit their own event record",
                    Name = "EditOwnEvent",
                },
                new Action
                {
                    Id = 5,
                    Description = "Allows users to edit any event record",
                    Name = "EditAnyEvent",
                },
                new Action
                {
                    Id = 6,
                    Description = "Allows users to view their own event record",
                    Name = "ViewOwnEvent",
                },
                new Action
                {
                    Id = 7,
                    Description = "Allows users to view any event records",
                    Name = "ViewAnyEvent",
                }
            );

        modelBuilder
            .Entity<Role>()
            .HasData(
                new Role
                {
                    Id = 1,
                    Description =
                        "Role owned by administrator users in the arts org (has all actions assigned to them)",
                    Name = "Admin",
                },
                new Role
                {
                    Id = 2,
                    Description =
                        "Role owned by artist users in the arts org (has restricted actions)",
                    Name = "Artist",
                }
            );

        modelBuilder
            .Entity<ActionRole>()
            .HasData(
                // Create Event Actions
                new ActionRole
                {
                    Id = 1,
                    ActionId = 1,
                    RoleId = 1,
                },
                new ActionRole
                {
                    Id = 2,
                    ActionId = 1,
                    RoleId = 2,
                },
                // Delete Own Event Action
                new ActionRole
                {
                    Id = 3,
                    ActionId = 2,
                    RoleId = 1,
                },
                new ActionRole
                {
                    Id = 4,
                    ActionId = 2,
                    RoleId = 2,
                },
                // Delete Any Event Action
                new ActionRole
                {
                    Id = 5,
                    ActionId = 3,
                    RoleId = 1,
                },
                // Edit Own Event Action
                new ActionRole
                {
                    Id = 6,
                    ActionId = 4,
                    RoleId = 1,
                },
                new ActionRole
                {
                    Id = 7,
                    ActionId = 4,
                    RoleId = 2,
                },
                // Edit Any Event Action
                new ActionRole
                {
                    Id = 8,
                    ActionId = 5,
                    RoleId = 1,
                },
                // View Own Event Action
                new ActionRole
                {
                    Id = 9,
                    ActionId = 6,
                    RoleId = 1,
                },
                new ActionRole
                {
                    Id = 10,
                    ActionId = 6,
                    RoleId = 2,
                },
                // View Any Event Action
                new ActionRole
                {
                    Id = 11,
                    ActionId = 7,
                    RoleId = 1,
                }
            );

        modelBuilder.Entity<Event>().Property(e => e.Description).HasColumnType("varchar(255)");

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Address1).HasMaxLength(100);
            entity.Property(e => e.Address2).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(2);
            entity.Property(e => e.Zip).HasMaxLength(10);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(255);

            entity
                .HasMany(r => r.Actions)
                .WithMany()
                .UsingEntity<ActionRole>(
                    j =>
                        j.HasOne<Action>(ar => ar.Action)
                            .WithMany()
                            .HasForeignKey(ar => ar.ActionId),
                    j => j.HasOne<Role>(ar => ar.Role).WithMany().HasForeignKey(ar => ar.RoleId)
                );
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
        });
    }
}
