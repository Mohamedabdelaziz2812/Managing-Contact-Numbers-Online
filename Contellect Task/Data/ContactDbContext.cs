using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Contellect_Task.Data;
public class ContactDbContext : DbContext, IContactsDbContext
{
    public ContactDbContext(DbContextOptions<ContactDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactNote> ContactNotes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactDbContext).Assembly);
    }
    public override int SaveChanges()
    {

        return base.SaveChanges();
    }
    public override ChangeTracker ChangeTracker => base.ChangeTracker;

}
