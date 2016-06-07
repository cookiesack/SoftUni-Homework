using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_01___Class_Student
{
    class Student
    {
        public Student(string firstName,
                       string lastName,
                       int age,
                       string facultyNumber,
                       string phone,
                       string email,
                       int[] marks,
                       int groupNumber,
                       string groupName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
            this.GroupName = groupName;
        }
        public string FirstName;
        public string LastName;
        public int Age;
        public string FacultyNumber;
        public string Phone;
        public string Email;
        public IList<int> Marks;
        public int GroupNumber;
        public string GroupName;
    }
}
