using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventurListe.Model
{
    public class GeräteTyp
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Modell { get; set; }

        [Required]
        public String GerätTyp { get; set; }
    }
}
