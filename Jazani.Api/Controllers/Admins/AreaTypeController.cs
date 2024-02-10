﻿using Jazani.Application.Admins.Dtos.AreaTypes;
using Jazani.Application.Admins.Services;
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
        public async Task<AreaTypeDto>GetById(int id)
        {
            return await _areaTypeService.FindByIdAsync(id);
        }
        [HttpPost]
        public async Task<AreaTypeDto> Post([FromBody] AreaTypeSaveDto saveDto)
        {
            return await _areaTypeService.CreateAsync(saveDto);
        }
        [HttpPut("{id}")]
        public async Task<AreaTypeDto> Put(int id, [FromBody] AreaTypeSaveDto saveDto)
        {
            return await _areaTypeService.EditAsync(id, saveDto);
        }
        [HttpDelete("{id}")]
        public async Task<AreaTypeDto> Delete(int id)
        {
            return await _areaTypeService.DisabledAsync(id);
        }
    }
}
