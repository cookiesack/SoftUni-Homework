using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_01___Class_Student
{
    public static class WeakMarks
    {
        public static int countWeakMarks(this IList<int> marks)
        {
            var weakMarks = from mark in marks
                            where mark == 2
                            select mark;
            return weakMarks.Count();
        }
    }
}
