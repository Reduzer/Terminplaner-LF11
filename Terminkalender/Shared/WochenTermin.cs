using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	public class WochenTermin : ITermin
	{
		private List<Termin> m_voTermineDerWoche;

		public WochenTermin()
		{
		
		}

		public void AddTermin(Termin oTermin)
		{
			m_voTermineDerWoche.Add(oTermin);
		}

		public IEnumerable<object> GetGuests()
		{
			throw new NotImplementedException();
		}

		public string GetName() 
		{
			
		}
	}
}
