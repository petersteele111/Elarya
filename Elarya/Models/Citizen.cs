using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    public class Citizen : NPC, ISpeak
    {
        public List<string> Messages { get; set; }

        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }

        public Citizen()
        {

        }

        private string GetMessage()
        {
            Random random = new Random();
            int index = random.Next(0, Messages.Count());
            return Messages[index];
        }

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }
    }
}
