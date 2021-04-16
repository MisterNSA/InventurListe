using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventurListe.Model
{
    public class Raum
    {
        [Key]
        public int Id { get; set; }

        public String RaumName { get; set; }
    }
}
