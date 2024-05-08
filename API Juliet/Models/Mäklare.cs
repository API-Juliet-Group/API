using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Juliet.Models
{
    public class Mäklare : IdentityUser
    {
        public override string Id { get => base.Id; set => base.Id = value; }
        [Required]
        public string Förnamn { get; set; }
        [Required]
        public string Efternamn { get; set; }
        public string? BildURL { get; set; }


        public int MäklarbyråId { get; set; }
        [ForeignKey("MäklarbyråId")]
        public Mäklarbyrå Mäklarbyrå { get; set; }
    }
}
