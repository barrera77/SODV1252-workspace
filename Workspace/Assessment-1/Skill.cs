using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    public class Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Attribute { get; set; }
        public int RequiredAttributePoints { get; set; }

        // Constructor
        public Skill(string name, string description, string attribute, int requiredAttributePoints)
        {
            Name = name;
            Description = description;
            Attribute = attribute;
            RequiredAttributePoints = requiredAttributePoints;
        }
       
        public override string ToString()
        {
            return $"{Name}: {Description} (Attribute: {Attribute}, Required Points: {RequiredAttributePoints})";
        }
    }
}
