using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class PermisosGenericos :BaseEntity
    {
         [Required]
    public string NombrePermiso { get; set; }
    [Required]
    public DateOnly FechaCreacion { get; set; }
    [Required]
    public DateOnly FechaModificacion { get; set; }
    public ICollection<GenericovsSubmodulos> GenericovsSubmodulos { get; set; }
    }
}