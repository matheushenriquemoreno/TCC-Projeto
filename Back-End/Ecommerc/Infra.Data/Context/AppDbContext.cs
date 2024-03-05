using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context;

public abstract class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
    : base(options)
    {
    }
}
