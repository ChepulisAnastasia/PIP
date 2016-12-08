//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BooksLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Instance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Instance()
        {
            this.Extraditions = new HashSet<Extradition>();
        }
    
        public int id { get; set; }
        [Display(Name = "№ Комнаты")]
        public short room { get; set; }
        [Display(Name = "№ Стеллажа")]
        public short rack { get; set; }
        [Display(Name = "№ Полки")]
        public short shelf { get; set; }
        [Display(Name = "Наличие")]
        public string existence { get; set; }
        public string ISBN { get; set; }
    
        public virtual Book Book { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Extradition> Extraditions { get; set; }
    }
}
