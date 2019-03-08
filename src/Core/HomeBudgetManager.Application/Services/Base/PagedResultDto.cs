using System.Collections.Generic;

namespace HomeBudgetManager.Application.Services.Base
{
    public class PagedResultDto<TEntityDto>
    {
        public int TotalCount { get; set; }
        public List<TEntityDto> Items { get; set; }

        public PagedResultDto()
        {
            Items = new List<TEntityDto>();
        }
    }
}
