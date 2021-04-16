using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventurListe.Model
{
    public class Standort
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StandortName { get; set; }
    }
}
