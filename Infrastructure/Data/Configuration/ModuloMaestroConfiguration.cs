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
    public class ModuloMaestroConfiguration : IEntityTypeConfiguration<ModuloMaestro>
    {
        public void Configure(EntityTypeBuilder<ModuloMaestro> builder)
    {
        builder.ToTable("modulosmaestro");

        builder.HasKey(x=>x.Id);
        builder.Property(x=>x.Id);

        builder.Property(x=>x.NombreModuloMaestro).IsRequired().HasMaxLength(100);
        builder.Property(x=>x.FechaCreacion).HasColumnType("date");
        builder.Property(x=>x.FechaModificacion).HasColumnType("date");
    }
    }
}