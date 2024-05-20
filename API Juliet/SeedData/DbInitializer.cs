using API_Juliet.Constants;
using API_Juliet.Data;
using API_Juliet.Models;

namespace API_Juliet.SeedData
{
    public static class DbInitializer
    {
        public static WebApplication Seed(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                try
                {
                    context.Database.EnsureCreated();

                    var kategori = context.BostadKategorier.FirstOrDefault();
                    var kommun = context.Kommuner.FirstOrDefault();

                    if (kategori == null)
                    {
                        context.BostadKategorier.AddRange(GetKategoriData());
                    }
                    if(kommun == null)
                    {
                        context.Kommuner.AddRange(GetKommunData());
                    }
                    context.SaveChanges();

                    var Bostad = context.Bostäder.FirstOrDefault();

                    if (Bostad == null)
                    {
                        context.Bostäder.AddRange(GetBostadData());
                    }
                    //Här kan det bli Error om datan laddas ojämnt, töm batamasen och gö en ny migration. 
                    context.SaveChanges();

                    var Bild = context.BostadsBilder.FirstOrDefault();

                    if (Bild == null)
                    {
                        context.BostadsBilder.AddRange(GetBildData());
                    }
                    //Här kan det bli Error om datan laddas ojämnt, töm databasen och gö en ny migration.
                    //Det blir garanterat Error om man raderar alla bostäder och startar om programet.
                    //Bildernas FK till Bostäderna måste stämma, och för det behöver det finnas Bostäder med Id 1,2,3,4 och 5.
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

                return app;
            }
        }

        public static List<BostadKategori> GetKategoriData()
        {
            var kommunList = new List<BostadKategori>
            {
                new BostadKategori { Namn = "Bostadsrättslägenhet" },
                new BostadKategori { Namn = "Bostadsrättsradhus" },
                new BostadKategori { Namn = "Villa" },
                new BostadKategori { Namn = "Fritidshus" }
            };
            return kommunList;
        }

        public static List<Bostad> GetBostadData()
        {
            var bostadList = new List<Bostad>
            {
                new Bostad { Utgångspris = 2500000, Boarea = 63, Biarea = 25, Tomtarea = 629, Antalrum = 2, Månadsavgift = null, Driftkonstnad = 29407, Byggår = 2020, Gatuadress = "Tegelbruksvägen x", Ort ="Duved", Objektbeskrivning = "Huset är uppdelat i zoner där entrén ligger som en central del.", KategoriId = 4, KommunId = 270, MäklareId = SeedUserId.MäklareId, },
                new Bostad { Utgångspris = 3400000, Boarea = 101, Biarea = 15, Tomtarea = 889, Antalrum = 4, Månadsavgift = null, Driftkonstnad = 31024, Byggår = 2018, Gatuadress = "Nystrandsvägen x", Ort ="Hemse", Objektbeskrivning = "Husets öppna planlösning drar full nytta av de stora ljusinsläppen.", KategoriId = 4, KommunId = 52, MäklareId = SeedUserId.MäklareId, },
                new Bostad { Utgångspris = 4600000, Boarea = 133, Biarea = 22, Tomtarea = 400, Antalrum = 5, Månadsavgift = null, Driftkonstnad = 32156, Byggår = 2012, Gatuadress = "Morellgången x", Ort ="Göteborg", Objektbeskrivning = "Ett trivsamt gavelställt tvåplanshus.", KategoriId = 3, KommunId = 58, MäklareId = SeedUserId.MäklareId, },
                new Bostad { Utgångspris = 1600000, Boarea = 30, Biarea = 6, Tomtarea = 0, Antalrum = 1, Månadsavgift = 2129, Driftkonstnad = 5354, Byggår = 1939, Gatuadress = "Gamla Tanneforsvägen x", Ort ="Tannefors", Objektbeskrivning = "Toppmodern etta med coola vinklar", KategoriId = 1, KommunId = 125, MäklareId = SeedUserId.MäklareId, },
                new Bostad { Utgångspris = 5650000, Boarea = 141, Biarea = 172, Tomtarea = 644, Antalrum = 5, Månadsavgift = null, Driftkonstnad = 51227, Byggår = 1900, Gatuadress = "Solrosvägen x", Ort ="Viken", Objektbeskrivning = "Ett flexibelt boende i lugnt och tryggt område.", KategoriId = 2, KommunId = 84, MäklareId = SeedUserId.MäklareId, },
                new Bostad { Utgångspris = 2000000, Boarea = 100, Biarea = 25, Tomtarea = 700, Antalrum = 4, Månadsavgift = null, Driftkonstnad = 29000, Byggår = 2011, Gatuadress = "Norum x", Ort ="Bjästa", Objektbeskrivning = "Den klassiska husdrömmen.", KategoriId = 3, KommunId = 284, MäklareId = SeedUserId.MäklareId, },
                new Bostad { Utgångspris = 2000000, Boarea = 150, Biarea = 30, Tomtarea = 400, Antalrum = 6, Månadsavgift = null, Driftkonstnad = 31000, Byggår = 2004, Gatuadress = "Pennyvägen x", Ort ="Själevad", Objektbeskrivning = "Ett enplanshus för den stora familjen", KategoriId = 3, KommunId = 284, MäklareId = SeedUserId.MäklareId, },
                new Bostad { Utgångspris = 2000000, Boarea = 148, Biarea = 35, Tomtarea = 680, Antalrum = 7, Månadsavgift = null, Driftkonstnad = 32156, Byggår = 2012, Gatuadress = "Kläppavägen x", Ort ="Köpmanholmen", Objektbeskrivning = "Rum för hela familjen.", KategoriId = 3, KommunId = 284, MäklareId = SeedUserId.MäklareId, },
                new Bostad { Utgångspris = 2000000, Boarea = 134, Biarea = 10, Tomtarea = 350, Antalrum = 5, Månadsavgift = null, Driftkonstnad = 34000, Byggår = 2015, Gatuadress = "Samhällsvägen x", Ort ="Domsjö", Objektbeskrivning = "Huset är verkligen något extra.", KategoriId = 3, KommunId = 284, MäklareId = SeedUserId.MäklareId, },
                new Bostad { Utgångspris = 3200000, Boarea = 97, Biarea = 5, Tomtarea = 0, Antalrum = 3, Månadsavgift = 3307, Driftkonstnad = 32156, Byggår = 1945, Gatuadress = "Framnäsgatan x", Ort ="Örnsköldsvik", Objektbeskrivning = "Modern trea med ett okej läge.", KategoriId = 1, KommunId = 284, MäklareId = SeedUserId.MäklareId, },
                new Bostad { Utgångspris = 890000, Boarea = 59, Biarea = 11, Tomtarea = 540, Antalrum = 2, Månadsavgift = null, Driftkonstnad = 12000, Byggår = 2000, Gatuadress = "Tomtevägenvägen x", Ort ="Själevad", Objektbeskrivning = "Det går bara inte att fotografera det här huset...", KategoriId = 3, KommunId = 284, MäklareId = SeedUserId.MäklareId, }
            };
            return bostadList;
        }

