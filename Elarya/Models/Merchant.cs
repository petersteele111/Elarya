using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    public class Merchant : NPC, ISpeak
    {

        public List<string> Messages { get; set; }

        public Merchant()
        {
           
        }

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
