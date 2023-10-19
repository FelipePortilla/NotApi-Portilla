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

public class GenericovsSubmodulosController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenericovsSubmodulosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GenericovsSubmodulosDto>>> Get()
    {
        var genericovsSubmodulos = await _unitOfWork.GenericovsSubmodulos.GetAllAsync();
        return _mapper.Map<List<GenericovsSubmodulosDto>>(genericovsSubmodulos);
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenericovsSubmodulosDto>> Get(int Id)
    {
        var genericovsSubmodulos = await _unitOfWork.GenericovsSubmodulos.GetByIdAsync(Id);
        if (genericovsSubmodulos == null)
        {
            return NotFound();
        }
        return _mapper.Map<GenericovsSubmodulosDto>(genericovsSubmodulos);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenericovsSubmodulosDto>> Post(GenericovsSubmodulosDto genericovsSubmodulosDto)
    {
        var genericovsSubmodulos = _mapper.Map<GenericovsSubmodulos>(genericovsSubmodulosDto);
        if (genericovsSubmodulosDto.FechaCreacion == DateOnly.MinValue)
        {
            genericovsSubmodulosDto.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            genericovsSubmodulos.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
        }
        if (genericovsSubmodulosDto.FechaModificacion == DateOnly.MinValue)
        {
            genericovsSubmodulosDto.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
            genericovsSubmodulos.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
        }
        _unitOfWork.GenericovsSubmodulos.Add(genericovsSubmodulos);
        await _unitOfWork.SaveAsync();
        if (genericovsSubmodulosDto == null)
        {
            return BadRequest();
        }
        genericovsSubmodulosDto.Id = genericovsSubmodulos.Id;
        return CreatedAtAction(nameof(Post), new { id = genericovsSubmodulosDto.Id }, genericovsSubmodulosDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GenericovsSubmodulosDto>> Put(int id, [FromBody] GenericovsSubmodulosDto genericovsSubmodulosDto)
    {
        if (genericovsSubmodulosDto.Id == 0)
        {
            genericovsSubmodulosDto.Id = id;
        }
        if (genericovsSubmodulosDto.Id != id)
        {
            return NotFound();
        }
        var genericovsSubmodulos = _mapper.Map<GenericovsSubmodulos>(genericovsSubmodulosDto);
        if (genericovsSubmodulosDto.FechaCreacion == DateOnly.MinValue)
        {
            genericovsSubmodulosDto.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            genericovsSubmodulos.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
        }
        if (genericovsSubmodulosDto.FechaModificacion == DateOnly.MinValue)
        {
            genericovsSubmodulosDto.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
            genericovsSubmodulos.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
        }
        genericovsSubmodulosDto.Id = genericovsSubmodulos.Id;
        _unitOfWork.GenericovsSubmodulos.Update(genericovsSubmodulos);
        await _unitOfWork.SaveAsync();
        return genericovsSubmodulosDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var genericovsSubmodulos = await _unitOfWork.GenericovsSubmodulos.GetByIdAsync(id);
        if (genericovsSubmodulos == null)
        {
            return NotFound();
        }
        _unitOfWork.GenericovsSubmodulos.Remove(genericovsSubmodulos);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
