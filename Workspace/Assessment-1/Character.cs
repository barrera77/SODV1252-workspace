using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    internal class Character
    {
        private string _name;
        private string _class;
        private int _level;
        private int _hitPoints;
        private int _availableAttributePoints;
        public List<Skill> _skills;

        //Default constructor
        public Character()
        {
            _skills = new List<Skill>();
        }

        //Character name
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input, please provide a name for the character");
                }
                else
                {
                    _name = value.Trim();
                }
            }
        }

        //Character class
        public string Class
        {
            get { return _class; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input, please provide a class for the character");
                }
                else
                {
                    _class = value.Trim();
                }
            }
        }

        //Character level
        public int Level
        {
            get 
            { 
                return _level; 
            }
        }
     

        //Number of hitpoint for the character
        public int HitPoints 
        {
            get
            {
                return _hitPoints;
            }
        }

        //Number of atribute points for the charcater
        public int AvailableAttributePoints 
        {
            get { return _availableAttributePoints;  }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Invalid input, please provide a positive integer for the attribute points");
                }
                _availableAttributePoints = value;
            }
        }     

        //Greedy Constructor
        public Character(string name, string CharacterClass, int availableAttributePoints)
        {
            Name = name;
            Class = CharacterClass;
            _level = 1;
            _hitPoints = CalculateInitialHitPoints();
            AvailableAttributePoints = availableAttributePoints;
            _skills = new List<Skill>();
        }

        /// <summary>
        /// Level up character as per specs
        /// </summary>
        public void LevelUp()
        {
            _level += 1;
            AvailableAttributePoints += 10;
            _hitPoints += 5;
        }

        /// <summary>
        /// Calculates the initial hitpoints for the character
        /// </summary>
        /// <returns></returns>
        private int CalculateInitialHitPoints()
        {
            return 10 + AvailableAttributePoints / 2;
        }

        public override string ToString()
        {
            string skillsList = _skills.Count > 0 ? string.Join("Skills:\n", _skills.Select(skill => skill.ToString())) : "Skills:\nThere are no skills assigned yet...!";

            return $"Name: {Name}, Class: {Class}, Level: {Level}, Hitpoints: {HitPoints}, Available Attribute Points: {AvailableAttributePoints}, \n{skillsList}";
        }

    }
}
