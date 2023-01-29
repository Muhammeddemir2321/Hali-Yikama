using Hali.Core.DTOs;
using Hali.Shared.DTOs;
using System.Linq.Expressions;

namespace Hali.Core.Services
{
    public interface IService<TEntity,TDto> where TEntity : class where TDto: class
    {
        Task<ResponseDto<IEnumerable<TDto>>> GetAllAsync();
        Task<ResponseDto<TDto>> GetByIdAsync(int id);
        Task<ResponseDto<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> expression);
        Task<ResponseDto<bool>> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<ResponseDto<IEnumerable<TDto>>> AddRangeAsync(IEnumerable<TDto> dtos);
        Task<ResponseDto<TDto>> AddAsync(TDto dto);
        Task<ResponseDto<NoContent>> UpdateAsync(TDto dto);
        Task<ResponseDto<NoContent>> RemoveAsync(int id);
        Task<ResponseDto<NoContent>> RemoveRangeAsync(IEnumerable<int> ids);
    }
}
