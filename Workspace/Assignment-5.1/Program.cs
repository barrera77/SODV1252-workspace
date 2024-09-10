namespace Assignment_5._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Create instances of the 'Book' class
            Console.WriteLine("Using Default Constructor: ");
            Book defaultBook = new Book();
            Console.WriteLine(defaultBook);

            Console.WriteLine("Enter Book Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Author: ");
            string author = Console.ReadLine();
            Console.WriteLine("Enter Publication Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Using Parametric Constructor: ");
            Book parameterizedBook = new Book(title, author, year);
            Console.WriteLine(parameterizedBook);


            // Task 2: Create an instance of the 'Student' class using object initializer syntax

            Console.WriteLine("Enter student name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student major: ");
            string major = Console.ReadLine();
            //ToDo
            //Replace the following line and create a student object...
            Student student = new Student()
            {
                Name = name,
                Age = age,
                Major = major
            };
            Console.WriteLine($"Student - Name: {student.Name}, Age: {student.Age}, Major: {student.Major}");
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }

        // Default constructor
        public Book()
        {
            //ToDo
            Title = null;
            Author = null;
            YearPublished = 0;
        }

        // Parameterized constructor
        public Book(string title, string author, int yearPublished)
        {
            //ToDo
            Title = title;
            Author = author;
            YearPublished = yearPublished;
        }

        public override string ToString()
        {
            //ToDo
            return $"Default Book - Title: {Title}, Author: {Author}, Year Published: {YearPublished}";
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
    }
}
