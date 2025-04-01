using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Contellect_Task.Data;

public interface IContactsDbContext
{
    DbSet<Contact> Contacts { get; set; }
    DbSet<ContactNote> ContactNotes { get; set; }



    DatabaseFacade Database { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    ChangeTracker ChangeTracker { get; }
}
