using System;
using System.Collections.Generic;
using DbFirst.Models.Entities;
using DbFirst.Models.Secrets;
using Microsoft.EntityFrameworkCore;

namespace DbFirst.Models;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder
            .UseSqlite(SecretAppSettingReader
                .ReadSection<SecretValues, DataContext>("Secrets")!
                .ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
