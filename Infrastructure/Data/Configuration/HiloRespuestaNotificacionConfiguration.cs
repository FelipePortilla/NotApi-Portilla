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
    public class HiloRespuestaNotificacionConfiguration: IEntityTypeConfiguration<HiloRespuesNotificacion>
{
    public void Configure(EntityTypeBuilder<HiloRespuesNotificacion> builder)
    {
        builder.ToTable("hilorespuestanotificacion");

        builder.HasKey(x=>x.Id);
        builder.Property(x=>x.Id);

        builder.Property(x=>x.NombreHiloRespuesta).IsRequired().HasMaxLength(80);
        builder.Property(x=>x.FechaCreacion).HasColumnType("date");
        builder.Property(x=>x.FechaModificacion).HasColumnType("date");
    }
}
}