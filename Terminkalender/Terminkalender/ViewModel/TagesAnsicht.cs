using Datenbankanbindung;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminkalender.ViewModel
{
	public class TagesAnsicht
	{
		private RepositoryHandler oRepoHandler;

		public TagesAnsicht(RepositoryHandler oRepoHandler)
		{
			this.oRepoHandler = oRepoHandler;
		}

	}
}
