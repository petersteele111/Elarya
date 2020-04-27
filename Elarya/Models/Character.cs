namespace Elarya.Models
{
    public abstract class Character : ObservableObject
    {

        #region Properties

		/// <summary>
		/// ID of Character
		/// </summary>
		public int Id { get; set; }

        /// <summary>
		/// Name of Character
		/// </summary>
		public string Name { get; set; }

        /// <summary>
		/// Location ID of Character
		/// </summary>
		public int LocationId { get; set; }

        /// <summary>
		/// Age of Character
		/// </summary>
		public int Age { get; set; }

        /// <summary>
		/// Race of Character
		/// </summary>
		public RaceType Race { get; set; }

        /// <summary>
		/// Gender of Character
		/// </summary>
		public GenderType Gender { get; set; }

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
        protected Character()
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
        protected Character(int id, int locationId, string name, int age, RaceType race, GenderType gender)
		{
			Id = id;
			LocationId = locationId;
			Name = name;
			Age = age;
			Race = race;
			Gender = gender;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Default Greeting for Character
		/// </summary>
		/// <returns>Returns Default Greeting for Character</returns>
		public virtual string Greeting()
		{
			return $"Hello, I am {Name} and I am {Age} years old. I am a {Race}.";
		}

		/// <summary>
		/// Abstract Method for if a Character has a quest
		/// </summary>
		/// <returns>Returns True or False if the Character has a quest</returns>
		public abstract bool HasQuest();

		#endregion
	}
}
