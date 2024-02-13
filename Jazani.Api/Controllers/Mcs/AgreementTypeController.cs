using Jazani.Api.Exceptions;
using Jazani.Application.Mcs.Dtos.AgreementTypes;
using Jazani.Application.Mcs.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jazani.Api.Controllers.Mcs
{

    [ApiController]
    [Route("api/[controller]")]
    public class AgreementTypeController : ControllerBase
    {

        private readonly IAgreementTypeService _agreementTypeervice;

        public AgreementTypeController(IAgreementTypeService agreementTypeervice)
        {
            _agreementTypeervice = agreementTypeervice;
        }

        [HttpGet]
        public async Task<IEnumerable<AgreementTypeSmallDto>> Get()
        {
            return await _agreementTypeervice.FindAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgreementTypeDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<AgreementTypeDto>>> Get(int id)
        {
            var response = await _agreementTypeervice.FindByIdAsync(id);

            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AgreementTypeSimpleDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
        public async Task<Results<BadRequest, CreatedAtRoute<AgreementTypeSimpleDto>>> Post([FromBody] AgreementTypeSaveDto saveDto)
        {
            var response = await _agreementTypeervice.CreateAsync(saveDto);

            return TypedResults.CreatedAtRoute(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgreementTypeSimpleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorValidationResponse))]
        public async Task<Results<NotFound, BadRequest, Ok<AgreementTypeSimpleDto>>> Put(int id, [FromBody] AgreementTypeSaveDto saveDto)
        {
            var response = await _agreementTypeervice.EditAsync(id, saveDto);

            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgreementTypeSimpleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorModel))]
        public async Task<Results<NotFound, Ok<AgreementTypeSimpleDto>>> Delete(int id)
        {
            var response = await _agreementTypeervice.DisabledAsync(id);

            return TypedResults.Ok(response);
        }

    }
}
