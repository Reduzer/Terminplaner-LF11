namespace Shared
{
	public class Participant
	{
		public long nID { get; set; }
		public string? sName { get; set; }

		public Participant(string sName)
		{
			this.sName = sName;
		}
	}
}
