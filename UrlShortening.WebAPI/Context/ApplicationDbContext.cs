using Microsoft.EntityFrameworkCore;
using UrlShortening.WebAPI.Models;

namespace UrlShortening.WebAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<HashedUrl> HashedUrls { get; set; }
    }
}
