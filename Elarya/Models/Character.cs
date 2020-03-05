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

		public int Id
		{
			get => _id;
			set
			{
				_id = value;
			}
		}

		public string Name
		{
			get => _name;
			set
			{
				_name = value;
			}
		}

		public int LocationId
		{
			get => _locationId;
			set
			{
				_locationId = value;
			}
		}

		public int Age
		{
			get => _age;
			set 
			{
				_age = value;
			}
		}

		public RaceType Race
		{
			get { return _race; }
			set { _race = value; }
		}


		public GenderType Gender
		{
			get { return _gender; }
			set { _gender = value; }
		}

		#endregion

		#region Enums

		public enum RaceType
		{
			Nungari,
			Diolecian,
			Draggaru,
			Plenskolt
		}

		public enum GenderType
		{
			Male,
			Female,
			Nonbinary
		}

		#endregion

		#region Constructor

		public Character()
		{

		}

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

		public virtual string Greeting()
		{
			return $"Hello, I am {_name} and I am {_age} years old. I am a {_race}.";
		}

		public abstract bool HasQuest();

		#endregion
	}
}
