using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class GenericovsSubmodulos : BaseEntity
{
    public int IdGenericos { get; set; }
    public PermisosGenericos PermisosGenericos { get; set; }
    public int IdSubmodulos { get; set; }
    public MaestrosvsSubmodulos MaestrosvsSubmodulos { get; set; }
    public int IdRol { get; set; }
    public Rol Roles { get; set; }
}
