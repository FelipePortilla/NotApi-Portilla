using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ModuloMaestro : BaseEntity

    {
        public string NombreModuloMaestro { get; set; }
        [Required]
        public DateOnly FechaCreacion { get; set; }
        [Required]
        public DateOnly FechaModificacion { get; set; }
        public ICollection<GenericovsSubmodulos> GenericovsSubmodulos { get; set; }
        public ICollection<MaestrovsSubmodulos> MaestrosvsSubmodulos { get; set; }
        public ICollection<RolvsMaestro> RolvsMaestros { get; set; }
    

    }
}