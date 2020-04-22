using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    public class GameItemQuantity
    {
        #region Properties

        /// <summary>
        /// Gets and Sets Game Item
        /// </summary>
        public GameItem GameItem { get; set; }
        
        /// <summary>
        /// Gets and Sets Quantity
        /// </summary>
        public int Quantity { get; set; }

        #endregion

        #region Constructors

        public GameItemQuantity()
        {

        }

        public GameItemQuantity(GameItem gameItem, int quantity)
        {
            GameItem = gameItem;
            Quantity = quantity;
        }

        #endregion
    }
}
