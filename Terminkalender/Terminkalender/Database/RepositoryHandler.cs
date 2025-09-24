using Terminkalender;
using Terminkalender.ViewModel.Interfaces;

namespace Datenbankanbindung
{
	public class RepositoryHandler : IRepositoryHandler
	{
		private ParticipantRepository m_oParticipantRepository;
		private TerminRepository m_oTerminRepository;

		public RepositoryHandler(TerminVerwalterContext oContext)
		{
			m_oParticipantRepository = new ParticipantRepository(oContext);
			m_oTerminRepository = new TerminRepository(oContext);
		}

		public TerminRepository Termin()
		{
			return m_oTerminRepository;
		}

		public ParticipantRepository Participant()
		{
			return m_oParticipantRepository;
		}
	}
}
