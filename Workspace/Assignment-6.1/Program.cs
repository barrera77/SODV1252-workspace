using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Assignment_6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            while (true)
            {
                Console.WriteLine("1. Add a student\n2. Assign grade\n3. Retrieve student info\n4. Exit");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter student name: ");
                            string name = Console.ReadLine();

                            ValidateName(name);

                               
                          
                            
                                Console.Write("Enter student age: ");
                                int age = int.Parse(Console.ReadLine());
                                students.Add(new Student { Name = name, Age = age });
                            

                            
                            break;
                        case 2:
                            Console.Write("Enter student index: ");
                            int index = int.Parse(Console.ReadLine());
                            Console.Write("Enter student grade: ");
                            double grade = double.Parse(Console.ReadLine());
                            students[index].Grade = grade;
                            break;
                        case 3:
                            Console.Write("Enter student index: ");
                            index = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Name: {students[index].Name}, Age: {students[index].Age}, Grade: {students[index].Grade}");
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Try again.\n");
                            break;
                    }

                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Format error: {ex.Message}");

                    Console.WriteLine("Instructed executed. Press Enter to continue... ");
                    Console.ReadLine();
                }
               
                
            }
        }

        static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new FormatException("Name must start with an uppercase letter.");
            }

            if (!char.IsUpper(name[0]))
            {

                throw new FormatException("Name must start with an uppercase letter.");
            }

            if (Regex.IsMatch(name, @"\d"))
            {
                throw new FormatException("Name must start with an uppercase letter.");
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
    }






}