        public static List<BostadBild> GetBildData()
        {
            var bildList = new List<BostadBild>
            {
                new BostadBild { BildURL = "images/SvartFritidshus.jpg", BostadId = 1 },
                new BostadBild { BildURL = "images/GråttFritidshus.jpg", BostadId = 2 },
                new BostadBild { BildURL = "images/GrönVilla.jpg", BostadId = 3 },
                new BostadBild { BildURL = "images/Lägenhet.jpg", BostadId = 4 },
                new BostadBild { BildURL = "images/Radhus.jpg", BostadId = 5 },
                new BostadBild { BildURL = "images/Bjästa.jpg", BostadId = 6 },
                new BostadBild { BildURL = "images/Själevad.jpg", BostadId = 7 },
                new BostadBild { BildURL = "images/Köpmanholmen.jpg", BostadId = 8 },
                new BostadBild { BildURL = "images/Domsjö.jpg", BostadId = 9 },
                new BostadBild { BildURL = "images/Lägenhet2.jpg", BostadId = 10 }
            };
            return bildList;
        }

        public static List<Kommun> GetKommunData()
        {
            var kommunList = new List<Kommun>
            {
                new Kommun { Namn = "Ale" },
                new Kommun { Namn = "Alingsås" },
                new Kommun { Namn = "Alvesta" },
                new Kommun { Namn = "Aneby" },
                new Kommun { Namn = "Arboga" },
                new Kommun { Namn = "Arjeplog" },
                new Kommun { Namn = "Arvidsjaur" },
                new Kommun { Namn = "Arvika" },
                new Kommun { Namn = "Askersund" },
                new Kommun { Namn = "Avesta" },
                new Kommun { Namn = "Bengtsfors" },
                new Kommun { Namn = "Berg" },
                new Kommun { Namn = "Bjurholm" },
                new Kommun { Namn = "Bjuv" },
                new Kommun { Namn = "Boden" },
                new Kommun { Namn = "Bollebygd" },
                new Kommun { Namn = "Bollnäs" },
                new Kommun { Namn = "Borgholm" },
                new Kommun { Namn = "Borlänge" },
                new Kommun { Namn = "Borås" },
                new Kommun { Namn = "Botkyrka" },
                new Kommun { Namn = "Boxholm" },
                new Kommun { Namn = "Bromölla" },
                new Kommun { Namn = "Bräcke" },
                new Kommun { Namn = "Burlöv" },
                new Kommun { Namn = "Båstad" },
                new Kommun { Namn = "Dals-Ed" },
                new Kommun { Namn = "Danderyd" },
                new Kommun { Namn = "Degerfors" },
                new Kommun { Namn = "Dorotea" },
                new Kommun { Namn = "Eda" },
                new Kommun { Namn = "Ekerö" },
                new Kommun { Namn = "Eksjö" },
                new Kommun { Namn = "Emmaboda" },
                new Kommun { Namn = "Enköping" },
                new Kommun { Namn = "Eskilstuna" },
                new Kommun { Namn = "Eslöv" },
                new Kommun { Namn = "Essunga" },
                new Kommun { Namn = "Fagersta" },
                new Kommun { Namn = "Falkenberg" },
                new Kommun { Namn = "Falköping" },
                new Kommun { Namn = "Falun" },
                new Kommun { Namn = "Filipstad" },
                new Kommun { Namn = "Finspång" },
                new Kommun { Namn = "Flen" },
                new Kommun { Namn = "Forshaga" },
                new Kommun { Namn = "Färgelanda" },
                new Kommun { Namn = "Gagnef" },
                new Kommun { Namn = "Gislaved" },
                new Kommun { Namn = "Gnesta" },
                new Kommun { Namn = "Gnosjö" },
                new Kommun { Namn = "Gotland" },
                new Kommun { Namn = "Grums" },
                new Kommun { Namn = "Grästorp" },
                new Kommun { Namn = "Gullspång" },
                new Kommun { Namn = "Gällivare" },
                new Kommun { Namn = "Gävle" },
                new Kommun { Namn = "Göteborg" },
                new Kommun { Namn = "Götene" },
                new Kommun { Namn = "Habo" },
                new Kommun { Namn = "Hagfors" },
                new Kommun { Namn = "Hallsberg" },
                new Kommun { Namn = "Hallstahammar" },
                new Kommun { Namn = "Halmstad" },
                new Kommun { Namn = "Hammarö" },
                new Kommun { Namn = "Haninge" },
                new Kommun { Namn = "Haparanda" },
                new Kommun { Namn = "Heby" },
                new Kommun { Namn = "Hedemora" },
                new Kommun { Namn = "Helsingborg" },
                new Kommun { Namn = "Herrljunga" },
                new Kommun { Namn = "Hjo" },
                new Kommun { Namn = "Hofors" },
                new Kommun { Namn = "Huddinge" },
                new Kommun { Namn = "Hudiksvall" },
                new Kommun { Namn = "Hultsfred" },
                new Kommun { Namn = "Hylte" },
                new Kommun { Namn = "Håbo" },
                new Kommun { Namn = "Hällefors" },
                new Kommun { Namn = "Härjedalen" },
                new Kommun { Namn = "Härnösand" },
                new Kommun { Namn = "Härryda" },
                new Kommun { Namn = "Hässleholm" },
                new Kommun { Namn = "Höganäs" },
                new Kommun { Namn = "Högsby" },
                new Kommun { Namn = "Hörby" },
                new Kommun { Namn = "Höör" },
                new Kommun { Namn = "Jokkmokk" },
                new Kommun { Namn = "Järfälla" },
                new Kommun { Namn = "Jönköping" },
                new Kommun { Namn = "Kalix" },
                new Kommun { Namn = "Kalmar" },
                new Kommun { Namn = "Karlsborg" },
                new Kommun { Namn = "Karlshamn" },
                new Kommun { Namn = "Karlskoga" },
                new Kommun { Namn = "Karlskrona" },
                new Kommun { Namn = "Karlstad" },
                new Kommun { Namn = "Katrineholm" },
                new Kommun { Namn = "Kil" },
                new Kommun { Namn = "Kinda" },
                new Kommun { Namn = "Kiruna" },
                new Kommun { Namn = "Klippan" },
                new Kommun { Namn = "Knivsta" },
                new Kommun { Namn = "Kramfors" },
                new Kommun { Namn = "Kristianstad" },
                new Kommun { Namn = "Kristinehamn" },
                new Kommun { Namn = "Krokom" },
                new Kommun { Namn = "Kumla" },
                new Kommun { Namn = "Kungsbacka" },
                new Kommun { Namn = "Kungsör" },
                new Kommun { Namn = "Kungälv" },
                new Kommun { Namn = "Kävlinge" },
                new Kommun { Namn = "Köping" },
                new Kommun { Namn = "Laholm" },
                new Kommun { Namn = "Landskrona" },
                new Kommun { Namn = "Laxå" },
                new Kommun { Namn = "Lekeberg" },
                new Kommun { Namn = "Leksand" },
                new Kommun { Namn = "Lerum" },
                new Kommun { Namn = "Lessebo" },
                new Kommun { Namn = "Lidingö" },
                new Kommun { Namn = "Lidköping" },
                new Kommun { Namn = "Lilla Edet" },
                new Kommun { Namn = "Lindesberg" },
                new Kommun { Namn = "Linköping" },
                new Kommun { Namn = "Ljungby" },
                new Kommun { Namn = "Ljusdal" },
                new Kommun { Namn = "Ljusnarsberg" },
                new Kommun { Namn = "Lomma" },
                new Kommun { Namn = "Ludvika" },
                new Kommun { Namn = "Luleå" },
                new Kommun { Namn = "Lund" },
                new Kommun { Namn = "Lycksele" },
                new Kommun { Namn = "Lysekil" },
                new Kommun { Namn = "Malmö" },
                new Kommun { Namn = "Malung-Sälen" },
                new Kommun { Namn = "Malå" },
                new Kommun { Namn = "Mariestad" },
                new Kommun { Namn = "Mark" },
                new Kommun { Namn = "Markaryd" },
                new Kommun { Namn = "Mellerud" },
                new Kommun { Namn = "Mjölby" },
                new Kommun { Namn = "Mora" },
                new Kommun { Namn = "Motala" },
                new Kommun { Namn = "Mullsjö" },
                new Kommun { Namn = "Munkedal" },
                new Kommun { Namn = "Munkfors" },
                new Kommun { Namn = "Mölndal" },
                new Kommun { Namn = "Mönsterås" },
                new Kommun { Namn = "Mörbylånga" },
                new Kommun { Namn = "Nacka" },
                new Kommun { Namn = "Nora" },
                new Kommun { Namn = "Norberg" },
                new Kommun { Namn = "Nordanstig" },
                new Kommun { Namn = "Nordmaling" },
                new Kommun { Namn = "Norrköping" },
                new Kommun { Namn = "Norrtälje" },
                new Kommun { Namn = "Norsjö" },
                new Kommun { Namn = "Nybro" },
                new Kommun { Namn = "Nykvarn" },
                new Kommun { Namn = "Nyköping" },
                new Kommun { Namn = "Nynäshamn" },
                new Kommun { Namn = "Nässjö" },
                new Kommun { Namn = "Ockelbo" },
                new Kommun { Namn = "Olofström" },
                new Kommun { Namn = "Orsa" },
                new Kommun { Namn = "Orust" },
                new Kommun { Namn = "Osby" },
                new Kommun { Namn = "Oskarshamn" },
                new Kommun { Namn = "Ovanåker" },
                new Kommun { Namn = "Oxelösund" },
                new Kommun { Namn = "Pajala" },
                new Kommun { Namn = "Partille" },
                new Kommun { Namn = "Perstorp" },
                new Kommun { Namn = "Piteå" },
                new Kommun { Namn = "Ragunda" },
                new Kommun { Namn = "Robertsfors" },
                new Kommun { Namn = "Ronneby" },
                new Kommun { Namn = "Rättvik" },
                new Kommun { Namn = "Sala" },
                new Kommun { Namn = "Salem" },
                new Kommun { Namn = "Sandviken" },
                new Kommun { Namn = "Sigtuna" },
                new Kommun { Namn = "Simrishamn" },
                new Kommun { Namn = "Sjöbo" },
                new Kommun { Namn = "Skara" },
                new Kommun { Namn = "Skellefteå" },
                new Kommun { Namn = "Skinnskatteberg" },
                new Kommun { Namn = "Skurup" },
                new Kommun { Namn = "Skövde" },
                new Kommun { Namn = "Smedjebacken" },
                new Kommun { Namn = "Sollefteå" },
                new Kommun { Namn = "Sollentuna" },
                new Kommun { Namn = "Solna" },
                new Kommun { Namn = "Sorsele" },
                new Kommun { Namn = "Sotenäs" },
                new Kommun { Namn = "Staffanstorp" },
                new Kommun { Namn = "Stenungsund" },
                new Kommun { Namn = "Stockholm" },
                new Kommun { Namn = "Storfors" },
                new Kommun { Namn = "Storuman" },
                new Kommun { Namn = "Strängnäs" },
                new Kommun { Namn = "Strömstad" },
                new Kommun { Namn = "Strömsund" },
                new Kommun { Namn = "Sundbyberg" },
                new Kommun { Namn = "Sundsvall" },
                new Kommun { Namn = "Sunne" },
                new Kommun { Namn = "Surahammar" },
                new Kommun { Namn = "Svalöv" },
                new Kommun { Namn = "Svedala" },
                new Kommun { Namn = "Svenljunga" },
                new Kommun { Namn = "Säffle" },
                new Kommun { Namn = "Säter" },
                new Kommun { Namn = "Sävsjö" },
                new Kommun { Namn = "Söderhamn" },
                new Kommun { Namn = "Söderköping" },
                new Kommun { Namn = "Södertälje" },
                new Kommun { Namn = "Sölvesborg" },
                new Kommun { Namn = "Tanum" },
                new Kommun { Namn = "Tibro" },
                new Kommun { Namn = "Tidaholm" },
                new Kommun { Namn = "Tierp" },
                new Kommun { Namn = "Timrå" },
                new Kommun { Namn = "Tingsryd" },
                new Kommun { Namn = "Tjörn" },
                new Kommun { Namn = "Tomelilla" },
                new Kommun { Namn = "Torsby" },
                new Kommun { Namn = "Torsås" },
                new Kommun { Namn = "Tranemo" },
                new Kommun { Namn = "Tranås" },
                new Kommun { Namn = "Trelleborg" },
                new Kommun { Namn = "Trollhättan" },
                new Kommun { Namn = "Trosa" },
                new Kommun { Namn = "Tyresö" },
                new Kommun { Namn = "Täby" },
                new Kommun { Namn = "Töreboda" },
                new Kommun { Namn = "Uddevalla" },
                new Kommun { Namn = "Ulricehamn" },
                new Kommun { Namn = "Umeå" },
                new Kommun { Namn = "Upplands-Bro" },
                new Kommun { Namn = "Upplands Väsby" },
                new Kommun { Namn = "Uppsala" },
                new Kommun { Namn = "Uppvidinge" },
                new Kommun { Namn = "Vadstena" },
                new Kommun { Namn = "Vaggeryd" },
                new Kommun { Namn = "Valdemarsvik" },
                new Kommun { Namn = "Vallentuna" },
                new Kommun { Namn = "Vansbro" },
                new Kommun { Namn = "Vara" },
                new Kommun { Namn = "Varberg" },
                new Kommun { Namn = "Vaxholm" },
                new Kommun { Namn = "Vellinge" },
                new Kommun { Namn = "Vetlanda" },
                new Kommun { Namn = "Vilhelmina" },
                new Kommun { Namn = "Vimmerby" },
                new Kommun { Namn = "Vindeln" },
                new Kommun { Namn = "Vingåker" },
                new Kommun { Namn = "Vårgårda" },
                new Kommun { Namn = "Vänersborg" },
                new Kommun { Namn = "Vännäs" },
                new Kommun { Namn = "Värmdö" },
                new Kommun { Namn = "Värnamo" },
                new Kommun { Namn = "Västervik" },
                new Kommun { Namn = "Västerås" },
                new Kommun { Namn = "Växjö" },
                new Kommun { Namn = "Ydre" },
                new Kommun { Namn = "Ystad" },
                new Kommun { Namn = "Åmål" },
                new Kommun { Namn = "Ånge" },
                new Kommun { Namn = "Åre" },
                new Kommun { Namn = "Årjäng" },
                new Kommun { Namn = "Åsele" },
                new Kommun { Namn = "Åstorp" },
                new Kommun { Namn = "Åtvidaberg" },
                new Kommun { Namn = "Älmhult" },
                new Kommun { Namn = "Älvdalen" },
                new Kommun { Namn = "Älvkarleby" },
                new Kommun { Namn = "Älvsbyn" },
                new Kommun { Namn = "Ängelholm" },
                new Kommun { Namn = "Öckerö" },
                new Kommun { Namn = "Ödeshög" },
                new Kommun { Namn = "Örebro" },
                new Kommun { Namn = "Örkelljunga" },
                new Kommun { Namn = "Örnsköldsvik" },
                new Kommun { Namn = "Östersund" },
                new Kommun { Namn = "Österåker" },
                new Kommun { Namn = "Östhammar" },
                new Kommun { Namn = "Östra Göinge" },
                new Kommun { Namn = "Överkalix" },
                new Kommun { Namn = "Övertorneå" }
            };

            return kommunList;
        }
    }
}
