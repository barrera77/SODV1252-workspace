
namespace Assignment_6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int choice = 0;

            do
            {
                Console.WriteLine("1. Add a student\n2. Assign grade\n3. Retrieve student info\n4. Exit");

                try
                {
                    choice = ValidateMenuChoice(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            string name = "";
                            int age = 0;
                            name = ValidateName();

                            age = ValidateAge();
                            students.Add(new Student { Name = name, Age = age });

                            break;
                        case 2:
                            int index;
                            double grade;

                            index = FindStudentIndex(students);                            
                            grade = ValidateGrade();

                            students[index].Grade = grade;
                            break;
                        case 3:                           
                            index = FindStudentIndex(students);

                            Console.WriteLine($"Name: {students[index].Name}, Age: {students[index].Age}, Grade: {students[index].Grade}");
                            Console.WriteLine("Instructed executed. Press Enter to continue... ");
                            Console.ReadLine();
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Try again.\n");
                            break;
                    }
                }               
                catch (InvalidDataException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Instructed executed. Press Enter to continue... ");
                    Console.ReadLine();
                }
            }
            while (choice != 4);
        }

        #region Helper Methods
        /// <summary>
        /// Validates the menu choice, if valid returns the number
        /// otherwise, throw a custom Exception
        /// </summary>
        /// <param name="input"></param>
        /// <returns>validated menu choice</returns>
        /// <exception cref="InvalidDataException"></exception>
        static int ValidateMenuChoice(string input)
        {
            if (!int.TryParse(input, out int validChoice))
            {
                throw new InvalidDataException("Invalid Input. Please enter a number");
            }

            return validChoice;
        }

       /// <summary>
       /// Validates the name based on the provided conditions
       /// </summary>
       /// <returns>validated name</returns>
        static string ValidateName()
        {
            bool isValidName = false;
            string name = "";
            string errorMessage = "Name error: Name must start with an uppercase letter.";

            while (!isValidName)
            {

                Console.Write("Enter student name: ");

                name = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine(errorMessage);
                }
                else if (!char.IsUpper(name[0]))
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    isValidName = true;
                }               
            }
            
            return name;
        }

        /// <summary>
        /// Validates that the age is according to specified
        /// conditions
        /// </summary>
        /// <returns>Validated Age</returns>
        static int ValidateAge()
        {
            bool isValidAge = false;
            int validAge = 0;

            while (!isValidAge)
            {
                Console.Write("Enter student age: ");
                if (!int.TryParse(Console.ReadLine(), out validAge))
                {
                    Console.WriteLine("Age must be a number.");
                }
                else
                {
                    if (validAge >= 0 && validAge < 18)
                    {
                        Console.WriteLine("Validation error: Age must be at least 18.");
                    }
                    else if (validAge < 0)
                    {
                        Console.WriteLine("Validation error: Age cannot be negative.");
                    }
                    else if (validAge > 65)
                    {
                        Console.WriteLine("Validation error: Age cannot be more than 65.");
                    }
                    else
                    {
                        Console.WriteLine("Instructed executed. Press Enter to continue...");
                        Console.ReadLine();

                        isValidAge = true;
                    }
                }
            }
            return validAge;
        }

        /// <summary>
        /// Finds the index within the students list
        /// for the provided student
        /// </summary>
        /// <param name="studentsList"></param>
        /// <returns>student index</returns>
        /// <exception cref="InvalidDataException"></exception>
        static int FindStudentIndex(List<Student> studentsList)
        {
            int studentIndex = 0;
            string studentName = "";

            studentName = ValidateName();

            Student student = studentsList.FirstOrDefault(s => s.Name == studentName);

            if (student == null)
            {
                throw new InvalidDataException($"Student {studentName} not found");
            }
            else
            {
                studentIndex = studentsList.IndexOf(student);
            }

            return studentIndex;
        }

        /// <summary>
        /// Verifies that the provided grade is within the
        /// especified conditions
        /// </summary>
        /// <returns>Validated grade</returns>
        static double ValidateGrade()
        {
            bool isValidGrade = false;

            double validGrade = 0;

            while (!isValidGrade)
            {
                Console.Write("Enter student grade: ");

                if (!double.TryParse(Console.ReadLine(), out validGrade))
                {
                    Console.WriteLine($"Validation error: Input string was not in a correct format. ");
                }
                else
                {
                    if (validGrade < 0 || validGrade > 100)
                    {
                        Console.WriteLine("Validation error: Grade must be between 0 and 100.");
                    }
                    else
                    {
                        Console.WriteLine("Instructed executed. Press Enter to continue...");
                        Console.ReadLine();

                        isValidGrade = true;
                    }
                }
            }
            return validGrade;
        }

        #endregion

    }

    //Helper class for custom exceptions
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message) : base(message)
        {
        }
    }

    //Student class
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
    }
}
