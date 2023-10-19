using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UniOfWork;


public class UnitOfWork : IUnitOfWork,IDisposable
{
    private readonly NotiAppContext _context;
    private IAuditoria _Auditorias;
    private IBlockchain _BlockChains;
    private IEstadoNotificacion _EstadoNotificaciones;
    private IFormato _Formatos;
    private IGenericovsSubmodulos _GenericoVsSubmodulos;
    private IHiloRespuestaNotificacion _HiloRespuestaNotificaciones;
    private IMaestrovsSubmodulos _MaestrosVsSubmodulos;
    private IModulosMaestro _ModuloMaestros;
    private IModuloNotificacion _ModuloNotificaciones;
    private IPermisoGenericos _PermisosGenericos;
    private IRadicados _Radicados;
    private IRol _Roles;
    private IRolvsMaestro _RolVsMaestros;
    private ISubModulos _Submodulos;
    private ITipoNotificacion _TipoNotificaciones;
    private ITipoRequerimientos _TipoRequerimientos;

    public UnitOfWork(NotiAppContext context)
    {
        _context = context;
    }

    public IAuditoria Auditorias
    {
        get
        {
            if (_Auditorias == null)
            {
                _Auditorias = new AuditoriaRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _Auditorias;
        }
    }

    public IBlockchain BlockChains
    {
        get
        {
            if (_BlockChains == null)
            {
                _BlockChains = new BlockChainRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _BlockChains;
        }
    }

    public IEstadoNotificacion EstadoNotificaciones
    {
        get
        {
            if (_EstadoNotificaciones == null)
            {
                _EstadoNotificaciones = new EstadoNoficacionRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _EstadoNotificaciones;
        }
    }

    public IFormato Formatos
    {
        get
        {
            if (_Formatos == null)
            {
                _Formatos = new FormatosRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _Formatos;
        }
    }

    public IGenericovsSubmodulos GenericoVsSubmodulos
    {
        get
        {
            if (_GenericoVsSubmodulos == null)
            {
                _GenericoVsSubmodulos = new GeneticovsSubmodulosRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _GenericoVsSubmodulos;
        }
    }

    public IHiloRespuestaNotificacion HiloRespuestaNotificaciones
    {
        get
        {
            if (_HiloRespuestaNotificaciones == null)
            {
                _HiloRespuestaNotificaciones = new HiloRepuestaNotificacionRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _HiloRespuestaNotificaciones;
        }
    }

    public IMaestrovsSubmodulos MaestrosVsSubmodulos
    {
        get
        {
            if (_MaestrosVsSubmodulos == null)
            {
                _MaestrosVsSubmodulos = new MaestrovsSubmoduloRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _MaestrosVsSubmodulos;
        }
    }

    public IModulosMaestro ModuloMaestros
    {
        get
        {
            if (_ModuloMaestros == null)
            {
                _ModuloMaestros = new ModuloMaestroRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _ModuloMaestros;
        }
    }

    public IModuloNotificacion ModuloNotificaciones
    {
        get
        {
            if (_ModuloNotificaciones == null)
            {
                _ModuloNotificaciones = new ModuloNotificacionRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _ModuloNotificaciones;
        }
    }

    public IPermisoGenericos PermisosGenericos
    {
        get
        {
            if (_PermisosGenericos == null)
            {
                _PermisosGenericos = new PermisosGenericosRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _PermisosGenericos;
        }
    }

    public IRadicados Radicados
    {
        get
        {
            if (_Radicados == null)
            {
                _Radicados = new RadicadosRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _Radicados;
        }
    }

    public IRol Roles
    {
        get
        {
            if (_Roles == null)
            {
                _Roles = new RolRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _Roles;
        }
    }

    public IRolvsMaestro RolVsMaestros
    {
        get
        {
            if (_RolVsMaestros == null)
            {
                _RolVsMaestros = new RolvsMaestroRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _RolVsMaestros;
        }
    }

    public ISubModulos Submodulos
    {
        get
        {
            if (_Submodulos == null)
            {
                _Submodulos = new SubmodulosRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _Submodulos;
        }
    }

    public ITipoNotificacion TipoNotificaciones
    {
        get
        {
            if (_TipoNotificaciones == null)
            {
                _TipoNotificaciones = new TipoNotificacionRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _TipoNotificaciones;
        }
    }

    public ITipoRequerimientos TipoRequerimientos
    {
        get
        {
            if (_TipoRequerimientos == null)
            {
                _TipoRequerimientos = new TipoRequerimientoRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _TipoRequerimientos;
        }
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
