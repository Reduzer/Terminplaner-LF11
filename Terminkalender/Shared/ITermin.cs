using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	public abstract class ATermin
	{
		public string sName { get; protected set; }
		public DateTime oStartDate { get; protected set; }
		public DateTime oEndDate { get; protected set; }

		public ATermin(string sName)
		{
			this.sName = sName;
		}

		public IEnumerable<object> GetGuests()
		{
		
		}
	}
}
