using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class BlockChain : BaseEntity
{
     [Required]
    public string HashGenerado { get; set; }
    [Required]
    public DateOnly FechaCreacion { get; set; }
    [Required]
    public DateOnly FechaModificacion { get; set; }
    public int IdAuditoriaFk { get; set; }
    public Auditoria Auditorias { get; set; }
    public int IdTipoNotificacionesFk { get; set; }
    public TipoNotificacion TipoNotificaciones { get; set; }
    public int IdHiloRespuestaFk { get; set; }
    public HiloRespuesNotificacion HiloRespuesNotificaciones { get; set; }
}
