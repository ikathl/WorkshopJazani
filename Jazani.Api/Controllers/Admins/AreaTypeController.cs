using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaTypeController : ControllerBase
    {
        private readonly IAreaTypeRepository _areaTypeRepository;

        public AreaTypeController(IAreaTypeRepository areaTypeRepository)
        {
            _areaTypeRepository = areaTypeRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<AreaType>>Get()
        {
            return await _areaTypeRepository.FindAllAsync();    
        }
        [HttpGet("{id}")]
        public async Task<AreaType>GetById(int id)
        {
            return await _areaTypeRepository.FindByIdAsync(id);
        }
    }
}
