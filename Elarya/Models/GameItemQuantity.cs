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

        /// <summary>
        /// Public Constructor for Game Item Quantity
        /// </summary>
        public GameItemQuantity()
        {

        }

        /// <summary>
        /// Public Constructor for Game Item Quantity
        /// </summary>
        /// <param name="gameItem">item</param>
        /// <param name="quantity">quantity of item</param>
        public GameItemQuantity(GameItem gameItem, int quantity)
        {
            GameItem = gameItem;
            Quantity = quantity;
        }

        #endregion

    }
}
