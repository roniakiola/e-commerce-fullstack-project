using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Database
{
  public class TimeStampInterceptor : SaveChangesInterceptor
  {
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
      var addedEntries = eventData.Context!.ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
      var modifiedEntries = eventData.Context!.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);

      foreach (var trackEntry in addedEntries)
      {
        if (trackEntry.Entity is Timestamp entity)
        {
          entity.CreatedAt = DateTime.Now;
        }
      }

      foreach (var trackEntry in modifiedEntries)
      {
        if (trackEntry.Entity is Timestamp entity)
        {
          entity.ModifiedAt = DateTime.Now;
        }
      }

      return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
  }
}