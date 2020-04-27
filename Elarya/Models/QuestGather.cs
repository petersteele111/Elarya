using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    public class QuestGather : Quest
    {

        #region Fields

        private int _id;
        private string _name;
        private QuestStatus _status;
        private List<GameItemQuantity> _requiredGameItemQuantities;

        #endregion

        #region Properties

        /// <summary>
        /// Gets and Sets the Required Game Items
        /// </summary>
        public List<GameItemQuantity> RequiredGameItemQuantities
        {
            get => _requiredGameItemQuantities;
            set => _requiredGameItemQuantities = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Public Constructor
        /// </summary>
        public QuestGather()
        {

        }

        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <param name="id">Id of QuestGather</param>
        /// <param name="name">Name of Quest Gather</param>
        /// <param name="status">Stats of QuestGather</param>
        /// <param name="requiredGameItemQuantities">Required items to gather</param>
        public QuestGather(int id, string name, QuestStatus status, List<GameItemQuantity> requiredGameItemQuantities) : base(id, name, status)
        {
            _id = id;
            _name = name;
            _status = status;
            _requiredGameItemQuantities = requiredGameItemQuantities;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Finds the game items that are still needed to complete the Quest
        /// </summary>
        /// <param name="inventory">items</param>
        /// <returns>Returns the items still needed for the Quest</returns>
        public List<GameItemQuantity> GameItemQuantitiesNotCompleted(List<GameItemQuantity> inventory)
        {
            List<GameItemQuantity> gameItemQuantitiesToComplete = new List<GameItemQuantity>();

            foreach (var questGameItem in _requiredGameItemQuantities)
            {
                GameItemQuantity inventoryItemMatch =
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
