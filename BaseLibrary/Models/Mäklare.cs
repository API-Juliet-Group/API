using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseLibrary.Models
{
    public class Mäklare
    {
        public int Id { get; set; }

        [Required]
        public string Förnamn { get; set; }
        [Required]
        public string Efternamn { get; set; }
        [EmailAddress]
        public string Epostadress {  get; set; }

        public string? Telefonnummer { get; set; }
        public string? BildURL { get; set; }


        public int MäklarbyråId { get; set; }
        [ForeignKey("MäklarbyråId")]
        public Mäklarbyrå Mäklarbyrå { get; set; }
    }
}
