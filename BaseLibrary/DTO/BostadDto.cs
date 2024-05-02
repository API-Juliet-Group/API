namespace BaseLibrary.DTO
{
    public class BostadDto
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


        public string Kategori { get; set; }
        public string Kommun { get; set; }
        public string? Mäklare { get; set; }
    }
}
