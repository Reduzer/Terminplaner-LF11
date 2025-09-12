using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	public abstract class ATermin
	{
		public string sName { get; protected set; }
		public DateTime oStartDate { get; protected set; }
		public DateTime oEndDate { get; protected set; }
		public string sLocation { get; protected set; }
		public List<Participant> voParticipants { get; protected set; }


		public ATermin(string sName)
		{
			this.sName = sName;
		}

		public void ChangeStartDate(DateTime oStartDate)
		{
		
		}

		public void ChangeEndDate()
		{
			
		}

		public IEnumerable<object> GetGuests()
		{
		
		}
	}
}
