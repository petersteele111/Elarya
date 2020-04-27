using System;
using System.Collections.Generic;

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
            return this.Messages != null ? GetMessage() : "";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the Message 
        /// </summary>
        /// <returns>Returns the Message Randomly</returns>
        private string GetMessage()
        {
            var random = new Random();
            var index = random.Next(0, Messages.Count);
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
