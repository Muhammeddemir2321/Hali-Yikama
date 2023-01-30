using Hali.Core.DTOs;
using Hali.Core.Models;
using Hali.Core.Repositories;
using Hali.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hali.API.Filters
{
    public class NotFoundFilter<TEntity> : IAsyncActionFilter where TEntity : BaseEntitiy
    {
        private readonly IGenericRepository<TEntity> _repository;

        public NotFoundFilter(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = context.ActionArguments.Values.FirstOrDefault();

            if (id == null)
            {
                await next.Invoke();
                return;
            }

            var anyEntity = await _repository.AnyAsync(i => i.Id == (int)id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(ResponseDto<NoContent>
                                                        .Fail(($"{typeof(TEntity).Name} {id} not found"), 404, true));
        }
    }
}
