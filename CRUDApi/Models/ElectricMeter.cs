using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDApi.Models
{
    public class ElectricMeter
    {
        public long id { get; set; }

        [Required(ErrorMessage = "Campo Obligatirio")]
        [StringLength(50, ErrorMessage = "Superado máximo de carácteres.")]
        public string SerialNumber { get; set; }
        [StringLength(50, ErrorMessage = "Superado máximo de carácteres.")]
        public string Brand { get; set; }
        [StringLength(50, ErrorMessage = "Superado máximo de carácteres.")]
        public string Model { get; set; }
    }
}
