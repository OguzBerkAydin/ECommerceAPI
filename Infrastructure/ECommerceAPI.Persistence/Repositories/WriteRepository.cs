﻿using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
	{
		private readonly ECommerceAPIDbContext _context;

		public WriteRepository(ECommerceAPIDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public async Task<bool> AddAsync(T entity)
		{
			EntityEntry<T> entityEntry = await Table.AddAsync(entity);
			return entityEntry.State == EntityState.Added;
		}

		public async Task<bool> AddRangeAsync(List<T> entities)
		{
			await Table.AddRangeAsync(entities);
			return true;
		}

		public bool Update(T entity)
		{
			EntityEntry entityEntry = Table.Update(entity);
			return entityEntry.State == EntityState.Modified;
		}
		

		public bool Delete(T entity)
		{
			EntityEntry<T> entityEntry = Table.Remove(entity);
			return entityEntry.State == EntityState.Deleted;
		}
		public bool DeleteRange(List<T> entities)
		{
			Table.RemoveRange(entities);
			return true;
		}

		public async Task<bool> DeleteAsync(string id)
		{
			T entity = await Table.FirstOrDefaultAsync(entity => entity.Id == Guid.Parse(id));
			return Delete(entity);
		}
		public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
	}
}
