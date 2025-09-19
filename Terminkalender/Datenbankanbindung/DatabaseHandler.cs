namespace Datenbankanbindung
{
	public class DatabaseHandler
	{
		private static DatabaseHandler instance;

		private DatabaseHandler()
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
	}
}
