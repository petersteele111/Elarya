using System.Collections.Generic;

namespace Elarya.Models
{
    public class Map
    {

        #region Fields

        private readonly int _maxRows;
        private readonly int _maxColumns;

        #endregion

        #region Properties

        /// <summary>
        /// Sets and Gets All Locations
        /// </summary>
        public Location[,] Locations { get; set; }

        /// <summary>
		/// Gets Current Location on Map
		/// </summary>
		public MapCoordinates CurrentLocationCoords { get; set; }

        public Location CurrentLocation => Locations[CurrentLocationCoords.Row, CurrentLocationCoords.Column];

        public List<GameItem> StandardGameItems { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Public Constructor
        /// </summary>
        /// <param name="rows">Number of Rows for the Map</param>
        /// <param name="columns">Number of Columns for the Map</param>
        public Map(int rows, int columns)
        {
            _maxRows = rows;
            _maxColumns = columns;
            Locations = new Location[rows, columns];
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks to see if Player can move North
        /// </summary>
        /// <returns>Returns False if player cannot go North, True if they can</returns>
        public void CanMoveNorth()
        {
            if (CurrentLocationCoords.Row > 0)
            {
                CurrentLocationCoords.Row -= 1;
            }
        }

        /// <summary>
        /// Checks to see if Player can move East
        /// </summary>
        /// <returns>Returns False if player cannot go East, True if they can</returns>
        public void CanMoveEast()
        {
            if (CurrentLocationCoords.Column < _maxColumns - 1)
            {
                CurrentLocationCoords.Column += 1;
            }
        }

        /// <summary>
        /// Checks to see if Player can move South
        /// </summary>
        /// <returns>Returns False if player cannot go South, True if they can</returns>
        public void CanMoveSouth()
        {
            if (CurrentLocationCoords.Row < _maxRows - 1)
            {
                CurrentLocationCoords.Row += 1;
            }
        }

        /// <summary>
        /// Checks to see if Player can move West
        /// </summary>
        /// <returns>Returns False if player cannot go West, True if they can</returns>
        public void CanMoveWest()
        {
            if (CurrentLocationCoords.Column > 0)
            {
                CurrentLocationCoords.Column -= 1;
            }
        }

        /// <summary>
        /// Gets next North Location if available
        /// </summary>
        /// <returns>Returns next North location</returns>
        public Location NorthLocation()
        {
            Location northLocation = null;

            if (CurrentLocationCoords.Row <= 0) return null;
            var nextNorthLocation = Locations[CurrentLocationCoords.Row - 1, CurrentLocationCoords.Column];

            if (nextNorthLocation != null)
            {
                northLocation = nextNorthLocation;
            }

            return northLocation;
        }

        /// <summary>
        /// Gets next East Location if available
        /// </summary>
        /// <returns>Returns next East location</returns>
        public Location EastLocation()
        {
            Location eastLocation = null;

            if (CurrentLocationCoords.Column >= _maxColumns - 1) return null;
            var nextEastLocation = Locations[CurrentLocationCoords.Row, CurrentLocationCoords.Column + 1];
            if (nextEastLocation != null)
            {
                eastLocation = nextEastLocation;
            }

            return eastLocation;
        }

        /// <summary>
        /// Gets next South Location if available
        /// </summary>
        /// <returns>Returns next South location</returns>
        public Location SouthLocation()
        {
            Location southLocation = null;

            if (CurrentLocationCoords.Row >= _maxRows - 1) return null;
            var nextSouthLocation = Locations[CurrentLocationCoords.Row + 1, CurrentLocationCoords.Column];
            if (nextSouthLocation != null)
            {
                southLocation = nextSouthLocation;
            }

            return southLocation;
        }

        /// <summary>
        /// Gets next West Location if available
        /// </summary>
        /// <returns>Returns next West location</returns>
        public Location WestLocation()
        {
            Location westLocation = null;

            if (CurrentLocationCoords.Column <= 0) return null;
            var nextWestLocation = Locations[CurrentLocationCoords.Row, CurrentLocationCoords.Column - 1];
            if (nextWestLocation != null)
            {
                westLocation = nextWestLocation;
            }

            return westLocation;
        }


        /// <summary>
        /// Opens a given location based on a given Item
        /// </summary>
        /// <param name="itemId">Item to open location</param>
        /// <returns>Returns a message of success or not</returns>
        public string OpenLocationsByItem(int itemId)
        {
            var message = "The Item did nothing.";

            for (var row = 0; row < _maxRows; row++)
            {
                for (var column = 0; column < _maxColumns; column++)
                {
                    var mapLocation = Locations[row, column];

                    if (mapLocation == null || mapLocation.RequiredItem != itemId) continue;
                    mapLocation.Accessible = true;
                    message = $"{mapLocation.Name} is now accessible.";
                }
            }
            return message;
        }

        #endregion

    }
}
