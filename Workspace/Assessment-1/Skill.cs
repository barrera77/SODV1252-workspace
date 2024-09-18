using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    public class Skill
    {
        private string _name;
        private string _description;
        private string _attribute;
        private int _requiredAttributePoints;

        //Default constructor
        public Skill() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Attribute { get; set; }
        public int RequiredAttributePoints { get; set; }

       

        // Greedy constructor
        public Skill(string name, string description, string attribute, int requiredAttributePoints)
        {
            Name = name;
            Description = description;
            Attribute = attribute;
            RequiredAttributePoints = requiredAttributePoints;
        }
       
        public override string ToString()
        {
            return $"{Name} - {Description} - {Attribute} - Point Requirments: {RequiredAttributePoints})";
        }
    }
}
