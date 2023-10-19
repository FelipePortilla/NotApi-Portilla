using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Rol : BaseEntity
    {


        [Required]
        public string NombreRol { get; set; }
        public DateOnly FechaCreacion { get; set; }
        [Required]
        public DateOnly FechaModificacion { get; set; }
        public ICollection<ModuloNotificacion> ModuloNotificaciones { get; set; }
        public ICollection<GenericovsSubmodulos> GenericovsSubmodulos { get; set; }
        public ICollection<RolvsMaestro> RolvsMaestros { get; set; }

    }
}