using HomeBudgetManager.Application.Interfaces.Services.Base;
using HomeBudgetManager.Application.Services.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HomeBudgetManager.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController<TService, TEntityKey, TEntityDto, TCreateDto, TUpdateDto, TGetPagedDto> : Controller
        where TEntityDto : EntityDto<TEntityKey>
        where TUpdateDto : EntityDto<TEntityKey>
        where TGetPagedDto : GetPagedDto
        where TService : class, IBaseService<TEntityKey, TEntityDto, TCreateDto, TUpdateDto, TGetPagedDto>
    {
        protected readonly ILogger _logger;
        protected readonly TService _service;

        protected BaseController(TService service, ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("{key}")]
        public virtual async Task<ActionResult<TEntityDto>> Get(TEntityKey key)
        {
            try
            {
                var dto = await _service.GetAsync(key);
                return Json(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
            
        }

        [HttpPost]
        public virtual async Task<ActionResult<PagedResultDto<TEntityDto>>> GetFiltered([FromBody] TGetPagedDto dto)
        {
            try
            {
                var pagedResult = await _service.GetFilteredAsync(dto);
                return Json(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
            
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create([FromBody] TCreateDto dto)
        {
            try
            {
                await _service.CreateAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
            
        }

        [HttpPut]
        public virtual async Task<ActionResult> Update([FromBody] TUpdateDto dto)
        {
            try
            {
                await _service.UpdateAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
            
        }

        [HttpDelete("{key}")]
        public virtual async Task<ActionResult> Delete(TEntityKey key)
        {
            try
            {
                await _service.DeleteAsync(key);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
