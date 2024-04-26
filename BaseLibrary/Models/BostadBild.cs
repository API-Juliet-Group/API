using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Models
{
    public class BostadBild
    {
        public int Id { get; set; }

        public string? BildURL { get; set; }

        public Bostad Bostad { get; set; }
    }
}
