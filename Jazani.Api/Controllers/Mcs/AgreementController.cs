using Jazani.Api.Exceptions;
using Jazani.Application.Mcs.Dtos.Agreements;
using Jazani.Application.Mcs.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mcs
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgreementController : ControllerBase
    {

        private readonly IAgreementService _agreementService;

        public AgreementController(IAgreementService Agreementervice)
        {
            _agreementService = Agreementervice;
        }

        [HttpGet]
        public async Task<IEnumerable<AgreementSmallDto>> Get()
        {
            return await _agreementService.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgreementDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<AgreementDto>>> Get(int id)
        {
            var response = await _agreementService.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AgreementSimpleDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<AgreementSimpleDto>>> Post([FromBody] AgreementSaveDto saveDto)
        {
            var response = await _agreementService.CreateAsync(saveDto);

            return TypedResults.CreatedAtRoute(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgreementSimpleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
        public async Task<Results<NotFound, BadRequest, Ok<AgreementSimpleDto>>> Put(int id, [FromBody] AgreementSaveDto saveDto)
        {
            var response = await _agreementService.EditAsync(id, saveDto);

            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgreementSimpleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<AgreementSimpleDto>>> Delete(int id)
        {
            var response = await _agreementService.DisabledAsync(id);

            return TypedResults.Ok(response);
        }

    }
}