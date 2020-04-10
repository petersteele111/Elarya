using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elarya.Models
{
    class Map
    {
		private string[,] _location;

		public string[,] Location
		{
			get { return _location; }
			set { _location = value; }
		}

	}
}
