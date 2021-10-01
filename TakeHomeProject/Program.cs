using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TakeHomeProject
{
    class Program
    {
        #region Lista feltöltése

        /// <summary>
        /// Lista feltöltése és döntési pont ahol ki lehet választani, hogy milyen típusú legyen és mivel töltsük fel a listát.
        /// </summary>
        /// <returns>Egy feltöltött listával tér vissza.</returns>
        static ArrayList FillAndList()
        {
            ArrayList result = new ArrayList();
            for (int i = 0; i < 7; i++)
            {
                Console.Clear();
                Console.WriteLine("Válasszon típust:");
                Console.WriteLine("1) szám");
                Console.WriteLine("2) szöveg");
                Console.WriteLine("3) dátum");
                Console.Write("\r\nAdja meg a számát: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Számot választott.");
                        Console.Write("\nAdjon meg egy számot: ");
                        int number = 0;

                        while (!int.TryParse(Console.ReadLine(), out number) || !IsInRange(number))
                        {
                            Console.WriteLine("Hibás szám adjon meg egy számot 10 ls 9999 között");
                            Console.Write("Adjon meg újra: ");
                        }
                        result.Add(number);


                        break;
                    case "2":
                        Console.WriteLine("Szöveget választott.");
                        Console.WriteLine("\nAdjon meg egy szót: ");
                        string text = "";

                        while (!IsLengthInRange(text = Console.ReadLine()))
                        {
                            Console.WriteLine("Hibás adat, adjon meg egy szót 5 és 45 karakterhossz között van");
                        }
                        result.Add(text);


                        break;
                    case "3":
                        Console.WriteLine("Dátumot választott.");
                        Console.WriteLine("Adjon meg 7 dátumot ami YYYYMMDD formátumú és 2000.01.01. utáni");
                        DateTime dateTime;

                        while (!DateTime.TryParseExact(Console.ReadLine(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dateTime) || !IsDateAfter(dateTime))
                        {
                            Console.WriteLine("Hibás adat, adjon meg 7 dátumot ami YYYYMMDD formátumú és 2000.01.01. utáni");
                        }
                        result.Add(dateTime);

                        break;
                    default:
                        Console.WriteLine("Kérem a megadott számok közül válasszon!");
                        break;
                }
            }
            return result;
        }

        #endregion

        #region Liste feltöltéséhez szükséges segéd metódusok
        /// <summary>
        /// Megvizsgálja, hogy a paraméterben kapott szám az megfelel-e a feltételnek.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True vagy False értékkel tér vissza.</returns>
        static Boolean IsInRange(int data)
        {
            return data > 10 && data < 9999;
        }

        /// <summary>
        /// Megvizsgálja, hogy a paraméterben kapott string az megfelel-e a feltételnek.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True vagy False értékkel tér vissza.</returns>
        static Boolean IsLengthInRange(string data)
        {
            return data.Length > 5 && data.Length < 45;
        }

        /// <summary>
        /// Megvizsgálja, hogy a paraméterben kapott dátum az megfelel-e a feltételnek.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>True vagy False értékkel tér vissza.</returns>
        static Boolean IsDateAfter(DateTime date)
        {
            return date > new DateTime(2000, 01, 01);
        }

        #endregion

        #region Lista adatok ellenörzéséhez szükséges segéd metódusok

        /// <summary>
        /// Megvizsgálja a paraméterben kapott számot, hogy az prím-e vagy sem.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>True vagy False értékkel tér vissza.</returns>
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        /// <summary>
        /// Feldolgozza és megformázza az adott adatot és kiírja a képernyőre
        /// </summary>
        /// <param name="number"></param>
        static void PrintNumber(int number)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(number);
            sb.Append(" - ");
            sb.Append(number % 2 == 0 ? number / 2 : number * 2);
            sb.Append(IsPrime(number) ? " !prímszám" : "");
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Feldolgozza és megformázza az adott adatot és kiírja a képernyőre
        /// </summary>
        /// <param name="text"></param>
        static void PrintText(string text)
        {
            string motto = "Making an impact that matters –Deloitte";
            StringBuilder sb = new StringBuilder(text);
            sb.Append(" - ");
            sb.Append(motto.Substring(0, text.Length > motto.Length ? motto.Length : text.Length));
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Feldolgozza és megformázza az adott adatot és kiírja a képernyőre
        /// </summary>
        /// <param name="date"></param>
        static void PrintDate(DateTime date)
        {
            DateTime referenceDate = new DateTime(2002, 02, 20);

            StringBuilder sb = new StringBuilder(date.ToString("yyyy.MM.dd."));
            sb.Append(" - ");
            sb.Append(Math.Abs((date - referenceDate).Days));
            sb.Append(DateTime.IsLeapYear(date.Year) ? " !szökőév" : "");
            Console.WriteLine(sb.ToString());
        }

        #endregion

        #region Lista kiíratása

        /// <summary>
        /// Paraméterben kapott adatról eldönti, hogy milyen típusú lista és aszerint írja ki az adatokat
        /// </summary>
        /// <param name="list"></param>
        static void ListingData(ArrayList list)
        {
            List<int> numberList = new List<int>();
            List<string> textList = new List<string>();
            List<DateTime> dateList = new List<DateTime>();

            for (int i = 0; i < 7; i++)
            {
                if (list[i] is int)
                {
                    numberList.Add((int)(list[i]));
                }
                else if (list[i] is string)
                {
                    textList.Add((string)list[i]);
                }
                else if (list[i] is DateTime)
                {
                    dateList.Add((DateTime)list[i]);
                }
            }

            Console.Clear();

            Console.WriteLine("Szám ({0})", numberList.Count);
            foreach (int number in numberList)
            {
                PrintNumber(number);
            }
            Console.WriteLine();

            Console.WriteLine("Szöveg ({0})", textList.Count);
            foreach (string text in textList)
            {
                PrintText(text);
            }
            Console.WriteLine();

            Console.WriteLine("Dátum ({0})", dateList.Count);
            foreach (DateTime date in dateList)
            {
                PrintDate(date);
            }
        }

        #endregion

        static void Main(string[] args)
        {
            ArrayList list = FillAndList();
            ListingData(list);

            Console.ReadLine();
        }
    }
}
