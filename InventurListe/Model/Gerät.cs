using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventurListe.Model
{
    public class Gerät
    {
        [Key]
        public string InventurNr { get; set; }

        [Required]
        public int GeräteTypId { get; set; }

        [Required]
        public int HausId { get; set; }

        [Required]
        [RegularExpression(@"[A-F0-9]{12}", ErrorMessage = "Eine MAC-Adresse darf nur Großbuchstaben von A-F und Zahlen von 0-9 enthalten. Die Länge muss 12 Zeichen betragen")]
        public string MAC { get; set; }

        [Required]
        public string IP { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int OsIs { get; set; }

        public int VianovaNr { get; set; }

        [Required]
        public int AbteilungId { get; set; }
    }
}
