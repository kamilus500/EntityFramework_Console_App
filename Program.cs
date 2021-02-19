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

        #region Main
        static void Main()
        {
            Console.Clear();

            Console.WriteLine("###############################");
            Console.WriteLine(" Entity Framework  Application ");
            Console.WriteLine("###############################");

            Console.WriteLine();
            Console.WriteLine("Lista");

            GetAllData();

            Console.WriteLine();
            Console.WriteLine("Wybierz działanie programu");
            Console.WriteLine("1) Dodanie nowego kontaktu");
            Console.WriteLine("2) Usunięcię wybranego kontaktu");
            Console.WriteLine("3) Modifykowanie wybranego kontaktu");

            int action = Convert.ToInt32(Console.ReadLine());

            switch(action)
            {
                case 1:
                    int id = GetLastID();
                    AddNewKontakt(id);
                    break;

                case 2:
                    RemoveKontakt(GetLastID());
                    break;
                case 3:
                    Console.Write("Podaj imie do zmiany: ");
                    string imie = Console.ReadLine();
                    Console.Write("Podaj osobe(id) do zmiany: ");
                    int id2 = Convert.ToInt32(Console.ReadLine());
                    
                    UpdateKontakt(id2,imie);
                    break;
            }
        }
        #endregion

        #region Functions
        public static void GetAllData()
        {
            KontaktyEntities db = new KontaktyEntities();
            var lista = db.Table.ToList();

            foreach (var osoba in lista)
            {
                Console.WriteLine("ID: {0} Imie: {1} Nazwisko: {2}",osoba.ID,osoba.Imie,osoba.Nazwisko);
            }
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

            Main();
        }

        public static void RemoveKontakt(int _id)
        {
            KontaktyEntities db = new KontaktyEntities();
            Table osoba = db.Table.Single(x => x.ID == _id);
            db.Table.Remove(osoba);
            db.SaveChanges();

            Main();
        }

        public static void UpdateKontakt(int _id,string _imie)
        {
            KontaktyEntities db = new KontaktyEntities();
            Table table = db.Table.Single(x => x.ID == _id);
            table.Imie = _imie;
            db.SaveChanges();

            Main();
        }
        #endregion

        #region Helpers
        public static int GetLastID()
        {
            KontaktyEntities db = new KontaktyEntities();
            int ilosc = db.Table.Count();

            return ilosc;
        }
        #endregion
    }
}
