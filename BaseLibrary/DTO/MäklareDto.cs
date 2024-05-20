using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
