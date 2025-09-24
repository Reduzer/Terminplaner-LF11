using Datenbankanbindung;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminkalender.ViewModel.Interfaces
{
	public interface IRepositoryHandler
	{
		public TerminRepository Termin();
		public ParticipantRepository Participant();
	}
}
