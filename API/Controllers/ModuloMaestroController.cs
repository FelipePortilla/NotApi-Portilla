using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ModuloMaestroController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ModuloMaestroController(IUnitOfWork unitOfWork,IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ModulosMaestroDto>>> Get()
    {
        var modulomaestro = await _unitOfWork.ModulosMaestros.GetAllAsync();
        return _mapper.Map<List<ModulosMaestroDto>>(modulomaestro);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModulosMaestroDto>> Get(int id)
    {
        var modulosmaestro = await _unitOfWork.ModulosMaestros.GetByIdAsync(id);
        if(modulosmaestro == null)
        {
            return NotFound();
        }
        return _mapper.Map<ModulosMaestroDto>(modulosmaestro);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ModulosMaestroDto>> Post([FromBody] ModulosMaestroDto moduloDto)
    {
        var modulo = _mapper.Map<ModulosMaestro>(moduloDto);

        if(modulo == null)
            return BadRequest();
        if (moduloDto.FechaCreacion == DateOnly.MinValue)
        {
            moduloDto.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            modulo.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
        }
        if (modulo.FechaModificacion == DateOnly.MinValue)
        {
            moduloDto.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
            modulo.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
        }
        _unitOfWork.ModulosMaestros.Add(modulo);
        await _unitOfWork.SaveAsync();
        moduloDto.Id = modulo.Id;
        return CreatedAtAction(nameof(Post),new {id = modulo.Id},moduloDto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ModulosMaestroDto>> Put(int id, [FromBody] ModulosMaestroDto moduloDto)
    {
        if(moduloDto.Id == 0)
        {
            moduloDto.Id = id;
        }
        if(moduloDto.Id != id)
        {
            return NotFound();
        }
        var modulo = _mapper.Map<ModulosMaestro>(moduloDto);
        if(modulo==null)
            return BadRequest();
        if(modulo.FechaCreacion == DateOnly.MinValue)
        {
            moduloDto.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);
            modulo.FechaCreacion = DateOnly.FromDateTime(DateTime.Now); 
        }
        if(moduloDto.FechaModificacion == DateOnly.MinValue)
        {
            moduloDto.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
            modulo.FechaModificacion = DateOnly.FromDateTime(DateTime.Now);
        }
        _unitOfWork.ModulosMaestros.Update(modulo);
        await _unitOfWork.SaveAsync();
        return moduloDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var modulo = await _unitOfWork.ModulosMaestros.GetByIdAsync(id);
        if(modulo == null)
            return NotFound();
        _unitOfWork.ModulosMaestros.Remove(modulo);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}
