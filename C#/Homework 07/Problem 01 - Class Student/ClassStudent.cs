using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_01___Class_Student;

class ClassStudent
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();
        students.Add(new Student("Ivan", "Petrov", 15, "2180146", "+3592862436", "ivan4oyYy@gmail.com", new int[] { 2, 4, 4, 3, 2 }, 4, "Group4"));
        students.Add(new Student("Mariika", "Gosheva", 18, "2176108", "0878666666", "mariika97@abv.bg", new int[] { 5, 6, 2, 6 }, 2, "Group2"));
        students.Add(new Student("Stancho", "Iliev", 19, "2180141", "+3592862887", "stancho@mail.bg", new int[] { 5, 2, 2, 3, 2 }, 4, "Group4"));


        //Problem 02
        //var group2 = students.Where(student => student.GroupNumber == 2).OrderBy(student => student.FirstName);
        var group2 = from student in students
                     where student.GroupNumber == 2
                     orderby student.FirstName
                     select student;
        foreach (var student in group2)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }
        Console.WriteLine();

        //Problem 03
        //var firstBeforeLastName = students.Where(student => student.FirstName.CompareTo(student.LastName) == -1);
        var firstBeforeLastName = from student in students
                                  where student.FirstName.CompareTo(student.LastName) == -1
                                  select student;
        foreach (var student in firstBeforeLastName)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }
        Console.WriteLine();

        //Problem 04
        //var ageBetween18And24 = students.Where(student => student.Age >= 18 && student.Age <= 24).Select(student => new { FirstName = student.FirstName, LastName = student.LastName, Age = student.Age });
        var ageBetween18And24 = from student in students
                                where student.Age >= 18 && student.Age <= 24
                                select new { FirstName = student.FirstName, LastName = student.LastName, Age = student.Age };
        foreach (var student in ageBetween18And24)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName + ", Age: " + student.Age);
        }
        Console.WriteLine();

        //Problem 05
        var orderedByNamesLambda = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);
        var orderedByNamesQuery = from student in students
                                  orderby student.FirstName, student.LastName
                                  select student;
        foreach (var student in orderedByNamesLambda)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName + ", Age: " + student.Age);
        }
        Console.WriteLine();
        foreach (var student in orderedByNamesQuery)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName + ", Age: " + student.Age);
        }
        Console.WriteLine();

        //Problem 06
        var abv = from student in students
                  where student.Email.Substring(student.Email.Length - 7, 7) == "@abv.bg"
                  select student;
        foreach (var student in abv)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName + ", Age: " + student.Age + ", Email: " + student.Email);
        }
        Console.WriteLine();

        //Problem 07
        var phonesInSofia = from student in students
                            where student.Phone.Substring(0, 2) == "02" || student.Phone.Substring(0, 5) == "+3592" || student.Phone.Substring(0, 6) == "+359 2"
                            select student;
        foreach (var student in phonesInSofia)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName + ", Age: " + student.Age + ", Email: " + student.Email + ", Phone: " + student.Phone);
        }
        Console.WriteLine();

        //Problem 08
        var excellentStudents = from student in students
                                where student.Marks.Contains(6) == true
                                select new { Fullname = student.FirstName + " " + student.LastName, Marks = student.Marks };
        foreach (var student in excellentStudents)
        {
            Console.WriteLine(student.Fullname);
            foreach (var mark in student.Marks)
            {
                Console.Write(mark + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        //Problem 09
        var weakStudents = from student in students
                           where student.Marks.countWeakMarks() == 2
                           select new { Fullname = student.FirstName + " " + student.LastName, Marks = student.Marks };
        foreach (var student in weakStudents)
        {
            Console.WriteLine(student.Fullname);
            foreach (var mark in student.Marks)
            {
                Console.Write(mark + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        //Problem 10
        var enrolledIn2014 = from student in students
                             where student.FacultyNumber.Substring(4, 2) == "14"
                             select student.Marks;
        foreach (var student in enrolledIn2014)
        {
            foreach (var mark in student)
            {
                Console.Write(mark + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        //Problem 11
        var groupedByGroupName = from student in students
                                 group student by student.GroupName;
        foreach (var group in groupedByGroupName)
        {
            Console.WriteLine(group.Key);
            foreach (var student in group)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + ", Age: " + student.Age + ", Email: " + student.Email + ", Phone: " + student.Phone);
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        //Problem 12
        List<StudentSpecialty> specialties = new List<StudentSpecialty>();
        specialties.Add(new StudentSpecialty("Web Developer", "2180146"));
        specialties.Add(new StudentSpecialty("Web Developer", "203114"));
        specialties.Add(new StudentSpecialty("PHP Developer", "2180141"));
        specialties.Add(new StudentSpecialty("PHP Developer", "2176108"));
        specialties.Add(new StudentSpecialty("QA Engineer", "2180146"));
        specialties.Add(new StudentSpecialty("Web Developer", "2176108"));
        var studentsWithSpecialties = from student in students
                                      join specialty in specialties on student.FacultyNumber equals specialty.FacultyNumber
                                      orderby student.FirstName, student.LastName
                                      select new { student, specialty };
        foreach (var student in studentsWithSpecialties)
        {
            Console.WriteLine(student.student.FirstName + " " + student.student.LastName + " " + student.student.FacultyNumber + " " + student.specialty.SpecialtyName);
        }
        Console.WriteLine();
    }
}