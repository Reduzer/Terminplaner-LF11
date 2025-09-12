using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	public class Participant
	{
		public string sName { get; private set; }
		
		public Participant (string sName)
		{
			this.sName = sName;
		}
	}
}
