using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_01___Students_and_Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("students.txt");
            var courses = new SortedDictionary<string, SortedSet<Person>>();
            string[] inputParams;
            do
            {
                string input = reader.ReadLine();
                if (input == null) break;
                inputParams = input.Split('|');
                for (int i = 0; i < inputParams.Length; i++)
                {
                    inputParams[i] = inputParams[i].Trim();
                }

                if (!courses.ContainsKey(inputParams[2]))
                {
                    courses.Add(inputParams[2], new SortedSet<Person>());
                }

                courses[inputParams[2]].Add(new Person(inputParams[0], inputParams[1]));
            } while (true);

            foreach (var course in courses)
            {
                Console.Write(course.Key + ": ");
                foreach (var person in course.Value)
                {
                    Console.Write(person.FirstName + " " + person.LastName);
                    if(person != course.Value.Last()) Console.Write(", ");
                }

                Console.WriteLine();
            }
        }
    }
}
