using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    public class Character
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public int AvailableAttributePoints { get; set; }
        public List<Skill> Skills { get; set; }


        //Constructor
        public Character(string name, string CharacterClass, int level, int hitPoints, int availableAttributePoints)
        {
            Name = name;
            Class = CharacterClass;
            Level = level;
            HitPoints = hitPoints;
            AvailableAttributePoints = availableAttributePoints;
            Skills = new List<Skill>();
        }

    }
}
