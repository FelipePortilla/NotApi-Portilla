using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class SubModulos :BaseEntity
    {
        [Required]
    public string NombreSubModulo { get; set; }
    [Required]
    public DateOnly FechaCreacion { get; set; }
    [Required]
    public DateOnly FechaModificacion { get; set; }
    public ICollection<MaestrovsSubmodulos> MaestrosvsSubmodulos { get; set; }
    }
}