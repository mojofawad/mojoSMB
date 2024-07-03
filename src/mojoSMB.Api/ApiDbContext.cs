using Microsoft.EntityFrameworkCore;

namespace mojoSMB.Api;

public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
{
    public DbSet<Todo> Todos => Set<Todo>();

}