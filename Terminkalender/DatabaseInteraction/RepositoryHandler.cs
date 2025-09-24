namespace Datenbankanbindung
{
	public class RepositoryHandler
	{
		private static RepositoryHandler instance;

		private ParticipantRepository m_oParticipantRepository;
		private TerminRepository m_oTerminRepository;

		private RepositoryHandler()
		{
			m_oParticipantRepository = new ParticipantRepository();
			m_oTerminRepository = new TerminRepository();
		}

		public static RepositoryHandler Instance
		{
			get
			{
				if (instance == null) {
					instance = new RepositoryHandler();
				}

				return instance;
			}
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
