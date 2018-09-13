using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class RecruiterMySqlContext : DbContext
{
    public RecruiterMySqlContext(DbContextOptions<RecruiterMySqlContext> options) : base(options)
    { }

    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Reviewer> Reviewers { get; set; }
}

public class RecruiterContextFactory : IDesignTimeDbContextFactory<RecruiterMySqlContext>
{
    public RecruiterMySqlContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RecruiterMySqlContext>();
        optionsBuilder.UseMySQL(@"Server=192.168.100.127;Database=recruiter;User Id=recruiter;Password=recruiter;");

        return new RecruiterMySqlContext(optionsBuilder.Options);
    }
}