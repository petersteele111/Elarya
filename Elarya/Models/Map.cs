﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    class Map
    {
		#region Fields

		private Location[,] _locations;
		private MapCoordinates _currentLocationCoords;
		private int _maxRows, _maxColumns;

		#endregion

		#region Properties

		/// <summary>
		/// Sets and Gets All Locations
		/// </summary>
		public Location[,] Locations
		{
			get => _locations;
			set
			{
				_locations = value;
			}
		}

		/// <summary>
		/// Gets Current Location on Map
		/// </summary>
		public MapCoordinates CurrentLocationCoords
		{
			get => _currentLocationCoords;
		}

		public Location CurrentLocation
		{
			get => _locations[_currentLocationCoords.Row, _currentLocationCoords.Column];
		}

		#endregion

		/// <summary>
		/// Public Constructor
		/// </summary>
		/// <param name="rows">Number of Rows for the Map</param>
		/// <param name="columns">Number of Columns for the Map</param>
		public Map(int rows, int columns)
		{
			_maxRows = rows;
			_maxColumns = columns;
			_locations = new Location[rows, columns];
		}

		#region Methods

		/// <summary>
		/// Checks to see if Player can move North
		/// </summary>
		/// <returns>Returns False if player cannot go North, True if they can</returns>
		public bool canMoveNorth()
		{
			if (_currentLocationCoords.Row <= 0)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Checks to see if Player can move East
		/// </summary>
		/// <returns>Returns False if player cannot go East, True if they can</returns>
		public bool canMoveEast()
		{
			if (_currentLocationCoords.Column >= _maxColumns)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Checks to see if Player can move South
		/// </summary>
		/// <returns>Returns False if player cannot go South, True if they can</returns>
		public bool canMoveSouth()
		{
			if (_currentLocationCoords.Row >= _maxRows)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Checks to see if Player can move West
		/// </summary>
		/// <returns>Returns False if player cannot go West, True if they can</returns>
		public bool canMoveWest()
		{
			if (_currentLocationCoords.Column <= 0)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Gets next North Location if available
		/// </summary>
		/// <returns>Returns next North location</returns>
		public Location NorthLocation()
		{
			Location northLocation = null;

			if (canMoveNorth())
			{
				Location nextNorthLocation = _locations[_currentLocationCoords.Row - 1, _currentLocationCoords.Column];

				if (nextNorthLocation != null)
				{
					northLocation = nextNorthLocation;
				}
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

			if (canMoveEast())
			{
				Location nextEastLocation = _locations[_currentLocationCoords.Row, _currentLocationCoords.Column + 1];
				if (nextEastLocation != null)
				{
					eastLocation = nextEastLocation;
				}
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

			if (canMoveSouth())
			{
				Location nextSouthLocation = _locations[_currentLocationCoords.Row + 1, _currentLocationCoords.Column];
				if (nextSouthLocation != null)
				{
					southLocation = nextSouthLocation;
				}
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

			if (canMoveWest())
			{
				Location nextWestLocation = _locations[_currentLocationCoords.Row, _currentLocationCoords.Column - 1];
				if (nextWestLocation != null)
				{
					westLocation = nextWestLocation;
				}
			}

			return westLocation;
		}

		#endregion

	}
}
