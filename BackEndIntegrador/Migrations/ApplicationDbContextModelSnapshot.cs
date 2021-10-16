﻿// <auto-generated />
using System;
using BackEndIntegrador.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEndIntegrador.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEndIntegrador.Models.Materia", b =>
                {
                    b.Property<int>("id_materia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_materia");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("BackEndIntegrador.Models.Publicacion", b =>
                {
                    b.Property<int>("id_publicacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("fecha_actualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_publicacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_usuario")
                        .HasColumnType("int");

                    b.Property<string>("titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_publicacion");

                    b.HasIndex("id_usuario");

                    b.ToTable("Publicacion");
                });

            modelBuilder.Entity("BackEndIntegrador.Models.Rol", b =>
                {
                    b.Property<int>("id_rol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id_usuario")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_rol");

                    b.HasIndex("id_usuario");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("BackEndIntegrador.Models.Tema", b =>
                {
                    b.Property<int>("id_tema")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("contenido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("content_file")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("file_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("file_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_publicacion")
                        .HasColumnType("int");

                    b.HasKey("id_tema");

                    b.HasIndex("id_publicacion");

                    b.ToTable("Tema");
                });

            modelBuilder.Entity("BackEndIntegrador.Models.Usuario", b =>
                {
                    b.Property<int>("id_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("activation_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("can_publicaciones")
                        .HasColumnType("int");

                    b.Property<string>("celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("es_tutor")
                        .HasColumnType("bit");

                    b.Property<bool>("is_mail_confirmed")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rol")
                        .HasColumnType("int");

                    b.Property<string>("salt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_usuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("BackEndIntegrador.Models.UsuarioMateria", b =>
                {
                    b.Property<int>("id_usuario_materia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("calificacion")
                        .HasColumnType("float");

                    b.Property<byte[]>("content_file")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("file_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("file_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_materia")
                        .HasColumnType("int");

                    b.Property<int>("id_usuario")
                        .HasColumnType("int");

                    b.HasKey("id_usuario_materia");

                    b.HasIndex("id_materia");

                    b.HasIndex("id_usuario");

                    b.ToTable("UsuarioMateria");
                });

            modelBuilder.Entity("BackEndIntegrador.Models.Publicacion", b =>
                {
                    b.HasOne("BackEndIntegrador.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("id_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("BackEndIntegrador.Models.Rol", b =>
                {
                    b.HasOne("BackEndIntegrador.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("id_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("BackEndIntegrador.Models.Tema", b =>
                {
                    b.HasOne("BackEndIntegrador.Models.Publicacion", "publicacion")
                        .WithMany()
                        .HasForeignKey("id_publicacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("publicacion");
                });

            modelBuilder.Entity("BackEndIntegrador.Models.UsuarioMateria", b =>
                {
                    b.HasOne("BackEndIntegrador.Models.Materia", "materia")
                        .WithMany()
                        .HasForeignKey("id_materia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndIntegrador.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("id_usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("materia");

                    b.Navigation("usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
