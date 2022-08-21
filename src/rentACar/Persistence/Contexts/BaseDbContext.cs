﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<Brand> Brands { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(a =>
        {
            a.ToTable("Brands").HasKey(k => k.Id);
            a.Property(p => p.Id).HasColumnName("Id");
            a.Property(p => p.Name).HasColumnName("Name");
        });

        Brand[] brandEntitySeeds = { new(1, "BMW"), new(2, "Mercedes") };
        modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);
    }
}
