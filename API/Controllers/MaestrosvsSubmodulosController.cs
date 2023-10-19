using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MaestrosvsSubmodulosController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MaestrosvsSubmodulosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MaestrosvsSubmodulosDto>>> Get()
    {
        var maestrosvsSubmodulos = await _unitOfWork.MaestrosVsSubmodulos.GetAllAsync();
        return _mapper.Map<List<MaestrosvsSubmodulosDto>>(maestrosvsSubmodulos);
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MaestrosvsSubmodulosDto>> Get(int Id)
    {
        var maestrosvsSubmodulos = await _unitOfWork.MaestrosVsSubmodulos.GetByIdAsync(Id);
        if (maestrosvsSubmodulos == null)
        {
            return NotFound();
        }
        return _mapper.Map<MaestrosvsSubmodulosDto>(maestrosvsSubmodulos);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MaestrosvsSubmodulosDto>> Post(MaestrosvsSubmodulosDto maestrosvsSubmodulosDto)
    {
        var maestrosvsSubmodulos = _mapper.Map<MaestrosvsSubmodulos>(maestrosvsSubmodulosDto);
        if (maestrosvsSubmodulosDto.FechaCreacion == DateOnly.MinValue)
        {
            maestrosvsSubmodulosDto.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            maestrosvsSubmodulos.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
        }
        if (maestrosvsSubmodulosDto.FechaModificacion == DateOnly.MinValue)
        {
            maestrosvsSubmodulosDto.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
            maestrosvsSubmodulos.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
        }
        _unitOfWork.MaestrosVsSubmodulos.Add(maestrosvsSubmodulos);
        await _unitOfWork.SaveAsync();
        if (maestrosvsSubmodulosDto == null)
        {
            return BadRequest();
        }
        maestrosvsSubmodulosDto.Id = maestrosvsSubmodulos.Id;
        return CreatedAtAction(nameof(Post), new { id = maestrosvsSubmodulosDto.Id }, maestrosvsSubmodulosDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MaestrosvsSubmodulosDto>> Put(int id, [FromBody] MaestrosvsSubmodulosDto maestrosvsSubmodulosDto)
    {
        if (maestrosvsSubmodulosDto.Id == 0)
        {
            maestrosvsSubmodulosDto.Id = id;
        }
        if (maestrosvsSubmodulosDto.Id != id)
        {
            return NotFound();
        }
        var maestrosvsSubmodulos = _mapper.Map<MaestrosvsSubmodulos>(maestrosvsSubmodulosDto);
        if (maestrosvsSubmodulosDto.FechaCreacion == DateOnly.MinValue)
        {
            maestrosvsSubmodulosDto.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            maestrosvsSubmodulos.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
        }
        if (maestrosvsSubmodulosDto.FechaModificacion == DateOnly.MinValue)
        {
            maestrosvsSubmodulosDto.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
            maestrosvsSubmodulos.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
        }
        maestrosvsSubmodulosDto.Id = maestrosvsSubmodulos.Id;
        _unitOfWork.MaestrosVsSubmodulos.Update(maestrosvsSubmodulos);
        await _unitOfWork.SaveAsync();
        return maestrosvsSubmodulosDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var maestrosvsSubmodulos = await _unitOfWork.MaestrosVsSubmodulos.GetByIdAsync(id);
        if (maestrosvsSubmodulos == null)
        {
            return NotFound();
        }
        _unitOfWork.MaestrosVsSubmodulos.Remove(maestrosvsSubmodulos);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
