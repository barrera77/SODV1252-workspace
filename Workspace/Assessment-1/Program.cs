namespace Assessment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Character> characters = new List<Character>();

            List<Skill> skills = new List<Skill>
            {
                new Skill { Name = "Strike", Description = "A powerful strike.", Attribute = "Strength", RequiredAttributePoints=10 },
                new Skill { Name = "Dodge", Description = "Avoid an attack.", Attribute = "Dexterity", RequiredAttributePoints=15 },
                new Skill { Name = "Spellcast", Description = "Cast a spell.", Attribute = "Intelligence", RequiredAttributePoints=20 }
            };
                


            Console.WriteLine("Hello, World!");
        }
    }
}
