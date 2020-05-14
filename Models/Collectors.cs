using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NumizmatDictionary.Models
{
    public class Collectors
    {
        [Key]
        public int Id { get; set; }

        [Required]

        [DisplayName("Страна")]
        public string Country { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Контактные координаты")]
        public string Contacts { get; set; }

        [DisplayName("Наличие редких монет в коллекции")]
        public string AvailabilityInCollection { get; set; }

    }
}
