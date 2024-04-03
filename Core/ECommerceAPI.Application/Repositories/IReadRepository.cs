using ECommerceAPI.Domain.Entities.Common;
using System.Linq.Expressions;

namespace ECommerceAPI.Application.Repositories
{
	public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
	{
		IQueryable<T> GetAll();
		IQueryable<T> GetWhere(Expression<Func<T, bool>> filter);
		Task<T> GetByIdAsync(string id);
		Task<T> GetSingleAsync(Expression<Func<T, bool>> filter);
	}
}
