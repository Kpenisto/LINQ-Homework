using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new List<Course>
            {
                new Course {Id = 1, Name = "Calculus", Credits = 3 },
                new Course {Id = 2, Name = "Physics", Credits = 4 },
                new Course {Id = 3, Name = "Psychology", Credits = 1 },
                new Course {Id = 4, Name = "Underwater Basketweaving", Credits = 0 },
            };

            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Alice",
                    Age = 20,
                    EnrolledCourseId = 3
                },
                new Student
                {
                    Id = 2,
                    Name = "Bob",
                    Age = 23,
                    EnrolledCourseId = 1
                },
                new Student
                {
                    Id = 3,
                    Name = "Charlie",
                    Age = 19,
                    EnrolledCourseId = 2
                },
                new Student
                {
                    Id = 4,
                    Name = "Diane",
                    Age = 20,
                    EnrolledCourseId = 4
                },
                new Student
                {
                    Id = 5,
                    Name = "Elliot",
                    Age = 21,
                    EnrolledCourseId = 1
                },
                new Student
                {
                    Id = 6,
                    Name = "Frank",
                    Age = 18,
                    EnrolledCourseId = 3
                },
            };

            /*************************************************************
             * YOUR CODE GOES BELOW HERE                                 *
             *************************************************************/

            //1. Use LINQ to get just the names of all the students.Iterate over the result to print the names.
            var names = students.Select(x => x.Name);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            //2. Save the result of the query from #1 into a variable. After saving the LINQ query, but before iterating to print names, add a new student to the list. Observe the result.
            names = students.Select(x => x.Name);
            students.Add(new Student { Id = 7, Name = "Kyle", Age = 24, EnrolledCourseId = 5 });
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            //3. Add “.ToList()” to the end of the LINQ query from #2. Now observe the result.
            names = students.Select(x => x.Name).ToList();
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();


            //4. Use LINQ to get all the students enrolled in Course ID 3. Print the count of the result(Count()).
            var a = students.Count(x => x.EnrolledCourseId == 3);
            
            Console.WriteLine(a);
            Console.WriteLine();

            //5. Use LINQ to get JUST the NAMES of all the students who are at least 21 years old.Iterate over the result to print the names.
            var b = students.Where(x => x.Age >= 21).Select( x => x.Name);
            foreach (var Names in b)
            {
                Console.WriteLine(Names);
            }

            Console.WriteLine();

            //6. Print the names of all the courses worth at least 2 credits.
            var c = courses.Where(x => x.Credits >= 2).Select(x => x.Name);
            foreach (var Name in c)
            {
                Console.WriteLine(Name);
            }

            Console.WriteLine();

            //7. Print the average age of the students.
            var d = students.Average(x => x.Age);
            Console.WriteLine(d);
            Console.WriteLine();

            //8. Print the average age of the students enrolled in Course ID 1.
            var e = students.Where(x => x.EnrolledCourseId == 1).Average(x => x.Age);
            Console.WriteLine(e);
            Console.WriteLine();

            //9. Print the name of the student with the highest age.
            var f = students.Select(x => x.Name).Max();
            Console.WriteLine(f);

            Console.WriteLine();

            //10. Print the names of the students with the 3 highest ages, in descending order (with the highest age first).
            var g = students.OrderByDescending(x => x.Age).Select(x => x.Name).Take(3);
            foreach (var Name in g)
            {
                Console.WriteLine(Name);
            }

            Console.WriteLine();
            //11. Use LINQ to create a collection of EnrolledStudent objects. (Note that EnrolledStudent has a constructor that makes this somewhat easier).
            var query =
                students.Join(courses,
                                s => s.EnrolledCourseId,
                                x => x.Id,
                                (s, x) => new EnrolledStudent(s, x));

            foreach(var obj in query)
            {
                Console.WriteLine(
                "{0} - {1}",
                obj.StudentName,
                obj.CourseName);
            }
                                


            /*************************************************************
             * YOUR CODE GOES ABOVE HERE                                 *
             *************************************************************/

            Console.ReadKey(true);
        }
    }

    class Student
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public int EnrolledCourseId { get; set; }
    }

    class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
    }

    class EnrolledStudent
    {
        public EnrolledStudent(Student s, Course c)
        {
            StudentId = s.Id;
            StudentAge = s.Age;
            StudentName = s.Name;
            CourseName = c.Name;
            Credits = c.Credits;
        }

        public int StudentId { get; set; }
        public int StudentAge { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
    }

}







