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
    
    public partial class Extradition
    {
        public int id { get; set; }
        public int instance_id { get; set; }
        public int reader_id { get; set; }
        public Nullable<System.DateTime> date_extradition { get; set; }
        public Nullable<System.DateTime> return_date { get; set; }
    
        public virtual Instance Instance { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
