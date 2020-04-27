using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using Elarya.Models;
using Elarya.Presentation.Views;

namespace Elarya.Presentation.ViewModels
{
    public class ElaryaGameViewModel : ObservableObject
    {

        #region Fields

        private Location _currentLocation, _northLocation, _eastLocation, _southLocation, _westLocation;
        private TimeSpan _gameTime;
        private DateTime _gameStartTime;
        private string _gameTimeDisplay;
        private string _currentMessage;

        private Npc _currentNpc;

        #endregion

        #region Properties

        /// <summary>
        /// Gets and sets the player
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// Gets and sets the gamemap
        /// </summary>
        public Map GameMap { get; set; }

        /// <summary>
        /// Gets and Sets the Current Message
        /// </summary>
        public string CurrentMessage
        {
            get => _currentMessage;
            set
            {
                _currentMessage = value;
                OnPropertyChanged(nameof(CurrentMessage));
            }
        }

        /// <summary>
        /// Gets and sets the current location
        /// </summary>
        public Location CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;
                _currentMessage = _currentLocation.Description;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentMessage));
            }
        }

        /// <summary>
        /// Gets the Message to Display
        /// </summary>
        public string MessageDisplay => _currentLocation.Messages;

        /// <summary>
        /// Gets and sets the north location (relative)
        /// </summary>
        public Location NorthLocation
        {
            get => _northLocation;
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(NorthLocation));
                OnPropertyChanged(nameof(HasNorthLocation));
            }
        }

        /// <summary>
        /// Gets and sets the east location (relative)
        /// </summary>
        public Location EastLocation
        {
            get => _eastLocation;
            set
            {
                _eastLocation = value;
                OnPropertyChanged(nameof(EastLocation));
                OnPropertyChanged(nameof(HasEastLocation));
            }
        }

        /// <summary>
        /// Gets and sets the south location (relative)
        /// </summary>
        public Location SouthLocation
        {
            get => _southLocation;
            set
            {
                _southLocation = value;
                OnPropertyChanged(nameof(SouthLocation));
                OnPropertyChanged(nameof(HasSouthLocation));
            }
        }

        /// <summary>
        /// Gets and sets the west location (relative)
        /// </summary>
        public Location WestLocation
        {
            get => _westLocation;
            set
            {
                _westLocation = value;
                OnPropertyChanged(nameof(WestLocation));
                OnPropertyChanged(nameof(HasWestLocation));
            }
        }

        /// <summary>
        /// Checks if a north location exists
        /// </summary>
        public bool HasNorthLocation => NorthLocation != null;

        /// <summary>
        /// Checks if an east location exists
        /// </summary>
        public bool HasEastLocation => EastLocation != null;

        /// <summary>
        /// Checks if a south location exists
        /// </summary>
        public bool HasSouthLocation => SouthLocation != null;

        /// <summary>
        /// Checks if a west location exists
        /// </summary>
        public bool HasWestLocation => WestLocation != null;

        /// <summary>
        /// Gets and sets the GameTime Display ticker
        /// </summary>
        public string GameTimeDisplay
        {
            get => _gameTimeDisplay;
            set
            {
                _gameTimeDisplay = value;
                OnPropertyChanged(nameof(GameTimeDisplay));
            }
        }

        /// <summary>
        /// Gets and Sets the Current Game Item
        /// </summary>
        public GameItemQuantity CurrentGameItem { get; set; }

        /// <summary>
        /// Gets and Sets the Current NPC
        /// </summary>
        public Npc CurrentNpc
        {
            get => _currentNpc;
            set
            {
                _currentNpc = value;
                OnPropertyChanged(nameof(CurrentNpc));
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for the game
        /// </summary>
        /// <param name="player"></param>
        /// <param name="gameMap"></param>
        /// <param name="mapCoordinates"></param>
        public ElaryaGameViewModel(Player player, Map gameMap, MapCoordinates mapCoordinates)
        {
            Player = player;
            GameMap = gameMap;
            GameMap.CurrentLocationCoords = mapCoordinates;
            _currentLocation = GameMap.CurrentLocation;
            _currentMessage = _currentLocation.Description;
            InitializeView();
            BackgroundMusic();
            GameTimer();

        }

        #endregion

        #region Methods

        #region Music

        /// <summary>
        /// Creates the Sound player for background music and loops it
        /// </summary>
        private static void BackgroundMusic()
        {
            var backgroundMusic = new SoundPlayer("Presentation/Resources/Assets/Sounds/background.wav");
            backgroundMusic.Load();
            backgroundMusic.PlayLooping();
        }

        #endregion

        /// <summary>
        /// Initializes the timer and locations available
        /// </summary>
        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
            UpdateAvailableTravelPoints();
            Player.UpdateInventory();
            Player.CalcWealth();
        }

        #region Move Methods

        /// <summary>
        /// Updates the available travel points for a given area on the map
        /// </summary>
        private void UpdateAvailableTravelPoints()
        {

            NorthLocation = null;
            EastLocation = null;
            SouthLocation = null;
            WestLocation = null;

            if (GameMap.NorthLocation() != null)
            {
                var nextNorthLocation = GameMap.NorthLocation();
                if (nextNorthLocation.Accessible || PlayerCanAccessLocation(nextNorthLocation))
                {
                    NorthLocation = nextNorthLocation;
                }
            }

            if (GameMap.EastLocation() != null)
            {
                var nextEastLocation = GameMap.EastLocation();
                if (nextEastLocation.Accessible || PlayerCanAccessLocation(nextEastLocation))
                {
                    EastLocation = nextEastLocation;
                }
            }

            if (GameMap.SouthLocation() != null)
            {
                var nextSouthLocation = GameMap.SouthLocation();
                if (nextSouthLocation.Accessible || PlayerCanAccessLocation(nextSouthLocation))
                {
                    SouthLocation = nextSouthLocation;
                }
            }

            if (GameMap.WestLocation() == null) return;
            var nextWestLocation = GameMap.WestLocation();
            if (nextWestLocation.Accessible || PlayerCanAccessLocation(nextWestLocation))
            {
                WestLocation = nextWestLocation;
            }
        }

        /// <summary>
        /// If a north location exists, the player can move north
        /// </summary>
        public void MoveNorth()
        {
            if (!HasNorthLocation) return;
            GameMap.CanMoveNorth();
            CurrentLocation = GameMap.CurrentLocation;
            UpdateAvailableTravelPoints();
            PlayerMove();
            Player.UpdateQuestStatus();
        }

        /// <summary>
        /// If an east location exists, the player can move east
        /// </summary>
        public void MoveEast()
        {
            if (!HasEastLocation) return;
            GameMap.CanMoveEast();
            CurrentLocation = GameMap.CurrentLocation;
            UpdateAvailableTravelPoints();
            PlayerMove();
            Player.UpdateQuestStatus();
        }

        /// <summary>
        /// If a south location exists, the player can move south
        /// </summary>
        public void MoveSouth()
        {
            if (!HasSouthLocation) return;
            GameMap.CanMoveSouth();
            CurrentLocation = GameMap.CurrentLocation;
            UpdateAvailableTravelPoints();
            PlayerMove();
            Player.UpdateQuestStatus();
        }

        /// <summary>
        /// If a west location exists, the player can move west
        /// </summary>
        public void MoveWest()
        {
            if (!HasWestLocation) return;
            GameMap.CanMoveWest();
            CurrentLocation = GameMap.CurrentLocation;
            UpdateAvailableTravelPoints();
            PlayerMove();
            Player.UpdateQuestStatus();
        }

        /// <summary>
        /// Checks if Player can access a location
        /// </summary>
        /// <param name="nextLocation"></param>
        /// <returns></returns>
        private bool PlayerCanAccessLocation(Location nextLocation)
        {
            return nextLocation.IsAccessibleByExperience(Player.Experience);
        }

        /// <summary>
        /// Updates Player stats based on location
        /// </summary>
        private void PlayerMove()
        {
            if (Player.HasVisited(_currentLocation)) return;
            Player.LocationsVisited.Add(_currentLocation);
            Player.Health += _currentLocation.ModifyHealth;
            Player.Life += _currentLocation.ModifyLives;
            Player.MageSkill += _currentLocation.MageSkill;
            Player.HealerSkill += _currentLocation.HealerSkill;
            Player.Experience += _currentLocation.ExperienceGain;
            if (Player.Life == 0)
            {
                OnPlayerDies("Oh no, you have run out of lives!");
            }
            OnPropertyChanged(nameof(MessageDisplay));
        }

        #endregion

        #region Game Timer
        /// <summary>
        /// Initializes the Game Timer
        /// </summary>
        public void GameTimer()
        {
            var timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(1000)};
            timer.Tick += OnGameTimerTick;
            timer.Start();
        }

        /// <summary>
        /// Initializes the Game Timer Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGameTimerTick(object sender, EventArgs e)
        {
            _gameTime = DateTime.Now - _gameStartTime;
            GameTimeDisplay = _gameTime.ToString(@"hh\:mm\:ss");
        }

        #endregion

        #region Inventory Methods

        /// <summary>
        /// Add a new item to the players inventory
        /// </summary>
        public void AddItemToInventory()
        {
            if (CurrentGameItem == null || !_currentLocation.GameItems.Contains(CurrentGameItem)) return;
            var selectedGameItemQuantity = CurrentGameItem;

            _currentLocation.RemoveGameItemQuantityFromLocation(selectedGameItemQuantity, selectedGameItemQuantity.Quantity);
            Player.AddGameItemQuantityToInventory(selectedGameItemQuantity, selectedGameItemQuantity.Quantity);

            OnPlayerPickUp(selectedGameItemQuantity);
        }

        /// <summary>
        /// Remove item from the players inventory
        /// </summary>
        public void RemoveItemFromInventory()
        {
            if (CurrentGameItem == null) return;
            var selectedGameItemQuantity = CurrentGameItem;

            _currentLocation.AddGameItemQuantityToLocation(selectedGameItemQuantity);
            Player.RemoveGameItemQuantityFromInventory(selectedGameItemQuantity);

            OnPlayerPutDown(selectedGameItemQuantity);
        }

        /// <summary>
        /// Process events when a player picks up a new game item
        /// </summary>
        /// <param name="gameItemQuantity">new game item</param>
        private void OnPlayerPickUp(GameItemQuantity gameItemQuantity)
        {
            Player.Wealth += gameItemQuantity.GameItem.Value;
            Player.UpdateQuestStatus();
        }

        /// <summary>
        /// Recalculates player wealth after dropping an item
        /// </summary>
        /// <param name="gameItemQuantity">new game item</param>
        private void OnPlayerPutDown(GameItemQuantity gameItemQuantity)
        {
            Player.Wealth -= gameItemQuantity.GameItem.Value;
        }

        /// <summary>
        /// Try to use an item in the players inventory
        /// </summary>
        public void OnUseGameItem()
        {
            try
            {
                switch (CurrentGameItem.GameItem)
                {
                    case Potion potion:
                        ProcessPotionUse(potion);
                        break;
                    case Treasure treasure:
                        ProcessTreasure(treasure);
                        break;
                    case Food food:
                        ProcessFood(food);
                        break;
                    case Clothes clothes:
                        ProcessClothes(clothes);
                        break;
                    case Spell spell:
                        ProcessSpell(spell);
                        break;
                }
            }
            catch (NullReferenceException)
            {
                CurrentMessage = "Sorry, there is no use for that!";
            }
        }

        /// <summary>
        /// Process the effects of using the potion
        /// </summary>
        /// <param name="potion">potion</param>
        private void ProcessPotionUse(Potion potion)
        {
            CurrentMessage = potion.UseMessage;

            Player.Health += potion.HealthChange;
            Player.Life += potion.LivesChange;
            Player.MageSkill += potion.MageSkillChange;
            Player.HealerSkill += potion.HealerSkillChange;
            Player.Experience += potion.ExperienceGain;
            Player.Mana += potion.ManaChange;
            Player.RemoveGameItemQuantityFromInventory(CurrentGameItem);
            Player.Wealth -= potion.Value;

        }

        /// <summary>
        /// Process the use of Treasure
        /// </summary>
        /// <param name="treasure">treasure</param>
        private void ProcessTreasure(Treasure treasure)
        {
            if (treasure.Type == Treasure.TreasureType.Coin)
            {
                CurrentMessage = "You threw a coin to your Witcher!";
                Player.RemoveGameItemQuantityFromInventory(CurrentGameItem);
                Player.Wealth -= treasure.Value;
            }
            else
            {
                string message = GameMap.OpenLocationsByItem(treasure.Id);
                CurrentMessage = message;
                if (message != "The Item did nothing.")
                {
                    Player.RemoveGameItemQuantityFromInventory(CurrentGameItem);
                    Player.Wealth -= treasure.Value;
                }
                
            }
        }

        /// <summary>
        /// Process the Use of Spells
        /// </summary>
        /// <param name="spell">Selected Spell</param>
        private void ProcessSpell(Spell spell)
        {
            if (Player.Mana <= spell.ManaCost)
            {
                CurrentMessage = "You used too much magic and have died. Be more careful next time!";
                Player.Mana += 100;
                Player.Life--;
                if (Player.Life == 0)
                {
                    OnPlayerDies("Oh no, you have run out of lives!");
                }
            }
            else
            {
                string message = GameMap.OpenLocationsByItem(spell.Id);
                CurrentMessage = message;
                Player.RemoveGameItemQuantityFromInventory(CurrentGameItem);
                Player.Mana -= spell.ManaCost;
                Player.MageSkill += spell.MageSkillGain;
                Player.HealerSkill += spell.HealerSkillGain;
                Player.Wealth -= spell.Value;
            }
        }

        /// <summary>
        /// Process the use of Food
        /// </summary>
        /// <param name="food">food</param>
        private void ProcessFood(Food food)
        {
            CurrentMessage = food.UseMessage;
            Player.Health += food.HealthChange;
            Player.Mana += food.ManaChange;
            Player.RemoveGameItemQuantityFromInventory(CurrentGameItem);
            Player.Wealth -= food.Value;
        }

        /// <summary>
        /// Process the use of Clothes
        /// </summary>
        /// <param name="clothes">Selected Clothes Item</param>
        private void ProcessClothes(Clothes clothes)
        {
            CurrentMessage = clothes.UseMessage;
            Player.Experience += clothes.ExperienceGain;
            Player.MageSkill += clothes.MageSkillChange;
            Player.HealerSkill += clothes.HealerSkillChange;
            Player.RemoveGameItemQuantityFromInventory(CurrentGameItem);
            Player.Wealth -= clothes.Value;
        }

        #endregion

        #region NPC Actions

        /// <summary>
        /// handle the speak to event in the view
        /// </summary>
        public void OnPlayerTalkTo()
        {
            if (!(CurrentNpc is ISpeak)) return;
            var speakingNpc = CurrentNpc as ISpeak;
            CurrentMessage = speakingNpc.Speak();
            if (Player.HasTalkedTo(_currentNpc)) return;
            Player.NpcsTalkedTo.Add(_currentNpc);
            Player.NpcsEngaged.Add(_currentNpc);
            Player.MageSkill += _currentNpc.MageSkillGain;
            Player.HealerSkill += _currentNpc.HealerSkillGain;
            Player.UpdateQuestStatus();
            OnPropertyChanged(nameof(MessageDisplay));
        }

        /// <summary>
        /// Buy Items from an NPC
        /// </summary>
        public void BuyItem()
        {
            if (CurrentGameItem != null && _currentNpc.GameItems.Contains(CurrentGameItem))
            {
                GameItemQuantity selectGameItemQuantity = CurrentGameItem;
                if (Player.PayMerchant(selectGameItemQuantity.GameItem.Value))
                {
                    Player.AddGameItemQuantityToInventory(selectGameItemQuantity, 1);
                    _currentNpc.RemoveGameItemQuantityFromInventory(selectGameItemQuantity);
                    OnPlayerPutDown(selectGameItemQuantity);
                }
                else
                {
                    CurrentMessage = "Sorry, you do not have enough Nocti Quarks for that!";
                }

            }
        }

        /// <summary>
        /// Buy Items from an NPC
        /// </summary>
        public void SellItem()
        {
            if (CurrentGameItem != null && _currentNpc is Merchant && Player.Inventory.Contains(CurrentGameItem))
            {
                GameItemQuantity selectGameItemQuantity = CurrentGameItem;
                Player.RemoveGameItemQuantityFromInventory(selectGameItemQuantity);
                Player.SellToMerchant(selectGameItemQuantity.GameItem.Value);
                OnPlayerPickUp(selectGameItemQuantity);
            }
        }

        #endregion

        #region FileMenuActions

        /// <summary>
        /// Resets the game
        /// </summary>
        public void ResetPlayer()
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Displays the Help Window
        /// </summary>
        public void Help()
        {
            var helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        /// <summary>
        /// player chooses to exit game
        /// </summary>
        public void QuitApplication()
        {
            Environment.Exit(0);
        }

        #endregion

        #region Quests

        /// <summary>
        /// Creates the Quest Travel Details Information
        /// </summary>
        /// <param name="quest">Quest</param>
        /// <returns>Returns Quest Travel Information</returns>
        private string GenerateQuestTravelDetail(QuestTravel quest)
        {
            var sb = new StringBuilder();
            sb.Clear();

            if (quest.Status != Quest.QuestStatus.Incomplete) return sb.ToString();
            sb.AppendLine("Locations yet to visit");
            foreach (var location in quest.LocationsNotCompleted(Player.LocationsVisited))
            {
                sb.Append(location.Name + ", ");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Creates the Quest Engage Details Information
        /// </summary>
        /// <param name="quest">Quest</param>
        /// <returns>Returns Quest Engage Information</returns>
        private string GenerateQuestEngageDetail(QuestEngage quest)
        {
            var sb = new StringBuilder();
            sb.Clear();

            if (quest.Status != Quest.QuestStatus.Incomplete) return sb.ToString();
            sb.AppendLine("NPC's yet to Engage");
            foreach (var npc in quest.NpcsNotEngaged(Player.NpcsEngaged))
            {
                sb.Append(npc.Name + ", ");
            }


            return sb.ToString();
        }

        /// <summary>
        /// Creates the Quest Gather Details Information
        /// </summary>
        /// <param name="quest">Quest</param>
        /// <returns>Returns Quest Gather Information</returns>
        private string GenerateQuestGatherDetail(QuestGather quest)
        {
            var sb = new StringBuilder();
            sb.Clear();

            if (quest.Status != Quest.QuestStatus.Incomplete) return sb.ToString();
            sb.AppendLine("Treasures yet to be found");
            foreach (var gameItemQuantity in quest.GameItemQuantitiesNotCompleted(Player.Inventory.ToList()))
            {
                var quantityInInventory = 0;
                var gameItemQuantityGathered =
                    Player.Inventory.FirstOrDefault(x => x.GameItem.Id == gameItemQuantity.GameItem.Id);
                if (gameItemQuantityGathered != null)
                {
                    quantityInInventory = gameItemQuantityGathered.Quantity;
                }

                sb.Append(Tab + gameItemQuantity.GameItem.Name);
                sb.AppendLine($" ({gameItemQuantity.Quantity - quantityInInventory})");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Create the Quest Status Information
        /// </summary>
        /// <returns>Returns Quest Status Information</returns>
        private string GenerateQuestStatusInformation()
        {
            double totalQuests = Player.Quests.Count;
            double questsCompleted = Player.Quests.Count(q => q.Status == Quest.QuestStatus.Complete);

            var percentQuestsCompleted = (int)((questsCompleted / totalQuests) * 100);
            var questStatusInformation = $"Quests Complete: {percentQuestsCompleted}%" + NewLine;

            if (percentQuestsCompleted == 0)
            {
                questStatusInformation +=
                    "Looks like you are just starting on your journey of self discovery! Best of luck.";
            }
            else if (percentQuestsCompleted <= 33)
            {
                questStatusInformation += "Looks like you completed at least one of your quests! Congrats. Keep at it though, there are more things to be discovered";
            }
            else if (percentQuestsCompleted <= 66)
            {
                questStatusInformation += "Great job so far! Only one more quest to go. Keep at it!";
            }
            else if (percentQuestsCompleted == 100)
            {
                questStatusInformation +=
                    "Congratulations! You have completed all the quests. Whichever Skill rank is higher, is the skill that you have in society!";
            }

            return questStatusInformation;
        }

        /// <summary>
        /// Initializes Quest Status View Model
        /// </summary>
        /// <returns>Returns Quest Status View Model</returns>
        private QuestStatusViewModel InitializeQuestStatusViewModel()
        {
            var questStatusViewModel = new QuestStatusViewModel
            {
                QuestInformation = GenerateQuestStatusInformation(), Quests = new List<Quest>(Player.Quests)
            };


            foreach (var quest in questStatusViewModel.Quests)
            {
                switch (quest)
                {
                    case QuestTravel travel:
                        travel.StatusDetail = GenerateQuestTravelDetail(travel);
                        break;
                    case QuestEngage engage:
                        engage.StatusDetail = GenerateQuestEngageDetail(engage);
                        break;
                    case QuestGather gather:
                        gather.StatusDetail = GenerateQuestGatherDetail(gather);
                        break;
                }
            }

            return questStatusViewModel;
        }

        /// <summary>
        /// Opens the Quest Status Window
        /// </summary>
        public void QuestWindow()
        {
            var questStatus = new QuestStatusView(InitializeQuestStatusViewModel());
            questStatus.Show();
        }

        #region Constants

        private const string Tab = "\t";
        private const string NewLine = "\n";

        #endregion


        #endregion

        #region Player Win/Lose

        /// <summary>
        /// Handles Player Death
        /// </summary>
        /// <param name="message">Message to display on death!</param>
        private void OnPlayerDies(string message)
        {
            var messagetext = message +
                              "\n\nWould you like to play again?";

            var titleText = "Death";
            const MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    ResetPlayer();
                    break;
                case MessageBoxResult.No:
                    QuitApplication();
                    break;
            }
        }

        #endregion

        #endregion

    }
}
