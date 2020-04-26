using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    public class Guard : NPC, ISpeak
    {

        #region Properties

        /// <summary>
        /// Gets and Sets the Message for NPC's
        /// </summary>
        public List<string> Messages { get; set; }

        /// <summary>
        /// Gets and Sets the Speak Property
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
        public Guard()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the Message Randomly
        /// </summary>
        /// <returns>Returns a Random Message</returns>
        private string GetMessage()
        {
            Random random = new Random();
            int index = random.Next(0, Messages.Count());
            return Messages[index];
        }

        /// <summary>
        /// Displays NPC information
        /// </summary>
        /// <returns>Returns NPC Information String</returns>
        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }

        #endregion

    }
}