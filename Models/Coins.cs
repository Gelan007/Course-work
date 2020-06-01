using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NumizmatDictionary.Models
{
    public class Coins
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Название монеты")]
        public string CoinsName { get; set; }

        [Required]
        [DisplayName("Страна")]
        public string Country { get; set; }

        [Required]
        [DisplayName("Стоимость")]
        public string FaceValue { get; set; }
        [RegularExpression("[1-9]{1}[0-9]{0,}", ErrorMessage = "Введите число больше нуля")]

        [Required]
        [DisplayName("Год выпуска")]
        public string Year { get; set; }

        [Required]
        [DisplayName("Металл или сплав")]
        public string MetalOrAlloy { get; set; }

        [Required]
        [DisplayName("Кол-во выпущеных монет")]
        public string NumberOfCoins { get; set; }

        [Required]
        [DisplayName("Особенности")]
        public string Features { get; set; }
    }
}
