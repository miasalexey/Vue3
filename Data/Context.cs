using System.Configuration;
using Data.DBEntities;
using Data.Utils;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) :base(options) {}
    /*public Context()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }*/
    
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseSqlServer();
    }*/

    public DbSet<CriminalCase>? CriminalCases { get; set; }
    public DbSet<CriminalDecision>? CriminalDecisions { get; set; }
    public DbSet<PersonInCriminalCase>? PersonInCriminalCases { get; set; }
    public DbSet<Person>? Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CriminalCase>()
            .HasOne(cc => cc.CriminalDecision)
            .WithOne(cc => cc.CriminalCase);

        modelBuilder.Entity<PersonInCriminalCase>()
            .HasOne(pic => pic.CriminalCase)
            .WithMany(cc => cc.PersonInCriminalCases)
            .HasForeignKey(pic => pic.CriminalCaseId);

        modelBuilder.Entity<PersonInCriminalCase>()
            .HasOne(pic => pic.Person)
            .WithMany(p => p.PersonInCriminalCases)
            .HasForeignKey(pic => pic.PersonId);
    }
}