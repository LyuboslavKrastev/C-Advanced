using System;
using System.Linq;
using System.Collections.Generic;
namespace Problem_4___Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var departments = new Dictionary<string, Queue<Room>>();
            var doctors = new Dictionary<string, HashSet<string>>();

            while ((input = Console.ReadLine()) != "Output")
            {
                var tokens = input.Split();
                var departmentName = tokens[0];
                var doctorName = $"{tokens[1]} {tokens[2]}";
                var patientName = tokens[3];

                if (!departments.ContainsKey(departmentName))
                {
                    CreateDepartment(departments, departmentName);
                }

                var availableRoom = departments[departmentName].FirstOrDefault(r => r.EmtpyBeds > 0);

                if (availableRoom == null)
                {
                    continue;
                }

                departments[departmentName].FirstOrDefault(r => r == availableRoom).EmtpyBeds--;
                departments[departmentName].FirstOrDefault(r => r == availableRoom).Patients.Add(patientName);

                if (!doctors.ContainsKey(doctorName))
                {
                    doctors[doctorName] = new HashSet<string>();
                }
                doctors[doctorName].Add(patientName);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                input = input.Trim();
                if (char.IsDigit(input[input.Length - 1]))
                {
                    var tokens = input.Split();
                    var dpt = tokens.Take(tokens.Length - 1);
                    var department = string.Join(" ", dpt);
                    var roomNumber = int.Parse(tokens[tokens.Length - 1]);

                    var room = departments[department].FirstOrDefault(r => r.Number == roomNumber);

                    foreach (var patient in room.Patients.OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }
                else if (departments.ContainsKey(input))
                {
                    foreach (var room in departments[input])
                    {
                        foreach (var patient in room.Patients)
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
                else if (doctors.ContainsKey(input))
                {
                    foreach (var patient in doctors[input].OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }
            }
        }

        private static void CreateDepartment(Dictionary<string, Queue<Room>> departments, string departmentName)
        {
            departments[departmentName] = new Queue<Room>();
            for (int i = 1; i <= 20; i++)
            {
                var currentRoom = new Room()
                {
                    Number = i
                };
                departments[departmentName].Enqueue(currentRoom);
            }
        }
    }
}
