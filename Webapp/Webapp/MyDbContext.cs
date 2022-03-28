using Microsoft.EntityFrameworkCore;

namespace Webapp;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        throw new NotImplementedException();
    }
}