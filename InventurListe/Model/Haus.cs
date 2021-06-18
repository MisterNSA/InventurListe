using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventurListe.Model
{
    public class Haus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StandortId { get; set; }

        // ? = Lässt NULL-Werte zu
        public int? RaumId { get; set; }

        [Required]
        public int StockId { get; set; }

        [Required]
        public string HausName { get; set; }

        public virtual Stockwerk Stockwerk { get; set; }
        public virtual Raum Raum { get; set; }
        public virtual Standort Standort { get; set; }
    }
}
