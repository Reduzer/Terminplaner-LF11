using Microsoft.Data.SqlClient;
using Shared;

namespace Datenbankanbindung
{
	public class DatabaseHandler
	{
		private static DatabaseHandler instance;

		private SqlConnectionStringBuilder m_oBuilder;
		private TerminInteraction m_oTermineInteraction;
		private ParticipantInteraction m_oParticipantInteraction;

		private DatabaseHandler()
		{
			Init();

			m_oTermineInteraction = new TerminInteraction(m_oBuilder.ConnectionString);
			m_oParticipantInteraction = new ParticipantInteraction(m_oBuilder);
		}

//TODO: FILL INFO FOR LOCAL SQLLITE DB
		private void Init()
		{
			m_oBuilder = new SqlConnectionStringBuilder{
				DataSource = "",
				UserID = "",
				Password = "",
				InitialCatalog = ""
			};

			SetupDatabase();
		}

		private void SetupDatabase()
		{
		
		}

		public static DatabaseHandler Instance
		{
			get{
				if(instance == null){
					instance = new DatabaseHandler();
				}

				return instance;
			}
		}

		public Tuple<bool, long> CreateTermin(Termin oTermin)
		{
			bool bResult = false;
			long nID = -1;

			Tuple<bool, long> tbnResult = new Tuple<bool, long>(bResult, nID);
			return tbnResult;
		}

		public Termin GetTerminByID(long nID)
		{
			return null;
		}

		public List<Termin> GetAllTermine()
		{
			return null;
		}

		public Termin UpdateTermin(Termin oTermin)
		{
			return null;
		}

		public bool DeleteTermin(long nID)
		{
			return false;
		}
	}
}
