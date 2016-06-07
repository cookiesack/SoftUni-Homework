using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_02___Implement_BiDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var distances = new BiDictionary<string, string, int>();
            distances.Add("Sofia", "Varna", 443);
            distances.Add("Sofia", "Varna", 468);
            distances.Add("Sofia", "Varna", 490);
            distances.Add("Sofia", "Plovdiv", 145);
            distances.Add("Sofia", "Bourgas", 383);
            distances.Add("Plovdiv", "Bourgas", 253);
            distances.Add("Plovdiv", "Bourgas", 292);
            var distancesFromSofia = distances.FindByKey1("Sofia"); // [443, 468, 490, 145, 383]
            foreach (var distance in distancesFromSofia)
            {
                Console.Write(distance + " ");
            }
            Console.WriteLine();
            var distancesToBourgas = distances.FindByKey2("Bourgas"); // [383, 253, 292]
            foreach (var distance in distancesToBourgas)
            {
                Console.Write(distance + " ");
            }
            Console.WriteLine();
            var distancesPlovdivBourgas = distances.Find("Plovdiv", "Bourgas"); // [253, 292]
            foreach (var distance in distancesPlovdivBourgas)
            {
                Console.Write(distance + " ");
            }
            Console.WriteLine();
            var distancesRousseVarna = distances.Find("Rousse", "Varna"); // []
            foreach (var distance in distancesRousseVarna)
            {
                Console.Write(distance + " ");
            }
            Console.WriteLine();
            var distancesSofiaVarna = distances.Find("Sofia", "Varna"); // [443, 468, 490]
            foreach (var distance in distancesSofiaVarna)
            {
                Console.Write(distance + " ");
            }
            Console.WriteLine();
            Console.WriteLine(distances.Remove("Sofia", "Varna")); // true
            var distancesFromSofiaAgain = distances.FindByKey1("Sofia"); // [145, 383]
            foreach (var distance in distancesFromSofiaAgain)
            {
                Console.Write(distance + " ");
            }
            Console.WriteLine();
            var distancesToVarna = distances.FindByKey2("Varna"); // []
            foreach (var distance in distancesToVarna)
            {
                Console.Write(distance + " ");
            }
            Console.WriteLine();
            var distancesSofiaVarnaAgain = distances.Find("Sofia", "Varna"); // []
            foreach (var distance in distancesSofiaVarnaAgain)
            {
                Console.Write(distance + " ");
            }
            Console.WriteLine();
        }
    }
}
