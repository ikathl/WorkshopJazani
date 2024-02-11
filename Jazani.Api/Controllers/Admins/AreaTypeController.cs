using Jazani.Api.Exceptions;
using Jazani.Application.Admins.Dtos.AreaTypes;
using Jazani.Application.Admins.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaTypeController : ControllerBase
    {
        private readonly IAreaTypeService _areaTypeService;
        public AreaTypeController(IAreaTypeService areaTypeService)
        {
            _areaTypeService = areaTypeService;
        }
        [HttpGet]
        public async Task<IEnumerable<AreaTypeSmallDto>>Get()
        {
            return await _areaTypeService.FindAllAsync();    
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(AreaTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound,Ok<AreaTypeDto>>>Get(int id)
        {
            var response= await _areaTypeService.FindByIdAsync(id);
            return TypedResults.Ok(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AreaTypeDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]

        public async Task<Results<BadRequest,CreatedAtRoute<AreaTypeDto>>> Post([FromBody] AreaTypeSaveDto saveDto)
        {
            var response= await _areaTypeService.CreateAsync(saveDto);
            return TypedResults.CreatedAtRoute(response);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AreaTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
        public async Task<Results<NotFound,BadRequest,Ok<AreaTypeDto>>> Put(int id, [FromBody] AreaTypeSaveDto saveDto)
        {
            var response =await _areaTypeService.EditAsync(id, saveDto);
            return TypedResults.Ok(response);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AreaTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<AreaTypeDto>>> Delete(int id)
        {
            var response = await _areaTypeService.DisabledAsync(id);

            return TypedResults.Ok(response);
        }
    }
}
