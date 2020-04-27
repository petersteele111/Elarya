using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    public class Citizen : NPC, ISpeak
    {

        #region Properties

        /// <summary>
        /// Gets and Sets the Messages
        /// </summary>
        public List<string> Messages { get; set; }

        /// <summary>
        /// Gets and Sets the Message to Display
        /// </summary>
        /// <returns>Returns the Message</returns>
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

        #endregion

        #region Constructor

        /// <summary>
        /// Public Constructor
        /// </summary>
        public Citizen()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the Message 
        /// </summary>
        /// <returns>Returns the Message Randomly</returns>
        private string GetMessage()
        {
            Random random = new Random();
            int index = random.Next(0, Messages.Count());
            return Messages[index];
        }

        /// <summary>
        /// Displays Information about the NPC
        /// </summary>
        /// <returns>Returns NPC Info String</returns>
        protected override string InformationText()
        {
            return $"{Name} - {Age} - {Race} - {Gender} - {Description}";
        }

        #endregion

    }
}
