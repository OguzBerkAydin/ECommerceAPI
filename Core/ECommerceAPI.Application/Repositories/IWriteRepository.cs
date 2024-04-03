using ECommerceAPI.Domain.Entities.Common;

namespace ECommerceAPI.Application.Repositories
{
	public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
	{
		Task<bool> AddAsync(T entity);
		Task<bool> AddRangeAsync(List<T> entity);
		bool Update(T entity);
		bool Delete(T entity);
		bool DeleteRange(List<T> entities);
		Task<bool> DeleteAsync(string id);
		Task<int> SaveAsync();

	}
}
