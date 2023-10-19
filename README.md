# NotApi-Portilla


### Creacion de Proyecto

##### Creacion solucion de proyecto

```dotnet
 dotnet new sln
```

##### Creacion proyecto WebApi

```dotnet
dotnet new webapi -o FolderDestino
```

##### Creacion de proyectos Classlib

```dotnet
dotnet new classlib -o Core
dotnet new classlib -o Infrastructure
```

##### Agregar proyectos a la solucion.

```dotnet
dotnet sln add ApiAnimals
dotnet sln add Core
dotnet sln add Infrastructure
```

##### Agregar la solucion entre proyectos

```dotnet
dotnet add reference ..\Infrastructure
dotnet add reference ..\Core
```

### Instalacion de paquetes

##### Proyecto webapi

```dotnet
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.11
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.11
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.11
dotnet add package Microsoft.Extensions.DependencyInjection --version 7.0.0
dotnet add package System.IdentityModel.Tokens.Jwt --version 6.32.3
dotnet add package Serilog.AspNetCore --version 7.0.0
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
```

##### Proyecto Infrastructure

```dotnet
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 7.0.0
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.11
dotnet add package CsvHelper --version 30.0.1

##### Dtos
namespace API.Dtos;

public class BlockChainDto
{
    public int Id { get; set; }
    public string HashGenerado { get; set; }
    public DateOnly FechaCreacion { get; set; }
    public DateOnly FechaModificacion { get; set; }
    public int IdTipoNotificacion { get; set; }
    public int IdHiloRespuesta { get; set; }
    public int IdAuditoria { get; set; }
}

