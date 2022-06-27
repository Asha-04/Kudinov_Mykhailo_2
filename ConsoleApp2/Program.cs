using System;
using System.Collections.Generic;

namespace lab2
{

    class photo
    {

        public string s;
        public photo()
        {
            Console.WriteLine("Constructor photo");


        }
    }

    class page
    {
        public int num;
        public page()
        {
            Console.WriteLine("Constructor page");

        }
    }

    class photoal
    {
        public Dictionary<int, string> mas = new Dictionary<int, string>();
        private string s;
        public photoal(page pa, photo ph, int n)
        {
            Console.WriteLine("Constructor album");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Add name");
                ph.s = Console.ReadLine();
                Console.WriteLine("Input page number");
                pa.num = int.Parse(Console.ReadLine());
                mas.Add(pa.num, ph.s);
            }
        }

 
        public override int GetHashCode()
        {
            Console.WriteLine("[Method GetHashCode]");

            int unitCode;
            if (s.Length < 10)
                unitCode = 1;
            else unitCode = 2;
            return unitCode;
        }
        public override bool Equals(object obj)
        {
            Console.WriteLine("[Method Equals]");

            if (obj == null)
                return false;
            photoal m = obj as photoal;
            if (m == null)
                return false;
            return s == m.s;
        }
        public void ChangeName()
        {
            Console.WriteLine("[Method change name]");

            string s;
            int n;
            Console.WriteLine("Input number:");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Input new name:");
            s = Console.ReadLine();
            if (n <= mas.Count)
                mas[n] = s;
            else
                Console.WriteLine("Incorrect page number");

        }
        public void AddPhoto()
        {
            Console.WriteLine("[Method add photo]");

            Console.WriteLine("Add new photo name:");
            s = Console.ReadLine();
            int n;
            Console.WriteLine("Input number:");
            n = int.Parse(Console.ReadLine());
            mas.Add(n, s);
        }
        public void ShowLenght()
        {
            Console.WriteLine("[Method Show lenght]");

            Console.WriteLine("There are " + mas.Count + " photo\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Input size of album");
            int n;
            n = Convert.ToInt32(Console.ReadLine());
            photo ph = new photo();
            page pa = new page();
            photoal pl = new photoal(pa, ph, n);
            pl.AddPhoto();
            pl.ChangeName();
            pl.ShowLenght();
            foreach (var person in pl.mas)
            {
                Console.Write($"{person.Key}: {person.Value}, ");
            }

        }
    }
}
