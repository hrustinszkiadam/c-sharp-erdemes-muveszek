namespace muveszek
{
   class Muvesz
   {
      public string Nev { get; set; }
      public int KituntetesEve { get; set; }
      public string LegmagasabbKituntetes { get; set; }
      public List<string> Foglalkozasok { get; set; }

      public Muvesz(string nev, int kituntetesEve, List<string> foglalkozasok, string legmagasabbKituntetes = "nincs")
      {
         Nev = nev;
         KituntetesEve = kituntetesEve;
         LegmagasabbKituntetes = legmagasabbKituntetes;
         Foglalkozasok = foglalkozasok;
      }
   }
}