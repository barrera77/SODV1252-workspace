namespace Assessment_1
{
    internal class Program
    {
        Character newCharater;

        void Main(string[] args)
        {
            List<Character> characters = new List<Character>();

            //List<Skill> skills = new List<Skill>
            //{
            //    new Skill { Name = "Strike", Description = "A powerful strike.", Attribute = "Strength", RequiredAttributePoints=10 },
            //    new Skill { Name = "Dodge", Description = "Avoid an attack.", Attribute = "Dexterity", RequiredAttributePoints=15 },
            //    new Skill { Name = "Spellcast", Description = "Cast a spell.", Attribute = "Intelligence", RequiredAttributePoints=20 }
            //};






            DisplayMainMenu();
        }

        /// <summary>
        /// Prints the main menu
        /// </summary>
        static void DisplayMainMenu()
        {
            string mainMenu = "Main Menu:" +
            "\n1. Create a character\n" +
            "2. Assign skills\n" +
            "3. Level up a character\n" +
            "4. Display all character sheets\n" +
            "5. Exit";

            Console.Clear();
            Console.WriteLine(mainMenu);
        }

        /// <summary>
        /// Handles the menu option selected by the user
        /// and redirects to the appropiate action
        /// </summary>
        static void HandleMainMenu()
        {
            string mainMenuOption = "";

            do
            {
                DisplayMainMenu();


                Console.Write("\nEnter your choice: ");
                mainMenuOption = Console.ReadLine();

                switch (mainMenuOption)
                {
                    case "1":
                        break;

                    case "2":
                        break;

                    case "3":
                        break;

                    case "4":
                        break;

                    case "5":
                        Console.WriteLine("Exiting the system. Have a great day!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ReadLine();
                        break;
                }
            }
            while (mainMenuOption != "5");
        }

        //public Character CreateCharacter()
        //{
        //    newCharater = new Character()
        //    { };
        //}
    }
}
