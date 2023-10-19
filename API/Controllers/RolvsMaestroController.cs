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

public class RolvsMaestroController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RolvsMaestroController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RolvsMaestroDto>>> Get()
    {
        var rolvsMaestro = await _unitOfWork.RolvsMaestros.GetAllAsync();
        return _mapper.Map<List<RolvsMaestroDto>>(rolvsMaestro);
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolvsMaestroDto>> Get(int Id)
    {
        var rolvsMaestro = await _unitOfWork.RolvsMaestros.GetByIdAsync(Id);
        if (rolvsMaestro == null)
        {
            return NotFound();
        }
        return _mapper.Map<RolvsMaestroDto>(rolvsMaestro);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolvsMaestroDto>> Post(RolvsMaestroDto rolvsMaestroDto)
    {
        var rolvsMaestro = _mapper.Map<RolvsMaestro>(rolvsMaestroDto);
        if (rolvsMaestroDto.FechaCreacion == DateOnly.MinValue)
        {
            rolvsMaestroDto.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            rolvsMaestro.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
        }
        if (rolvsMaestroDto.FechaModificacion == DateOnly.MinValue)
        {
            rolvsMaestroDto.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
            rolvsMaestro.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
        }
        _unitOfWork.RolvsMaestros.Add(rolvsMaestro);
        await _unitOfWork.SaveAsync();
        if (rolvsMaestroDto == null)
        {
            return BadRequest();
        }
        rolvsMaestroDto.Id = rolvsMaestro.Id;
        return CreatedAtAction(nameof(Post), new { id = rolvsMaestroDto.Id }, rolvsMaestroDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RolvsMaestroDto>> Put(int id, [FromBody] RolvsMaestroDto rolvsMaestroDto)
    {
        if (rolvsMaestroDto.Id == 0)
        {
            rolvsMaestroDto.Id = id;
        }
        if (rolvsMaestroDto.Id != id)
        {
            return NotFound();
        }
        var rolvsMaestro = _mapper.Map<RolvsMaestro>(rolvsMaestroDto);
        if (rolvsMaestroDto.FechaCreacion == DateOnly.MinValue)
        {
            rolvsMaestroDto.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            rolvsMaestro.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
        }
        if (rolvsMaestroDto.FechaModificacion == DateOnly.MinValue)
        {
            rolvsMaestroDto.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
            rolvsMaestro.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
        }
        rolvsMaestroDto.Id = rolvsMaestro.Id;
        _unitOfWork.RolvsMaestros.Update(rolvsMaestro);
        await _unitOfWork.SaveAsync();
        return rolvsMaestroDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var rolvsMaestro = await _unitOfWork.RolvsMaestros.GetByIdAsync(id);
        if (rolvsMaestro == null)
        {
            return NotFound();
        }
        _unitOfWork.RolvsMaestros.Remove(rolvsMaestro);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
