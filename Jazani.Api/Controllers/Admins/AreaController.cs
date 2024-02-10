using Jazani.Application.Admins.Dtos.Areas;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;
        public AreaController(IAreaService AreaService)
        {
            _areaService = AreaService;
        }
        [HttpGet]
        public async Task<IEnumerable<AreaSmallDto>> Get()
        {
            return await _areaService.FindAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<AreaDto> GetById(int id)
        {
            return await _areaService.FindByIdAsync(id);
        }
        [HttpPost]
        public async Task<AreaDto> Post([FromBody] AreaSaveDto saveDto)
        {
            return await _areaService.CreateAsync(saveDto);
        }
        [HttpPut("{id}")]
        public async Task<AreaDto> Put(int id, [FromBody] AreaSaveDto saveDto)
        {
            return await _areaService.EditAsync(id, saveDto);
        }
        [HttpDelete("{id}")]
        public async Task<AreaDto> Delete(int id)
        {
            return await _areaService.DisabledAsync(id);
        }
    }
}
