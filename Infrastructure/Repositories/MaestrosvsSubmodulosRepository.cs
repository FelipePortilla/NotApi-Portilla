using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MaestrosvsSubmodulosRepository : GenericRepository<MaestrosvsSubmodulos>,IMaestrosvsSubmodulos
{
    private readonly NotiAppContext _context;

    public MaestrosvsSubmodulosRepository(NotiAppContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MaestrosvsSubmodulos>> GetAllAsync()
    {
        return await _context.MaestrosvsSubmodulos
        .Include(h => h.GenericovsSubmodulos)
        .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<MaestrosvsSubmodulos> registros)> GetAllAsync(
        int pageIndex,
        int pageSize,
        string search
    )
    {
        var query = _context.MaestrosvsSubmodulos as IQueryable<MaestrosvsSubmodulos>;
    
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Id.ToString().ToLower().Contains(search)); // If necesary add .ToString() after varQuery
        }
        query = query.OrderBy(p => p.Id);
    
        var totalRegistros = await query.CountAsync();
        var registros = await query
                        .Include(h => h.GenericovsSubmodulos)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        return (totalRegistros, registros);
    }
}
