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

    public partial class Debtor
    {
        [Display(Name = "Фамилия")]
        public string last_name { get; set; }
        [Display(Name = "Имя")]
        public string name { get; set; }
        [Display(Name = "Отчество")]
        public string middle_name { get; set; }
        [Display(Name = "Телефон")]
        public string phone { get; set; }
        [Display(Name = "Количество дней отсутствия книги в библиотеке")]
        public Nullable<int> count_days { get; set; }
    }
}
