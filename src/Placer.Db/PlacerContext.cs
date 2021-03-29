using Microsoft.EntityFrameworkCore;
using System;

namespace Placer.Db
{
  public class PlacerContext : DbContext
  {
    public DbSet<Core.Idea> Ideas { get; set; }
    public DbSet<Core.Thing> Things { get; set; }
    public DbSet<Core.ThingDefinition> ThingDefinitions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      string folder = Environment.GetEnvironmentVariable("dbsFolder") ?? "D:/dbs";
      optionsBuilder.UseSqlite($"Data Source={folder}/Placer.db3");
      //optionsBuilder.UseMySQL("Server=localhost;Database=datar;User=datarApp;Password=v5p2bd3tm5Z3XamZB7vhxabgutMBqAaaasd;");
    }
    protected override void OnModelCreating(ModelBuilder mb)
    {
      base.OnModelCreating(mb);
      // HasKey
      // HasAlternateKey // isUnique
      mb.Entity<Core.Thing>().HasAlternateKey(item => new { item.IdeaID, item.DefinitionID }); // TODO: Gal nereikalingas?
      // Relations
      // Property
      mb.Entity<Core.Thing>().HasMany(item => item.RelationsFrom).WithOne(item => item.From);
      mb.Entity<Core.Thing>().HasMany(item => item.RelationsTo).WithOne(item => item.To);
      // Owns
      mb.Entity<Core.FieldOfThing>().OwnsOne(
        item => item.Value,
        sa =>
        {
          sa.Ignore(item => item.String);
          sa.Ignore(item => item.Integer);
          sa.Ignore(item => item.DateTime);
        }
      );
      mb.Entity<Core.FieldOfRelation>().OwnsOne(
        item => item.Value,
        sa =>
        {
          sa.Ignore(item => item.String);
          sa.Ignore(item => item.Integer);
          sa.Ignore(item => item.DateTime);
        }
      );
      // ToTable
    }
  }
}
