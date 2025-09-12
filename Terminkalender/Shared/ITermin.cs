using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	public abstract class ATermin
	{
		protected string sName;

		public string GetName()
		{
		
		}
		public IEnumerable<object> GetGuests();
	}
}
