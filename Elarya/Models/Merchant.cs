using System;
using System.Collections.Generic;

namespace Elarya.Models
{
    public class Merchant : NPC, ISpeak
    {

        #region Properties

        /// <summary>
        /// Gets and Sets the Messages
        /// </summary>
        public List<string> Messages { get; set; }

        /// <summary>
        /// Gets and Sets the Speak function to get messages
        /// </summary>
        /// <returns></returns>
        public string Speak()
        {
            return this.Messages != null ? GetMessage() : "";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the Message for the NPC Randomly
        /// </summary>
        /// <returns>Returns random message for NPC</returns>
        private string GetMessage()
        {
            var random = new Random();
            var index = random.Next(0, Messages.Count);
            return Messages[index];
        }

        /// <summary>
        /// Displays the NPC Information
        /// </summary>
        /// <returns>Returns the NPC Information String</returns>
        protected override string InformationText()
        {
            return $"{Name} - {Age} - {Race} - {Gender} - {Description}";
        }

        #endregion

    }
}
