//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aplicacion_Prueba_Tecnica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CUENTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUENTA()
        {
            this.NOTA_CREDITO_DEBITO = new HashSet<NOTA_CREDITO_DEBITO>();
        }
    
        public int ID_CUENTA { get; set; }
        public Nullable<long> NUMERO_CUENTA { get; set; }
        public Nullable<int> ID_CLIENTE { get; set; }
        public Nullable<int> ID_TIPO_CUENTA { get; set; }
        public Nullable<long> CREDITO_LIMITE { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA_APERTURA { get; set; }
        public Nullable<int> ID_ESTADO { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTA_CREDITO_DEBITO> NOTA_CREDITO_DEBITO { get; set; }
        public virtual TIPO_CUENTA TIPO_CUENTA { get; set; }
        public virtual TIPO_ESTADO TIPO_ESTADO { get; set; }
    }
}
