using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace muveszek
{
   class Program
   {
      static void Main(string[] args)
      {
         List<Muvesz> muveszek = ReadFiles();

         Masodik(muveszek);
         Harmadik(muveszek);
         Negyedik(muveszek);
         Otodik(muveszek);
         Hatodik(muveszek);
         Hetedik(muveszek);

         Console.ReadKey();
      }

      static List<Muvesz> ReadFiles()
      {
         List<string> szemelyek = File.ReadAllLines(@"szemely.txt").ToList();
         List<string> foglalkozasok = File.ReadAllLines(@"foglalkozas.txt").ToList();

         List<Muvesz> muveszek = new List<Muvesz>();

         for (int i = 0; i < szemelyek.Count; i++)
         {
            string[] szemelyAdatok = szemelyek[i].Split(',');
            List<string> foglalkozasokList = foglalkozasok[i].Split(',').ToList();
            foglalkozasokList.RemoveAt(0);

            muveszek.Add(new Muvesz(szemelyAdatok[0], int.Parse(szemelyAdatok[1]), foglalkozasokList, szemelyAdatok[2]));
         }

         return muveszek;
      }

      static void Masodik(List<Muvesz> muveszek)
      {
         Console.WriteLine("2. feladat: 2013-ban kitüntetettek:");
         foreach (var muvesz in muveszek)
         {
            if (muvesz.KituntetesEve == 2013)
            {
               Console.WriteLine(muvesz.Nev);
            }
         }
         Console.WriteLine();
      }

      static void Harmadik(List<Muvesz> muveszek)
      {
         Console.WriteLine("3. feladat: Balettel foglalkozó díjazottak:");
         foreach (var muvesz in muveszek)
         {
            foreach (var foglalkozas in muvesz.Foglalkozasok)
            {
               if (foglalkozas.ToLower().Contains("balett"))
               {
                  Console.WriteLine($"{muvesz.Nev} - ({foglalkozas})");
                  break;
               }
            }
         }
         Console.WriteLine();
      }

      static void Negyedik(List<Muvesz> muveszek)
      {
         Dictionary<int, int> kituntetesek = new Dictionary<int, int>();

         foreach (var muvesz in muveszek)
         {
            if (kituntetesek.ContainsKey(muvesz.KituntetesEve))
               kituntetesek[muvesz.KituntetesEve]++;
            else
               kituntetesek.Add(muvesz.KituntetesEve, 1);
         }

         int max = kituntetesek.Values.Max();
         int ev = kituntetesek.FirstOrDefault(x => x.Value == max).Key;

         Console.WriteLine($"4. feladat: {ev}-ban volt a legtöbb díjazott - {max} fő");
         Console.WriteLine();
      }

      static void Otodik(List<Muvesz> muveszek)
      {
         Dictionary<string, int> foglalkozasok = new Dictionary<string, int>();

         foreach (var muvesz in muveszek)
         {
            foreach (var foglalkozas in muvesz.Foglalkozasok)
            {
               if (foglalkozasok.ContainsKey(foglalkozas))
                  foglalkozasok[foglalkozas]++;
               else
                  foglalkozasok.Add(foglalkozas, 1);
            }
         }

         Console.WriteLine("5. feladat: Foglalkozások statisztikája:");
         foreach (var foglalkozas in foglalkozasok)
         {
            Console.WriteLine($"{foglalkozas.Key} - {foglalkozas.Value} fő");
         }
         Console.WriteLine();
      }

      static void Hatodik(List<Muvesz> muveszek)
      {
         List<string> PittiFoglalkozasok = new List<string>();

         foreach (var muvesz in muveszek)
         {
            if (muvesz.Nev == "Pitti Katalin")
            {
               PittiFoglalkozasok = muvesz.Foglalkozasok;
               break;
            }
         }

         List<Muvesz> PittiKollegak = new List<Muvesz>();

         foreach (var muvesz in muveszek)
         {
            foreach (var foglalkozas in muvesz.Foglalkozasok)
            {
               if (PittiFoglalkozasok.Contains(foglalkozas))
               {
                  PittiKollegak.Add(muvesz);
                  break;
               }
            }
         }

         Console.WriteLine("6. feladat: Pitti Katalin és kollegái:");
         foreach (var muvesz in PittiKollegak)
         {
            Console.WriteLine($"{muvesz.Nev} - {muvesz.KituntetesEve}");
         }

         Console.WriteLine();
      }

      static void Hetedik(List<Muvesz> muveszek)
      {
         List<string> grafikusFoglalkozasok = new List<string>();

         foreach (var muvesz in muveszek)
         {
            if (muvesz.Foglalkozasok.Contains("grafikus"))
            {
               foreach (var foglalkozas in muvesz.Foglalkozasok)
               {
                  if (foglalkozas != "grafikus" && !grafikusFoglalkozasok.Contains(foglalkozas))
                     grafikusFoglalkozasok.Add(foglalkozas);
               }
            }
         }

         Console.WriteLine("7. feladat: Grafikusok más foglalkozásai:");
         foreach (var foglalkozas in grafikusFoglalkozasok)
         {
            Console.WriteLine(foglalkozas);
         }
      }
   }
}