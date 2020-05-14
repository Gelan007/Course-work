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

        [DisplayName("Название монеты")]
        public string CoinsName { get; set; }

        [Required]
        [DisplayName("Страна")]
        public string Country { get; set; }

        [DisplayName("Номинал")]
        public string FaceValue { get; set; }

        [DisplayName("Год выпуска")]
        public string Year { get; set; }

        [DisplayName("Металл или сплав")]
        public string MetalOrAlloy { get; set; }

        [DisplayName("Кол-во выпущеных монет")]
        public string NumberOfCoins { get; set; }

        [DisplayName("Особенности")]
        public string Features { get; set; }
    }
}
