// <auto-generated />
using System;
using Challenge_Backend_Financas.Configuracoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Challenge_Backend_Financas.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20220813163510_AtualiacaoNomeIdCategoria")]
    partial class AtualiacaoNomeIdCategoria
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Challenge_Backend_Financas.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCategoria");

                    b.Property<string>("NomeCategoria")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("nomeCategoria");

                    b.HasKey("Id");

                    b.ToTable("tbCategoria");
                });

            modelBuilder.Entity("Challenge_Backend_Financas.Models.Despesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdDespesa");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DataDespesa");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("DescricaoDespesa");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<double>("Valor")
                        .HasColumnType("double")
                        .HasColumnName("ValorDespesa");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("TbDespesa");
                });

            modelBuilder.Entity("Challenge_Backend_Financas.Models.Receita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdReceita");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DataReceita");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("DescricaoReceita");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<double>("Valor")
                        .HasColumnType("double")
                        .HasColumnName("ValorReceita");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("TbReceita");
                });

            modelBuilder.Entity("Challenge_Backend_Financas.Models.Despesa", b =>
                {
                    b.HasOne("Challenge_Backend_Financas.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Challenge_Backend_Financas.Models.Receita", b =>
                {
                    b.HasOne("Challenge_Backend_Financas.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
