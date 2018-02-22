using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> l = new List<int> { 3, 1, 4, 1, 5, 2, 6, 5, 9 };

            foreach (var i in l)
            {
                if(i>=6)
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine();

            foreach (var i in l)
            {
                Console.WriteLine(i * i);
            }

            var newInts = new List<int>();
            foreach (var i in l)
            {
                if (i >= 6)
                {
                    newInts.Add(i);
                }
            }
            PrintInts(newInts);


            PrintInts(newInts.Where(x => x >= 6));

            PrintInts(newInts.Select(x => x * x));

            PrintInts(newInts.Where(x => x >= 6).Select(x => x * x));

            PrintInts(newInts.Where(x => x >= 6).Select(x => x * x).OrderByDescending(x => x));

            PrintInts(newInts.Where(x => x >= 6).Select(x => x * x).OrderByDescending(x => x).Take(3));


            //****************************************************

            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Name1",
                    Age = 5
                },
                 new Student
                {
                    Id = 5,
                    Name = "Name5",
                    Age = 5
                },
                  new Student
                {
                    Id = 3,
                    Name = "Name3",
                    Age = 3
                },
                   new Student
                {
                    Id = 4,
                    Name = "Name4",
                    Age = 4
                },
                    new Student
                {
                    Id = 2,
                    Name = "Name2",
                    Age = 2
                }
            };


            var names = students.Select(x => x.Name);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            


            Console.ReadKey(true);

        }

   


        public static void PrintInts(IEnumerable<int> l)
        {
            foreach (var i in l)
            {
                Console.WriteLine(i);
            }
        }



        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }




    }
}
