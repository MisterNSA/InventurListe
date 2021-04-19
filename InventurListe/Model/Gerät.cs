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
        [RegularExpression(@"CCB.{8}", ErrorMessage = "Wird als PK verwendet! Muss mit den Großbuchstaben CCB anfangen, gefolgt von 8 Zeichen")]
        public string InventurNr { get; set; }

        [Required]
        public int GeräteTypId { get; set; }

        [Required]
        public int HausId { get; set; }

        
        [RegularExpression(@"[A-F0-9]{12}", ErrorMessage = "Eine MAC-Adresse darf nur Großbuchstaben von A-F und Zahlen von 0-9 enthalten. Die Länge muss 12 Zeichen betragen")]
        public string MAC { get; set; }

        [RegularExpression(@"\d\d\d\.\d\d\d\.\d\d\d\.\d\d\d", ErrorMessage = "Die IP enthält 4 Blöcke von je 3 Zahlen. Die Blöcke müssen durch einen Punkt voneinander getrennt werden")]
        public string IP { get; set; }

        [Required]
        public string Name { get; set; }

        public int BetriebssystemId { get; set; }

        public int VianovaNr { get; set; }

        [Required]
        public int AbteilungId { get; set; }

        // Verknüpfung mit Untertabellem

        public virtual GeräteTyp GeräteTyp { get; set; }
        public virtual Haus Haus { get; set; }
        public virtual Abteilung Abteilung { get; set; }
        public virtual Betriebssystem Betriebssystem { get; set; }
    }
}
