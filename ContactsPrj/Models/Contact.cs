using System;
using System.ComponentModel.DataAnnotations;

namespace ContactsPrj.Models
{
    public class Contact
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Телефон")]
        public string MobilePhone { get; set; }

        [Display(Name = "Должность")]
        public string JobTitle { get; set; }

        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }
    }
}