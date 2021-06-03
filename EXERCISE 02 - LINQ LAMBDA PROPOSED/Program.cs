using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Entities;
namespace EXERCISE_02___LINQ_LAMBDA_PROPOSED {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter full file path: ");
            string path = Console.ReadLine();
            Console.WriteLine("Enter salary: ");
            double limit = double.Parse(Console.ReadLine());

            List<Employee> list = new List<Employee>();
            try {
                using (StreamReader sr = File.OpenText(path)) {
                    while (!sr.EndOfStream) {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2]);
                        list.Add(new Employee(name, email, salary));
                    }

                    var emails = list.Where(obj => obj.Salary > limit).OrderBy(obj => obj.Email).Select(obj => obj.Email);

                    var sum = list.Where(obj => obj.Name[0] == 'M').Sum(obj => obj.Salary);

                    Console.WriteLine("Email of people whose salary is more than " + limit.ToString("F2"));
                    foreach(string email in emails) {
                        Console.WriteLine(email);
                    }
                    Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2"));

                }
            }
            catch(IOException e) {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
