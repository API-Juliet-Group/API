/*
 * Author: Johan Ahlqvist
 */

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTO
{
    public class MäklareDto : LoginRequest
    {
        [Required]
        public string Förnamn { get; set; }
        [Required]
        public string Efternamn { get; set; }
        public string? BildURL { get; set; }
        public int? MäklarbyråId { get; set; }
    }
}
