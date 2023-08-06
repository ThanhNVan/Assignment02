using Microsoft.EntityFrameworkCore;

namespace Assignment02.EntityProviders;

public class AppDbContext : DbContext
{

    #region [ CTor ]
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
    }
    #endregion

    #region [ Properties -  ]
    public virtual DbSet<Author> Authors { get; set; }        

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<Publisher> Publisher { get; set; }
    
    public virtual DbSet<Role> Roles{ get; set; }

    public virtual DbSet<User> Users { get; set; }
    #endregion
}
