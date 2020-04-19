using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    public class Location
    {
        #region Fields

        private int _id;
		private string _name;
		private string _description;
		private string _messages;
		private bool _accessible;

		#endregion

		#region Properties

		/// <summary>
		/// Location ID
		/// </summary>
		public int ID
		{
			get => _id;
			set
			{
				_id = value;
			}
		}

		/// <summary>
		/// Location Name
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
		/// Location Description
		/// </summary>
		public string Description
		{
			get => _description;
			set
			{
				_description = value;
			}
		}

		public string Messages 
		{ get => _messages;
			set 
			{
				_messages = value;
			}
		}

		/// <summary>
		/// Is Location Accessible?
		/// </summary>
		public bool Accessible
		{
			get => _accessible;
			set
			{
				_accessible = value;
			}
		}

		#endregion
	}
}
