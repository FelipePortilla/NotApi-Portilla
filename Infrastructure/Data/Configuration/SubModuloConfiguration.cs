using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configuration
{
    public class SubModuloConfiguration : IEntityTypeConfiguration<SubModulos>
{
    public void Configure(EntityTypeBuilder<SubModulos> builder)
    { 
        builder.ToTable("submodulos");

        builder.HasKey(x=>x.Id);
        builder.Property(x=>x.Id);

        builder.Property(x=>x.NombreSubModulo).IsRequired().HasMaxLength(80);
        builder.Property(x=>x.FechaCreacion).HasColumnType("date");
        builder.Property(x=>x.FechaModificacion).HasColumnType("date");
    }
}

}