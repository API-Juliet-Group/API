namespace API_Juliet.Models
{
    public class Mäklare
    {
        public int Id { get; set; }
        public Mäklarbyrå Mäklarbyrå { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Epostadress {  get; set; }
        public string Telefonnummer { get; set; }
        public string Bild { get; set; }
    }
}
