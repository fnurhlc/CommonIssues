using Microsoft.EntityFrameworkCore; // DbContext, DbSet için
using CommonIssues.Models; // Issue modeli için

namespace CommonIssues.Models
{
    public class CommonIssuesContext : DbContext // EF Core context
    {
        public CommonIssuesContext(DbContextOptions<CommonIssuesContext> options)
            : base(options) // DbContext constructor
        {
        }

        public DbSet<Issue> Issues { get; set; } // Issues tablosu
    }
}
