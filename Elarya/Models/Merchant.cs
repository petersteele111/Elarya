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
        public Merchant()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the Message for the NPC Randomly
        /// </summary>
        /// <returns>Returns random message for NPC</returns>
        private string GetMessage()
        {
            Random random = new Random();
            int index = random.Next(0, Messages.Count());
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
