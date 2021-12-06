using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    class Program
    {
        

            public static int x = 0;
            public static List<int> resultat = new List<int>() { -1 };
            public static List<int> Count = new List<int>() { 0 };
            public static int m = 0;
            public static int l=0;
            public static int r = 1;
            public static int input1()
            {
                int tops = Convert.ToInt32(Console.ReadLine());
                return tops;
            }

            public static void input(int tops1, int[,] numbers)
            {
                Console.WriteLine("Если веса ребра нет, ввести 0 ");
                for (int i = 0; i < tops1; i++)
                {
                    for (int j = 0; j < tops1; j++)
                    {
                        Console.WriteLine("Введите вес ребра {0} → {1} ", i, j);
                        numbers[i, j] = Convert.ToInt32(Console.ReadLine());

                    }
                }

            }
            public static void search_min(int tops, int[,] numbers)
            {

                int t=0;
                int min = 2147483647;
            
                for (int y  = 0; y < tops; y++)//нахождение минимального в первой части
                {
                    for(int i=0;i<r;i++)
                    { 
                        if (y==Count[i])
                        {
                            numbers[m, y] = 0;

                        }
                    }
                }
            x = m;
            for (int y = 0; y < tops; y++)//нахождение минимального в первой части
            {
                if (min > numbers[x, y] && numbers[x, y] != 0)
                {
                    min = numbers[x, y];
                    m = y;
                    
                }

            }
            Count.Add(m);
            while (t < tops) { numbers[t, m] = min; t++; }
                resultat.Add(min);
                r = resultat.Count();

            }
        public static void search(int tops, int[,] numbers)
        {
            for(int j = 0; j < tops; j++)
            {
                if ((numbers[m,j]+resultat.Last())<=numbers[x,j] && numbers[m,j]!=0 && numbers[x, j] != 0)
                {
                    numbers[m, j] += resultat.Last();
                }
                else if((numbers[m, j] + resultat.Last()) > numbers[x, j] && numbers[m, j] != 0 && numbers[x, j] !=0)
                {
                    numbers[m, j] = numbers[x, j];
                }
                else if(numbers[x, j] == 0)
                {
                    numbers[m, j] += resultat.Last();
                }
                else if(numbers[m, j] == 0)
                {

                    while (numbers[l, j] == 0 && l >= 0)
                        if (numbers[l, j] == 0) l = m - 1;
                        else if (numbers[l, j] > 0) numbers[m, j] = numbers[l, j];
                        else break;
                }



            }
            
        }
        public static void  print(int tops)
        {
            int k = 1;
            for(int i=1;i<tops;i++)
            {
                Console.WriteLine("Кратчайший путь от {0} до {1}: {2}",k,i,resultat[i]);
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество вершин: (Что бы выйти из программы нажмите любую клавишу кроме цифр, enter и space) ");
                int top = input1();
                int[,] numbers = new int[top, top];
                input(top, numbers);
                search_min(top, numbers);
                search(top, numbers);
                search_min(top, numbers);
                search(top, numbers);
                search_min(top, numbers);
            print(top);
            Console.ReadKey();







            }
        }
    }

