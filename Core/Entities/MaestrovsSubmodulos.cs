using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class MaestrovsSubmodulos : BaseEntity
    {
        [Required]
        public DateOnly FechaCreacion { get; set; }
        [Required]
        public DateOnly FechaModificacion { get; set; }
        public int IdMaestroFk { get; set; }
        public ModuloMaestro ModulosMaestros { get; set; }
        public int IdSubModulosFk { get; set; }
        public SubModulos SubModulos { get; set; }
        public ICollection<GenericovsSubmodulos> GenericovsSubmodulos { get; set; }
    }
}