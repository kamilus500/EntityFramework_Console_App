using Console_EF_application.BAZA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_EF_application
{
    class Program
    {
        static void Main()
        {
            Console.Clear();

            Console.WriteLine("###############################");
            Console.WriteLine(" Entity Framework  Application ");
            Console.WriteLine("###############################");

            Console.WriteLine();
            Console.WriteLine("Wybierz działanie programu");
            Console.WriteLine("1) Wyświel wszystkie kontakty");
            Console.WriteLine("2) Dodanie nowego kontaktu");

            int action = Convert.ToInt32(Console.ReadLine());

            switch(action)
            {
                case 1:
                    GetAllData();
                    break;
                case 2:
                    int id = GetLastID();
                    AddNewKontakt(id);
                    break;
            }
        }

        public static void GetAllData()
        {
            KontaktyEntities db = new KontaktyEntities();
            var lista = db.Table.ToList();

            foreach (var osoba in lista)
            {
                Console.WriteLine(" ID: {0} \n Imie: {1} \n Nazwisko: {2} \n",osoba.ID,osoba.Imie,osoba.Nazwisko);
            }

            Console.ReadKey();
            Main();
        }

        public static void AddNewKontakt(int _id)
        {
            KontaktyEntities db = new KontaktyEntities();
            Console.Write("Podaj imie: ");
            string _imie = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            string _nazwisko = Console.ReadLine();
            Table result = new Table() {ID = _id ,Imie = _imie, Nazwisko = _nazwisko };

            db.Table.Add(result);
            db.SaveChanges();

            Console.ReadKey();

            Main();
        }

        public static int GetLastID()
        {
            KontaktyEntities db = new KontaktyEntities();
            int ilosc = db.Table.Count();

            return ilosc;
        }
    }
}
