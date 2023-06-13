using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Calisanlar.Models
{
    public class Calisan
    {
        [Key]
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string SicilNo { get; set; }
        public List<Calisan> Astlar { get; set; }
        public Calisan Ust { get; set; }
    }
}
