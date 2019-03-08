using HomeBudgetManager.Application.Interfaces.Repositories;
using HomeBudgetManager.Application.Interfaces.Services.Base;
using HomeBudgetManager.Common.Extensions;
using HomeBudgetManager.Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetManager.Application.Services.Base
{
    public abstract class BaseService<TEntity, TEntityKey, TRepository, TEntityDto, TCreateDto, TUpdateDto, TGetPagedDto> : IBaseService<TEntityKey, TEntityDto, TCreateDto, TUpdateDto, TGetPagedDto>
        where TRepository : class, IRepository<TEntity, TEntityKey>
        where TEntity : Entity<TEntityKey>
        where TEntityDto : EntityDto<TEntityKey>
        where TUpdateDto : EntityDto<TEntityKey>
        where TGetPagedDto : GetPagedDto
    {
        protected readonly TRepository _repository;

        protected BaseService(TRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public virtual Task CreateAsync(TCreateDto dto)
        {
            var mapped = dto.Adapt<TEntity>();
            return _repository.AddAsync(mapped);
        }

        public virtual async Task<TEntityDto> GetAsync(TEntityKey key)
        {
            var entity = await _repository.GetAsync(key);
            return entity.Adapt<TEntityDto>();
        }

        public virtual async Task<PagedResultDto<TEntityDto>> GetFilteredAsync(TGetPagedDto dto)
        {
            var query = CreateFilteredQuery(dto); 
            var totalCount = query.Count();

            query = ApplyPaging(query, dto);
            query = ApplySorting(query, dto);

            var items = await query.ToListAsync();
            return new PagedResultDto<TEntityDto>()
            {
                TotalCount = totalCount,
                Items = items.Adapt<List<TEntityDto>>()
            };
        }

        public virtual Task UpdateAsync(TUpdateDto dto)
        {
            var mapped = dto.Adapt<TEntity>();
            return _repository.UpdateAsync(mapped);
        }

        public virtual Task DeleteAsync(TEntityKey key)
        {
            return _repository.DeleteAsync(key);
        }

        protected virtual IQueryable<TEntity> ApplyPaging(IQueryable<TEntity> query, TGetPagedDto dto)
        {
            return query
                .Skip(dto.Skip)
                .Take(dto.Take);
        }

        protected virtual IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, TGetPagedDto dto)
        {
            if (dto is GetSortedDto sortedDto)
            {
                return query.OrderBy(sortedDto.Sorting);
            }
            else
            {
                return query.OrderByDescending(x => x.Id);
            }
        }

        protected virtual IQueryable<TEntity> CreateFilteredQuery(TGetPagedDto dto)
        {
            return _repository.Query(x => x);
        }
    }
}
