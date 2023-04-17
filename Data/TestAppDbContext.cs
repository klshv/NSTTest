using Microsoft.EntityFrameworkCore;
using Test_App.Data.Entities;

namespace Test_App.Data;

public class TestAppDbContext : DbContext
{
    public TestAppDbContext()
    {
        DbPath = BuildDbPath();
    }

    private TestAppDbContext(DbContextOptions<TestAppDbContext> options) : base(options)
    {
        DbPath = BuildDbPath();
    }

    public DbSet<PersonEntity> Persons { get; set; }

    public string DbPath { get; }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }

    private string BuildDbPath()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        return Path.Join(path, "test_app.db");
    }
}