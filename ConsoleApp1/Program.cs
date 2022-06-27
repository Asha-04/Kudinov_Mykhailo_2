using System;
using System.Collections.Generic;

namespace lab2_2
{


    class tarif1
    {
        public int cost, gigabyte, minutes;
        public string name;

        public tarif1(int cost, int gigabyte, int minutes, string name)
        {
            this.minutes = minutes;
            this.gigabyte = gigabyte;
            this.cost = cost;
            this.name = name;
        }
        public tarif1()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.Write("Цена = ");
            cost = int.Parse(Console.ReadLine());

            Console.Write("Кол-во гб = ");
            gigabyte = int.Parse(Console.ReadLine());

            Console.Write("Кол-во минут = ");
            minutes = int.Parse(Console.ReadLine());

            Console.Write("Название = ");
            name = Console.ReadLine();

        }


    }
    class tarif2 : tarif1
    {
        public int roum;
        public tarif2()
        {
            Console.WriteLine("[Дополнительно]");
            Console.Write("Кол-во минут в роуминге = ");
            roum = Convert.ToInt32(Console.ReadLine());
 
        }
    }
    class tarif3 : tarif1
    {
        public int sms;
        public tarif3()
        {
            Console.WriteLine("[Дополнительно]");
            Console.Write("Кол-во смс");
            sms = Convert.ToInt32(Console.ReadLine());

        }

    }

    class Mob
    {
        static public void Swap(tarif1 t1, tarif1 t2)
        {
            tarif1 tmp = new tarif1(t1.cost, t1.gigabyte, t1.minutes, t1.name);
            t1.cost = t2.cost;
            t1.gigabyte = t2.gigabyte;
            t1.minutes = t2.minutes;
            t1.name = t2.name;

            t2.cost = tmp.cost;
            t2.gigabyte = tmp.gigabyte;
            t2.minutes = tmp.minutes;
            t2.name = tmp.name;
        }
        public List<tarif1> lt = new List<tarif1>();
        public Mob(int n1, int n2, int n3)
        {
            for (int i = 0; i < n1; i++)
            {
                tarif1 t1 = new tarif1();
                lt.Add(t1);
            }
            for (int i = 0; i < n2; i++)
            {
                tarif2 t1 = new tarif2();
                lt.Add(t1);
            }
            for (int i = 0; i < n3; i++)
            {
                tarif3 t1 = new tarif3();
                lt.Add(t1);
            }
        }

        public void Search(int costl, int costr, int gbl)
        {
            for (int i = 0; i < lt.Count; i++)
            {
                if (lt[i].cost <= costr &&
                    lt[i].cost >= costl &&
                    lt[i].gigabyte >= gbl)
                    Console.WriteLine("Вы можете использовать " + lt[i].name + ", это стоит " + lt[i].cost + " и имеет " + lt[i].gigabyte + " GB");
            }

        }


        public void Calculate()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(lt.Count + " пользователя");
            Console.Write("------------------------------------------------------------------------------------------------------------------------");
        }

        public void Sort()
        {
            for (int i = 1; i < lt.Count; i++)
            {
                for (int j = 0; j < lt.Count - i; j++)
                {
                    if (lt[j].cost < lt[j + 1].cost)
                    {
                        Mob.Swap(lt[j], lt[j + 1]);
                    }
                }
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("[Sorted array]");

            for (int i = lt.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(lt[i].name + " - " + lt[i].cost);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n1, n2, n3;
            Console.Write("Введите кол-во 1 мобильного тарифа: ");
            n1 = int.Parse(Console.ReadLine());
            Console.Write("Введите кол-во 2 мобильного тарифа: ");
            n2 = int.Parse(Console.ReadLine());
            Console.Write("Введите кол-во 3 мобильного тарифа: ");
            n3 = int.Parse(Console.ReadLine());
            Mob t = new Mob(n1, n2, n3);
            t.Sort();
            Console.Write("Введите минимальную цену: ");
            n3 = int.Parse(Console.ReadLine());
            Console.Write("Введите максимальную цену: ");
            n2 = int.Parse(Console.ReadLine());
            Console.Write("Введите максимальное кол-во гб: ");
            n1 = int.Parse(Console.ReadLine());

            t.Search(n3, n2, n1);
            t.Calculate();
        }
    }
}
