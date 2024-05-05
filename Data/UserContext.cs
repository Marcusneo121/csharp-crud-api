namespace csharp_crud_api.Data;

using Models;
using Microsoft.EntityFrameworkCore;

// public class UserContext : DbContext
// {
//     public UserContext(DbContextOptions<UserContext> options) : base(options)
//     {
//     }
//     public DbSet<User> Users { get; set; }
// }

public class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}
