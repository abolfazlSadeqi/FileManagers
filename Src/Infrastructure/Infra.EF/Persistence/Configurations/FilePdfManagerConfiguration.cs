//using Domain.Entites.FilePdfManagers;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infra.EF.Persistence.Configurations;

//public class FilePdfManagerConfiguration : IEntityTypeConfiguration<FilePdfManager>
//{
//    public void Configure(EntityTypeBuilder<FilePdfManager> builder)
//    {
//        builder.ToTable("FilePdfManager");


//        builder.Property(e => e.Id)
//            .ValueGeneratedOnAdd();


//        builder.Property(e => e.Name)
//            .HasMaxLength(100).HasColumnType("VARCHAR(100)");

//        builder.Property(e => e.File_type)
//            .HasMaxLength(100).HasColumnType("VARCHAR(20)");

//        builder.Property(e => e.CreationTime)
//          .HasColumnName("Creation_time");

//        builder.Property(e => e.LastWriteTime)
//      .HasColumnName("Last_write_time");

//        builder.Property(e => e.LastAccessTime)
//.HasColumnName("Last_access_time");

        
//    }

//}