using System.Linq.Expressions;
using ECommerce.Application.Dtos;
using ECommerce.Application.Response;
using ECommerce.Domain.Entities.Base;

namespace ECommerce.Application.Services.Base;


    public interface IApplicationCrudService<T, TDto> where T : BaseEntity where TDto : BaseDto{
        Task<ServiceResponse<List<TDto>>> GetListAsync(Expression<Func<T?, bool>>? predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
            bool disableTracking = true);
        Task<ServiceResponse<TDto>> GetFirstOrDefaultAsync(Expression<Func<T?, bool>>? predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
            bool disableTracking = true);
        Task<ServiceResponse<List<TDto>>> GetPagedListAsync(int page, int size,Expression<Func<T, bool>>? predicate = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IQueryable<T>>? includeProperties = null,
            bool disableTracking = true);
        Task<ServiceResponse<TDto>> CreateAsync(TDto dto);
        Task<ServiceResponse<TDto>> UpdateAsync(TDto dto);
        Task<ServiceResponse<NoContent>> DeleteAsync(Guid id);
    }
