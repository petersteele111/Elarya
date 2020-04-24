using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    public abstract class NPC : Character
    {
        public string Description { get; set; }
        
        public string Information
        {
            get => InformationText();
            set
            {

            }
        }

        public NPC()
        {

        }

        public NPC(int id, int locationId, string name, int age, RaceType race, GenderType gender, string description) : base(id, locationId, name, age, race, gender)
        {
            Id = id;
            LocationId = locationId;
            Age = age;
            Race = race;
            Gender = gender;
            Description = description;
        }

        protected abstract string InformationText();

        public override bool HasQuest()
        {
            throw new NotImplementedException();
        }
    }
}
