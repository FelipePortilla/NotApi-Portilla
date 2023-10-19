using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class MaestrosvsSubmodulos : BaseEntity
{
    public int IdMaestro { get; set; }
    public ModuloMaestros ModuloMaestros { get; set; }
    public int IdSubmodulos { get; set; }
    public Submodulos Submodulos { get; set; }
    public ICollection<GenericovsSubmodulos> GenericovsSubmodulos { get; set; }
}
