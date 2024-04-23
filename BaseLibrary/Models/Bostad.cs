namespace BaseLibrary.Models
{
    public class Bostad
    {
        public int Id { get; set; }
        public BostadKategori BostadKategori { get; set; }
        public string Adress { get; set; }
        public Kommun Kommun { get; set; }
        public int Utgångspris {  get; set; }
        public int Boarea { get; set; }
        public int Biarea { get; set; }
        public int Tomtarea { get; set; }
        public string Objektbeskrivning { get; set; }
        public int Antalrum { get; set; }
        public int Månadsavgift { get; set; }
        public int Driftkonstnad {  get; set; }
        public int Byggår {  get; set; }
        public Mäklare Mäklare { get; set; }
    }
}
