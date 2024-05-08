using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTO
{
    public class MäklareDto : LoginDto
    {
        [Required]
        public string Förnamn { get; set; }
        [Required]
        public string Efternamn { get; set; }
    }
}
