using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    public abstract class Character
    {
		#region Fields

		protected int _id;
		protected string _name;
		protected int _locationId;
		protected int _age;
		protected GenderType _gender;
		protected RaceType _race;

		#endregion

		#region Properties

		/// <summary>
		/// ID of Character
		/// </summary>
		public int Id
		{
			get => _id;
			set
			{
				_id = value;
			}
		}

		/// <summary>
		/// Name of Character
		/// </summary>
		public string Name
		{
			get => _name;
			set
			{
				_name = value;
			}
		}

		/// <summary>
		/// Location ID of Character
		/// </summary>
		public int LocationId
		{
			get => _locationId;
			set
			{
				_locationId = value;
			}
		}

		/// <summary>
		/// Age of Character
		/// </summary>
		public int Age
		{
			get => _age;
			set 
			{
				_age = value;
			}
		}

		/// <summary>
		/// Race of Character
		/// </summary>
		public RaceType Race
		{
			get { return _race; }
			set { _race = value; }
		}

		/// <summary>
		/// Gender of Character
		/// </summary>
		public GenderType Gender
		{
			get { return _gender; }
			set { _gender = value; }
		}

		#endregion

		#region Enums

		/// <summary>
		/// Race Enum
		/// </summary>
		public enum RaceType
		{
			Nungari,
			Diolecian,
			Draggaru,
			Plenskolt
		}

		/// <summary>
		/// Gender Enum
		/// </summary>
		public enum GenderType
		{
			Male,
			Female,
			Nonbinary
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Public Constructor for Character Class
		/// </summary>
		public Character()
		{

		}

		/// <summary>
		/// Public Constructor for Character Class (Overload)
		/// </summary>
		/// <param name="id">ID of Character</param>
		/// <param name="locationId">Location ID of Character</param>
		/// <param name="name">Name of Character</param>
		/// <param name="age">Age of Character</param>
		/// <param name="race">Race of Character</param>
		/// <param name="gender">Gender of Character</param>
		public Character(int id, int locationId, string name, int age, RaceType race, GenderType gender)
		{
			_id = id;
			_locationId = locationId;
			_name = name;
			_age = age;
			_race = race;
			_gender = gender;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Default Greeting for Character
		/// </summary>
		/// <returns>Returns Default Greeting for Character</returns>
		public virtual string Greeting()
		{
			return $"Hello, I am {_name} and I am {_age} years old. I am a {_race}.";
		}

		/// <summary>
		/// Abstract Method for if a Character has a quest
		/// </summary>
		/// <returns>Returns True or False if the Character has a quest</returns>
		public abstract bool HasQuest();

		#endregion
	}
}
