using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErotteluPeli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Tämän pelin tekijä on: ");

            // Taulukkon tekija luonti ja tulostus foreach silmukalla
            string[] tekija = new string[] { "Mika ", "Ilmari ", "Tiihonen " };
            foreach (string i in tekija)
            {
                Console.Write(i);
            }
            Console.WriteLine();

            //Luo listan joka nimi on lista, satunnaslukujen luonti (random) ja kokonaisluku muuttujien asetus
            List<int> lista = new List<int>();
            Random random = new Random();
            int vaihdaYksi, vaihdaKaksi;

            //Lisätään listaan 6 lukua ja tarkistetaan ettei listaan tule dublikaatti numeroita
            while (lista.Count < 6)
            {
                int rnd = random.Next(0, 100);
                if (!lista.Contains(rnd))lista.Add(rnd);
            }

            //for (int i = 0; i < 6; i++)           // Tämä koodi lisää listaan dublikaatti numeroita!!!
            //{
            //    lista.Add(random.Next(0, 100));   // siksi koodi on kommentoi pois käytöstä !

            //}

            // Annetaan tekstille väriksi keltainen
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Vaihda numerot listassa niin että ne ovat nousevassa numerojärjestyksessä pienimmästä isoimpaan");
            
            Console.ResetColor();       // resetoi värit takaisin normaaliksi

            while (true)
            {
                // Tyhjennetään muuttujat joka silmukan alussa antamalla negatiivinen numero
                vaihdaYksi = -1;
                vaihdaKaksi = -1;
                
                KirjoitaLista(lista);   //Kutsutaan metodia/funktiota KirjoitaLista()

                //Tarkistaa että listassa ei ole numero vaihdaYksi ja pyytää käyttäjää antamaan sen
                while (lista.Contains(vaihdaYksi) ==  false)
                {
                    Console.WriteLine("Mikä on ensimmäinen numero jonka haluat vaihtaa?");
                    vaihdaYksi = Convert.ToInt32(Console.ReadLine());
                    
                }

                //Tarkistaa että listassa ei ole toinen numero vaihdaKaksi TAI numero2 == numero1 pyydetään numero2 uudelleen
                while (lista.Contains(vaihdaKaksi) ==  false || vaihdaKaksi == vaihdaYksi)
                {
                    Console.WriteLine("Mikä on toinen numero jonka haluat vaihtaa?");
                    vaihdaKaksi = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
                // Vaihdetaan numerot 1 ja 2 , iteroidaan lista
                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i] == vaihdaYksi)         // jos vaihdaYksi on listalla ja halutaan vaihtaa
                        lista[i] = vaihdaKaksi;         // Asetaan numero 1 vaihdaKaksi muutajan arvoksi
                    else if (lista[i] == vaihdaKaksi)   // numero jota katsomme on vaihdaKaksi
                        lista[i] = vaihdaYksi;          // annetaan vaihdaYksi muuttuajalle arvo numero 2
                }

                List<int> oikeaJarjestysLista = new List<int>(lista);       //Lista oikealle järjestykselle, vanhan listan numerot
                oikeaJarjestysLista.Sort();                                 //Sort laittaa numerot suuruusjärjestykseen

                if (lista.SequenceEqual(oikeaJarjestysLista) == true)       //SequenceEqual = JärjestysSama
                {
                    KirjoitaLista(lista);                                   //Kutsuu metodia ja tulostaa listan
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Oikea järjestys! Sinä Voitit !");
                    Console.Beep();
                    Console.ResetColor();

                    break;              //break lopettaa while silmukan
                }
            }
            Console.ReadLine();
        }

        // Luodaan metodi KirjoitaLista() joka tulostaa listan numerot
        static void KirjoitaLista(List<int> lista)
        {
            for (int i = 0; i < lista.Count; i++)       // Count = listan koko, voisi laittaa myös 6
            {
                Console.Write(lista[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}
