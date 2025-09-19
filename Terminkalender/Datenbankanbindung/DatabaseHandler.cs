using Microsoft.Data.SqlClient;
using Shared;

namespace Datenbankanbindung
{
	public class DatabaseHandler
	{
		private const string c_sDatabaseName = "TerminCalender_LF11";
		private const string c_sConenctionStringForDatabaseChecking = "server=(local)\\SQLEXPRESS;Trusted_Connection=yes";
		private const string c_sCreateDatabaseString = "SELECT database_id FROM sys.databases WHERE Name = '{0}'";

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

//TODO: FILL INFO FOR LOCAL MSSQL DB
		private void Init()
		{
			m_oBuilder = new SqlConnectionStringBuilder{
				DataSource = c_sDatabaseName,
				UserID = "TESTUSER",
				Password = "TESTPASSWORD",
			};

			SetupDatabase();
		}

		private void SetupDatabase()
		{
			bool bSuccessChecking = false;
			string sSqlCommand = string.Format(c_sCreateDatabaseString, c_sDatabaseName);

			using(SqlConnection oConnection = new SqlConnection(c_sConenctionStringForDatabaseChecking)){
				using(SqlCommand oCommand = new SqlCommand(sSqlCommand, oConnection)){
					oConnection.Open();

					object oResult = oCommand.ExecuteScalar();
					
					if(!(oResult == null)){
						bSuccessChecking = true;
					}

					oConnection.Close();
				}
			}

			//Check for existing database otherwise create the database and two tables
			if (!bSuccessChecking /*Database does not exist*/) {
				//Create

			}
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
