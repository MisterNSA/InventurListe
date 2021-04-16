using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventurListe.Model
{
    public class Stockwerk
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StockName { get; set; }
    }
}
