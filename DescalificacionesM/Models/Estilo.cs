//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Estilo
    {
        public Estilo()
        {
            this.Descalificacions = new HashSet<Descalificacion>();
            this.Eventoes = new HashSet<Evento>();
        }
    
        public int EstiloID { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<Descalificacion> Descalificacions { get; set; }
        public virtual ICollection<Evento> Eventoes { get; set; }
    }
}
