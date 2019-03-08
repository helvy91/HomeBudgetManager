using HomeBudgetManager.Application.Services.Base;
using System.Threading.Tasks;

namespace HomeBudgetManager.Application.Interfaces.Services.Base
{
    public interface IBaseService<TEntityKey, TEntityDto, TCreateDto, TUpdateDto, TGetPagedDto>
        where TEntityDto : EntityDto<TEntityKey>
        where TGetPagedDto : GetPagedDto
    {
        Task CreateAsync(TCreateDto dto);
        Task DeleteAsync(TEntityKey key);
        Task<PagedResultDto<TEntityDto>> GetFilteredAsync(TGetPagedDto dto);
        Task<TEntityDto> GetAsync(TEntityKey key);
        Task UpdateAsync(TUpdateDto dto);
    }
}