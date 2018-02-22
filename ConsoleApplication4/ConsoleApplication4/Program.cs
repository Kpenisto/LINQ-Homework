using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication4.Models;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            //display name
            using (var db = new EfExampleEntities())
            {
                var students = db.Students.Select(x => x.Name);
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }


            Console.WriteLine();
            //display course
            using (var db = new EfExampleEntities())
            {
                var students = db.Students;
                foreach (var student in students)
                {
                    Console.WriteLine(student.Name + ":");
                    foreach ( var course in student.Courses)
                    {
                        Console.WriteLine(course.Name);
                    }
                    
                }
            }

            //display teacher for student
            using (var db = new EfExampleEntities())
            {
                var students = db.Students;
                foreach (var student in students)
                {
                    Console.WriteLine(student.Name + ":");
                    foreach (var course in student.Courses)
                    {
                        Console.WriteLine(course.Teacher.Staff.Name);
                    }

                }
            }

            //display staff thats not teacher
            using (var db = new EfExampleEntities())
            {
                var staff = db.Staff.Where(s => s.Teacher == null);
                foreach ( var staffmember in staff)
                {
                    Console.WriteLine(staffmember.Name);
                }
            }


            //names of students in hist101

            using (var db = new EfExampleEntities())
            {

                foreach ( var student in db.Students.Where(s => s.Courses.Any(c => c.Name == "math101")))
                {
                    Console.WriteLine(student.Name);
                }
            }

            //mikes (8) ass got fired and barbra gets his classes barbs id = 7

            using (var db = new EfExampleEntities())
            {
                var barbara = db.Teachers.Find(7);
                var courses = db.Teachers.Find(8).Courses.ToList();

                foreach (var course in courses)
                {
                    course.Teacher = barbara;
                    db.Entry(course).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }

            Console.ReadKey(true);
        }
    }
}
