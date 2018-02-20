using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLambdaHomework
{
    class Program
    {

        #region StaticFields
        private static List<int> _integers = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 9 };

        private static List<string> _strings = new List<string> {
            "Hello",
            "World!",
            "I",
            "am",
            "a",
            "list",
            "of",
            "strings",


        };

        #endregion

        #region StaticMethods
        static int Aggregate(Func<int, int, int> f, List<int> list)
        {
            int result = list[0];
            for (int i = 1; i < list.Count; ++i)
            {
                result = f(result, list[i]);
            }

            return result;
        }

        static IEnumerable<int> Select(Func<int, int> f, IEnumerable<int> list)
        {
            List<int> result = new List<int>();
            foreach (int val in list)
            {
                result.Add(f(val));
            }
            return result;
        }

        static void ForEach<T>(Action<T> f, IEnumerable<T> list)
        {
            foreach (T val in list)
            {
                f(val);
            }
        }

        #endregion
        public static int Sum(int a, int b)
        {

            return a + b;
        }


        public static int Multiply(int a, int b)
        {

            return a * b;
        }

        public static int MakeDouble(int a)
        {
            return a * 2;
        }

        public static int Square(int a)
        {
            return a * a;
        }

        static void Main(string[] args)
        {

            /////hdhdhdhdhhdhdhdhdhd

            int c = Aggregate(Sum, _integers);
            int z = Aggregate(Multiply, _integers);
            int d = Aggregate((a, b) => a + b, _integers);
            int e = Aggregate((x, y) => x * y, _integers);
            List<int> f = (List<int>)Select(MakeDouble, _integers);
            List<int> g = (List<int>)Select(Square, _integers);

            Console.WriteLine("1a: " + c);
            Console.WriteLine("\n1b: " + z);
            Console.WriteLine("\n1c: " + d);
            Console.WriteLine("\n1d: " + e);

            Console.WriteLine("\n2a: ");

            foreach (int num in Select(x => 2 * x, _integers))
            {
                Console.Write(num + "");
            }


            Console.WriteLine("\n2b: ");

            foreach (int num in Select(Square, _integers))
            {
                Console.Write(num + "");
            }

            Console.WriteLine("\n2c: ");

            foreach (int num in Select(x => x * 2, _integers))
            {
                Console.Write(num + "");
            }

            Console.WriteLine("\n2d: ");

            foreach (int num in Select(x => x * x, _integers))
            {
                Console.Write(num + "");
            }

            Console.WriteLine("\n3a: ");
            ForEach<int>((x) => Console.Write(x), _integers);

            Console.WriteLine("\n3b: ");
            ForEach<string>((x) => Console.Write(x), _strings);

            Console.ReadLine();
            //test


        }
    }
}
