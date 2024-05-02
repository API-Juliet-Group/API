using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Juliet.Models
{
    public class Bostad
    {
        public int Id { get; set; }

        public int Utgångspris { get; set; }
        public int Boarea { get; set; }
        public int Biarea { get; set; }
        public int Tomtarea { get; set; }
        public int Antalrum { get; set; }
        public int? Månadsavgift { get; set; }
        public int Driftkonstnad { get; set; }
        public int Byggår { get; set; }

        public string? Gatuadress { get; set; }
        public string? Ort { get; set; }
        public string? Objektbeskrivning { get; set; }


        public int KategoriId { get; set; }
        [ForeignKey("KategoriId")]
        public BostadKategori BostadKategori { get; set; }

        public int KommunId { get; set; }
        [ForeignKey("KommunId")]
        public Kommun Kommun { get; set; }

        public int? MäklareId { get; set; }
        [ForeignKey("MäklareId")]
        public Mäklare? Mäklare { get; set; }
    }
}
