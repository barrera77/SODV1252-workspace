using System.Collections.Generic;
using System.Security.Claims;
using System.Transactions;
using System.Xml.Linq;

namespace Assessment_1
{
    internal class Program
    {
        public static List<Character> characters = new List<Character>();
        
        static void Main(string[] args)
        { 
            //Commence the sequence
            HandleMainMenu();
        }

        #region Helper Methods
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
                        //Create a new character
                        try
                        {
                            Character newCharacter = CreateCharacter();

                            characters.Add(newCharacter);
                            Console.ReadLine();
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        
                        break;

                    case "2":
                        //Assign skill to a character
                        AssignSkills();
                        break;

                    case "3":
                        //level up character
                        LevelUpCharacter();
                        break;

                    case "4":
                        //Display available characters sheet
                        DisplayCharacterSheets();
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

        #endregion

        #region Menu Option 1
        static Character CreateCharacter()
        {
            string characterName = RequestCharacterName();
            string characterClass = RequestCharacterClass();
            int characterAtributePoints = RequestCharacterAtributePoints();

            return new Character(characterName, characterClass, characterAtributePoints);
        }

        /// <summary>
        /// Request and validate the character name
        /// </summary>
        /// <returns>character name</returns>
        static string RequestCharacterName()
        {
            bool isValidName = false;
            string characterName = "";
            
            while(!isValidName)
            {
                Console.Write("Enter name: ");
                characterName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(characterName))
                {
                    Console.WriteLine("Invalid input, please provide a name for the character");
                }
                else
                {
                    isValidName = true;
                }
            }
            return characterName;
        }

        /// <summary>
        /// Request and validate the character class
        /// </summary>
        /// <returns>character class</returns>
        static string RequestCharacterClass()
        {
            bool isValidClass = false;
            string characterClass = "";

            while (!isValidClass)
            {
                Console.Write("Enter class: ");
                characterClass = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(characterClass))
                {
                    Console.WriteLine("Invalid input, please provide a class for the character");
                }
                else
                {
                    isValidClass = true;
                }
            }
            return characterClass;
        }

        /// <summary>
        /// Request and validate the amount of attribute points
        /// for the character
        /// </summary>
        /// <returns>Attribute points</returns>
        static int RequestCharacterAtributePoints()
        {
            bool isValidInput = false;
            int attibutePoints = 0;

            while (!isValidInput)
            {
                Console.Write("Enter total attribute points: ");

                if(int.TryParse(Console.ReadLine(), out attibutePoints))
                {
                    if (attibutePoints <= 0)
                    {
                        Console.WriteLine("Invalid input, please provide a positive integer for the level");
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }
                else
                {                    
                    Console.WriteLine("Invalid input, please a provide a valid number");
                }
            }

            return attibutePoints;
        }
        #endregion

        #region Menu Option 2

        /// <summary>
        /// Assigns the skills to the character as per requirments
        /// </summary>
        static void AssignSkills()
        {
            List<Skill> skills = new List<Skill>
            {
                new Skill { Name = "Strike", Description = "A powerful strike.", Attribute = "Strength", RequiredAttributePoints=10 },
                new Skill { Name = "Dodge", Description = "Avoid an attack.", Attribute = "Dexterity", RequiredAttributePoints=15 },
                new Skill { Name = "Spellcast", Description = "Cast a spell.", Attribute = "Intelligence", RequiredAttributePoints=20 }
            };

            bool isValidCharacter = false;
            int skillIndex = 0;
             
            if (characters.Count == 0)
            {
                Console.Write("There are no available characters");
                Console.ReadLine();
            }
            else
            {
                while(!isValidCharacter)
                {
                    //look up if the provided character exists
                    Character character = FindCharacter();
                    if (character == null)
                    {
                        Console.Write("Try again . . .");

                        Console.ReadLine();
                    }
                    else
                    {
                        int characterAttributePoints = character.AvailableAttributePoints;
                        Console.WriteLine($"\nTotal Attribute Points Available for this character: {characterAttributePoints} ");
                        Console.WriteLine("Available skills: ");

                        DisplayAvailableSkills(skills);
                        skillIndex = RequestSkill(characterAttributePoints);
                        Skill chosenSkill = skills.ElementAt(skillIndex -1);
                        
                        if(!ValidateSkill(chosenSkill, characterAttributePoints))
                        {
                            Console.WriteLine("Not enough attribute points are available!");
                        }
                        else
                        {
                            character._skills.Add(chosenSkill);

                            //Update attribute points
                            character.AvailableAttributePoints = characterAttributePoints - chosenSkill.RequiredAttributePoints;
                        }

                        Console.ReadLine();

                        isValidCharacter = true;
                    }
                }               
            }
        }

        /// <summary>
        /// Search for the provided character within the 
        /// characters list
        /// </summary>
        /// <returns>character index</returns>
        static Character FindCharacter()
        {
            string characterName = RequestCharacterName();

            Character character = characters.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                Console.WriteLine($"No character with the name {characterName} was found");
            }
            return character;
        }

