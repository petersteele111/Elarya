using System.Collections.Generic;
using System.Linq;

namespace Elarya.Models
{
    public class QuestGather : Quest
    {

        #region Properties

        /// <summary>
        /// Gets and Sets the Required Game Items
        /// </summary>
        public List<GameItemQuantity> RequiredGameItemQuantities { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the game items that are still needed to complete the Quest
        /// </summary>
        /// <param name="inventory">items</param>
        /// <returns>Returns the items still needed for the Quest</returns>
        public List<GameItemQuantity> GameItemQuantitiesNotCompleted(List<GameItemQuantity> inventory)
        {
            var gameItemQuantitiesToComplete = new List<GameItemQuantity>();

            foreach (var questGameItem in RequiredGameItemQuantities)
            {
                var inventoryItemMatch =
                    inventory.FirstOrDefault(x => x.GameItem.Id == questGameItem.GameItem.Id);
                if (inventoryItemMatch == null)
                {
                    gameItemQuantitiesToComplete.Add(questGameItem);
                }
                else
                {
                    if (inventoryItemMatch.Quantity < questGameItem.Quantity)
                    {
                        gameItemQuantitiesToComplete.Add(questGameItem);                        
                    }
                }
            }

            return gameItemQuantitiesToComplete;
        }

        #endregion

    }
}
