﻿using CQRS_Sample.Common.EntityHelpers;
using CQRS_Sample.Common.MediatRHelpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sima.Framework.Core.Repository;

namespace SIMA.Framework.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private readonly IMediator _domainEventDispacher;

    public UnitOfWork(DbContext dbContext, IMediator domainEventDispacher)
    {
        _context = dbContext;
        _domainEventDispacher = domainEventDispacher;
    }

    public async Task<int> SaveChangesAsync()
    {
        var entitiesForSave = GetEntityForSave();
        var events = GetEvents(entitiesForSave);
        await RaiseEvent(events);
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    private IList<INotification> GetEvents(IList<EntityEntry> entityForSave)
    {
        List<INotification> events = new List<INotification>();
        foreach (EntityEntry entityEntry in (IEnumerable<EntityEntry>)entityForSave)
        {
            if (entityEntry.Entity is IEventfulEntity entity && entity.GetEvents() != null)
            {
                events.AddRange(entity.GetEvents());
                entity.ClearEvents();
            }
        }
        return events;
    }
    private async Task RaiseEvent(IList<INotification> events)
    {
        if (events != null)
        {
            foreach (var item in events)
            {
                await _domainEventDispacher.Publish(item);
            }
        }
    }


    private IList<EntityEntry> GetEntityForSave() =>
        _context.ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Modified ||
                    x.State == EntityState.Added ||
                    x.State == EntityState.Deleted)
            .ToList();
}
