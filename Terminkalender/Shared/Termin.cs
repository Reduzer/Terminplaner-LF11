using System.Drawing;

namespace Shared
{
	public class Termin
	{
		public long nID { get; set; }
		public string? sName { get; protected set; }
		public DateOnly oStartDate { get; protected set; }
		public DateOnly oEndDate { get; protected set; }
		public TimeOnly oStarTime { get; protected set; }
		public TimeOnly oEndTime { get; protected set; }
		public string? sLocation { get; protected set; }
		public List<long> vnParticipants { get; protected set; }
		public bool bIsRepeating { get; protected set; }
		public short? nRepititionInterval { get; protected set; }
		public string? sNameForRepitition;

		public Termin(){ }

		public Termin(string sName, DateOnly oStartDate, DateOnly oEndDate, TimeOnly oStartTime, TimeOnly oEndTime, string sLocation, List<Participant> voParticipants, bool bIsRepeating, short nRepetition, string sNameForRepetition)
		{
			this.sName = sName;
			this.oStartDate = oStartDate;
			this.oEndDate = oEndDate;
			this.oStarTime = oStartTime;
			this.oEndTime = oEndTime;
			this.sLocation = sLocation;
			this.bIsRepeating = bIsRepeating;
			this.nRepititionInterval = nRepetition;
			this.sNameForRepitition = sNameForRepetition;

			this.vnParticipants = new List<long>();

			foreach (Participant oParticipant in voParticipants) {
				vnParticipants.Add(oParticipant.nID);
			}
		}
	}
}
