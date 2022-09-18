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
        public DateTime BirthDate { get; set; }
    }
}