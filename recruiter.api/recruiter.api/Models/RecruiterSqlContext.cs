using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class RecruiterSqlContext : DbContext
{
    public RecruiterSqlContext(DbContextOptions<RecruiterSqlContext> options) : base(options)
    { }

    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Reviewer> Reviewers { get; set; }
}

public class RecruiterContextFactory : IDesignTimeDbContextFactory<RecruiterSqlContext>
{
    public RecruiterSqlContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RecruiterSqlContext>();
        optionsBuilder.UseSqlServer(@"Server=192.168.50.116;Database=recruiter;User Id=recruiter;Password=recruiter;");

        return new RecruiterSqlContext(optionsBuilder.Options);
    }
}