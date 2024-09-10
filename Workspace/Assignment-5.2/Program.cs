namespace Assignment_5._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You may not change anything from the main method.

            Console.WriteLine("Enter a person's name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter e-mail address: ");
            string address = Console.ReadLine();

            // Demonstration for Person class
            Person person = new Person();
            person.Name = name;
            person.Age = age;
            person.EmailAddress = address;
            Console.WriteLine(person);



            // Demonstration for PlayersInfo class
            PlayersInfo playersInfo = new PlayersInfo();
            playersInfo.AddPlayer(person);
            playersInfo.AddPlayer(new Person { Name = "Susan Harper", Age = 35, EmailAddress = "susan.harper@gmail.com" });
            playersInfo.AddPlayer(new Person { Name = "Alex Whatmore", Age = 25, EmailAddress = "alex.whatmore@gmail.com" });
            playersInfo.DisplayPlayers();

            Console.ReadLine();
        }
    }

    // 1. Person class
    public class Person
    {
        private string _name;
        private int _age;
        private string _emailAddress;

        public string Name
        {
            //ToDo
            //Create properties out of private fields

            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int Age
        {
            //ToDo
            //Create properties out of private fields

            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }

        public string EmailAddress
        {
            //ToDo
            //Create properties out of private fields

            get
            {
                return _emailAddress;
            }
            set
            {
                _emailAddress = value;
            }
        }

        public override string ToString()
        {
            //Return a string to match the Person output!
            return $"Name: {Name}, {Age}, {EmailAddress}";
        }
    }

    // 2. PlayersInfo class
    public class PlayersInfo
    {
        //Create a list of players
        List<Person> PlayersList = new List<Person>();

        public void AddPlayer(Person player)
        {
            //add the "player" to the players list.
            PlayersList.Add(player);

        }

        public void DisplayPlayers()
        {
            Console.WriteLine("All Players Information:");
            //ToDo
            //Iterate over the players list and display all players
            foreach(var player in PlayersList)
            {
                Console.WriteLine($"Name: {player.Name}, Age: {player.Age}, Email: {player.EmailAddress}");
            }
        }
    }
}
