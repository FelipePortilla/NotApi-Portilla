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
    public class MaestrovsSubmoduloConfiguration : IEntityTypeConfiguration<MaestrovsSubmodulos>
{
    public void Configure(EntityTypeBuilder<MaestrovsSubmodulos> builder)
    {
        builder.ToTable("maestrovssubmodulos");
        
        builder.HasKey(x=>x.Id);
        builder.Property(x=>x.Id);

        builder.Property(x=>x.FechaCreacion).HasColumnType("date");
        builder.Property(x=>x.FechaModificacion).HasColumnType("date");

        builder.HasOne(x=>x.ModulosMaestros).WithMany(x=>x.MaestrosvsSubmodulos).HasForeignKey(x=>x.IdMaestroFk);
        builder.HasOne(x=>x.SubModulos).WithMany(x=>x.MaestrosvsSubmodulos).HasForeignKey(x=>x.IdSubModulosFk);

    }
}
}