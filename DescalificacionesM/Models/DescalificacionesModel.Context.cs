﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DescalificacionesM.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DescalificacionesFMNEntities : DbContext
    {
        public DescalificacionesFMNEntities()
            : base("name=DescalificacionesFMNEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<Descalificacion> Descalificacions { get; set; }
        public DbSet<Estilo> Estiloes { get; set; }
        public DbSet<Evento> Eventoes { get; set; }
        public DbSet<Heat> Heats { get; set; }
        public DbSet<Nadador> Nadadors { get; set; }
        public DbSet<Prueba> Pruebas { get; set; }
        public DbSet<Rama> Ramas { get; set; }
    }
}
