using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._AcademyGraduation
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new SortedDictionary<string, List<Double>>();

            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var student = Console.ReadLine();
                var grades = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();

                if (!students.ContainsKey(student))
                {
                    students[student] = new List<Double>();
                    students[student].AddRange(grades);
                }
            }

            foreach (var student in students)
            {
                Console.WriteLine("{0} is graduated with {1}", student.Key, student.Value.Average());
            }
        }
    }
}
