using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Assessment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string story = GenerateStory();
            //TODO: FIgure a way to prompt the user for input and then for file 
            //name to save the file. (may need to revise GetInputs method)
            string fileName = ValidateInput("Enter a filename to save your story:", "file name");
            SaveStory(fileName, story);
        }

        /// <summary>
        /// read the file to ge tthe story template
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>The story template</returns>
        static string[] ReadTemplate(string fileName)
        {
            string[] storyTemplate = null;

            try
            {
                if (File.Exists(fileName))
                {
                    storyTemplate = File.ReadAllLines(fileName);
                }
                else
                {
                    throw new IOException("Error reading the story template file.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return storyTemplate;
        }

        /// <summary>
        /// get the elements for the story from the user
        /// </summary>
        /// <returns>A dictionary with the lements for the story</returns>
        static Dictionary<string, string> GetUserInputs()
        {
            Dictionary<string, string> inputs = new Dictionary<string, string>();

            inputs["location"] = ValidateInput("Enter a location: ", "location");

            inputs["character_name"] = ValidateInput("Enter a character name: ", "name");

            inputs["item"] = ValidateInput("Enter a character item: ", "item");

            inputs["action"] = ValidateInput("Enter a character action: ", "action");

            return inputs;
        }

        /// <summary>
        /// Generates the story using the elements and story template
        /// </summary>
        static string GenerateStory()
        {
            string fileName = "story_template.txt";
            string directoryPath = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(directoryPath, fileName);

            string[] storyTemplate = ReadTemplate(filePath);
            string[] completedStory = new string[storyTemplate.Length];
            Dictionary<string, string> inputs = GetUserInputs();

            StringBuilder newStory = new StringBuilder();

            foreach (string storyLine in storyTemplate)
            {
                string processedStoryLine = storyLine;

                foreach (var input in inputs)
                {
                    processedStoryLine = processedStoryLine.Replace("{" + input.Key + "}", input.Value); ;

                }
                newStory.AppendLine(processedStoryLine);
                //Console.WriteLine(processedStoryLine);
            }

            return newStory.ToString();
        }
             
        /// <summary>
        /// Get the story and save it to a new file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="story"></param>
        static void SaveStory(string fileName, string story)
        {            
            string directoryPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            string filePath = Path.Combine(directoryPath, fileName);

            File.WriteAllText(filePath, story);

            Console.WriteLine($"The story was succesfully saved to {filePath}");
            Console.ReadLine();
            
        }

            #region Helper Methods
            //Validate file name
            static bool IsValidFileName(string fileName)
            {
                return !String.IsNullOrWhiteSpace(fileName);
            }

            /// <summary>
            /// Validates user input
            /// </summary>
            /// <param name="prompt"></param>
            /// <param name="element"></param>
            /// <returns>validated input</returns>
            static string ValidateInput(string prompt, string element)
            {
                bool isValidInput = false;
                string input = "";

                Console.Write(prompt);

                while (!isValidInput)
                {

                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.Write($"Invalid input. Please enter a valid {element}:");
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }
                return input;
            }

            #endregion        
    }
}