        /// <summary>
        /// Display a list of available skills from where the user
        /// can choose a option
        /// </summary>
        /// <param name="skillsList"></param>
        static void DisplayAvailableSkills(List<Skill> skillsList)
        {
            int skillCounter = 1;
            foreach (Skill skill in skillsList)
            {
                Console.WriteLine($"{skillCounter}. {skill.ToString()}  ");
                skillCounter++;
            }
        }

        /// <summary>
        /// Requests and validatest the skill choice
        /// </summary>
        /// <param name="attributePoints"></param>
        /// <returns>Validated skill choice</returns>
        static int RequestSkill(int attributePoints)
        {
            bool isValidInput = false;
            int skillNumber = 0;

            Console.Write("Select a skill to assign: ");
            while (!isValidInput)
            { 
                if (int.TryParse(Console.ReadLine(), out skillNumber))
                {
                    if (skillNumber <= 0 || skillNumber > 3)
                    {
                        Console.Write("Invalid selection. Please enter a number in range (1..3): ");
                    }
                    else
                    {                       
                        isValidInput = true;
                    }
                }
                else
                {
                    Console.Write("Invalid selection. Please enter a number in range (1..3): ");
                }
            }
            return skillNumber;
        }

        /// <summary>
        /// Validates if the the chosen skill can be acquired 
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="attributePoints"></param>
        /// <returns></returns>
        static bool ValidateSkill(Skill skill, int attributePoints)
        {
            return skill.RequiredAttributePoints > attributePoints ? false : true;  
        }

        #endregion

        #region Menu Option 3

        static void LevelUpCharacter()
        {
            bool isValidCharacter = false;
            

            if (characters.Count == 0)
            {
                Console.Write("There are no available characters");
                Console.ReadLine();
            }
            else
            {
                while (!isValidCharacter)
                {
                    //look up if the provided character exists
                    Character character = FindCharacter();
                    if (character == null)
                    {
                        Console.Write("Try again . . .");

                        Console.ReadLine();
                    }
                    else
                    {
                        character.LevelUp();
                        Console.Write($"{character.Name} is now a Level:{character.Level} character");
                        Console.ReadLine();

                    }
                    isValidCharacter = true;
                }
            }
        }

        #endregion

        #region Menu Option 4

        /// <summary>
        /// Display the avalaible characters sheet
        /// </summary>
        static void DisplayCharacterSheets()
        {
            if (!characters.Any())
            {
                Console.Write("No available characters to show.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("All Characters in the character sheet.......................");
                foreach (Character character in characters)
                {
                    Console.WriteLine(character.ToString() + "\n");                    
                }
                Console.WriteLine("End.........................................................");
                Console.ReadLine();

            }
        }
        #endregion
    }
}
