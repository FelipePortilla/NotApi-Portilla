using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class ModuloMaestros : BaseEntity
{
    public string NombreModulo { get; set; }
    public ICollection<MaestrosvsSubmodulos> MaestrosvsSubmodulos { get; set; }
    public ICollection<RolvsMaestro> RolvsMaestros { get; set; }
}
