using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace .UniOfWork;

public interface UniOfWork : IUnitOfWork, IDisposable
{

    private IAuditoria _auditorias;
    private IBlockchain _blockchains;
    private IEstadoNotificacion _estadoNotificaciones;
    private IFormato _formatos;
    private IGenericovsSubmodulos _genericovsSubmodulos;
    private IHiloRespuestaNotificacion _hiloRespuestaNotificaciones;
    private IMaestrovsSubmodulos _maestrovsSubmodulos;
    private IModuloNotificacion _moduloNotificaciones;
    private IModulosMaestro _modulosMaestros;
    private IPermisoGenericos _permisoGenericos;
    private IRadicados _radicados;
    private IRol _rols;
    private IRolvsMaestro _rolvsMaestros;
    private ISubModulos _subModulos;
    private ITipoNotificacion _tipoNotificaciones;
    private ITipoRequerimientos _tipoRequerimientos;

    private readonly NotiAppContext _context;
    public UniOfWork(NotiAppContext context)
    {
        _context = context;
    }
    public IAuditoria Auditorias
    {
        get
        {
            if (_auditorias == null)
            {
                _auditorias = new AuditoriaRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _auditorias;
        }
    }
    public IBlockchain Blockchains
    {
        get
        {
            if (_blockchains == null)
            {
                _blockchains = new BlockChainRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _blockchains;
        }
    }
    public IEstadoNotificacion EstadoNoficaciones
    {
        get
        {
            if (_estadoNotificaciones == null)
            {
                _estadoNotificaciones = new EstadoNoficacionRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _estadoNotificaciones;
        }
    }
    public IFormato Formato
    {
        get
        {
            if (_formatos == null)
            {
                _formatos = new FormatosRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _formatos;
        }
    }
    public IGenericovsSubmodulos GeneticovsSubmodulos
    {
        get
        {
            if (_genericovsSubmodulos == null)
            {
                _genericovsSubmodulos = new GeneticovsSubmodulosRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _genericovsSubmodulos;
        }
    }
    public IHiloRespuestaNotificacion HiloRepuestaNotificaciones
    {
        get
        {
            if (_hiloRespuestaNotificaciones == null)
            {
                _hiloRespuestaNotificaciones = new HiloRepuestaNotificacionRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _hiloRespuestaNotificaciones;
        }
    }
    public IMaestrovsSubmodulos MaestrovsSubmodulos
    {
        get
        {
            if (_maestrovsSubmodulos == null)
            {
                _maestrovsSubmodulos = new MaestrovsSubmoduloRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _maestrovsSubmodulos;
        }
    }
    public IModuloNotificacion ModuloNotificacion
    {
        get
        {
            if (_moduloNotificaciones == null)
            {
                _moduloNotificaciones = new ModuloNotificacionRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _moduloNotificaciones;
        }
    }
    public IModulosMaestro ModuloMaestro
    {
        get
        {
            if (_modulosMaestros == null)
            {
                _modulosMaestros = new ModuloMaestroRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _modulosMaestros;
        }
    }
    public IPermisoGenericos PermisosGenericos
    {
        get
        {
            if (_permisoGenericos == null)
            {
                _permisoGenericos = new PermisosGenericosRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _permisoGenericos;
        }
    }
    public IRadicados Radicados
    {
        get
        {
            if (_radicados == null)
            {
                _radicados = new RadicadosRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _radicados;
        }
    }
    public IRol Rol
    {
        get
        {
            if (_rols == null)
            {
                _rols = new RolRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _rols;
        }
    }
    public IRolvsMaestro RolvsMaestro
    {
        get
        {
            if (_rolvsMaestros == null)
            {
                _rolvsMaestros = new RolvsMaestroRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _rolvsMaestros;
        }
    }
    public ISubModulos SubModulo
    {
        get
        {
            if (_subModulos == null)
            {
                _subModulos = new SubModulosRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _subModulos;
        }
    }
    public ITipoNotificacion TipoNotificacion
    {
        get
        {
            if (_tipoNotificaciones == null)
            {
                _tipoNotificaciones = new TipoNotificacionRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _tipoNotificaciones;
        }
    }
    public ITipoRequerimientos TipoRequerimiento
    {
        get
        {
            if (_tipoRequerimientos == null)
            {
                _tipoRequerimientos = new TipoRequerimientoRepository(_context); // Remember putting the base in the repository of this entity
            }
            return _tipoRequerimientos;
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }




}

