using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elarya.Models;

namespace Elarya.Presentation.ViewModels
{
    public class ElaryaGameViewModel
    {
        #region Fields

        private Player _player;
        private List<string> _messages;

        #endregion

        #region Properties

        public Player Player
        {
            get => _player;
            set
            {
                _player = value;
            }
        }

        #endregion

        #region Constructor

        public ElaryaGameViewModel()
        {

        }

        public ElaryaGameViewModel(Player player, List<string> initialMessages)
        {
            _player = player;
            _messages = initialMessages;
        }

        #endregion

        #region Methods

        public string MessageDisplay
        {
            get => string.Join("\n\n", _messages);
        }

        #endregion
    }
}
