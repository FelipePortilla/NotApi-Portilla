using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class Rol : BaseEntity
{
    public string Nombre { get; set; }
    public ICollection<GenericovsSubmodulos> GenericovsSubmodulos { get; set; }
    public ICollection<RolvsMaestro> RolvsMaestros { get; set; }
}
