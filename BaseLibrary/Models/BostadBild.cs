using System.ComponentModel.DataAnnotations.Schema;

namespace BaseLibrary.Models
{
    public class BostadBild
    {
        public int Id { get; set; }

        public string? BildURL { get; set; }
        

        public int BostadId { get; set; }
        [ForeignKey("BostadId")]
        public Bostad Bostad { get; set; }
    }
}
