using System.Drawing;

namespace Shared
{
	public class Termin
	{
		public long nID { get; set; }
		public string? sName { get; protected set; }
		public string sStartDate { get; protected set; }
		public string sEndDate { get; protected set; }
		public string sStartTime { get; protected set; }
		public string sEndTime { get; protected set; }
		public string? sLocation { get; protected set; }
		public List<long> vnParticipants { get; protected set; }
		public bool bIsRepeating { get; protected set; }
		public short? nRepititionInterval { get; protected set; }
		public string? sNameForRepitition;
		public string? sDescription { get; protected set; }

		public Termin(){ }

		public Termin(string sName, string oStartDate, string oEndDate, string oStartTime, string oEndTime, string sLocation, List<long> vnParticipants, bool bIsRepeating, short nRepetition, string sNameForRepetition, string sDescription)
		{
			this.sName = sName;
			this.sStartDate = oStartDate;
			this.sEndDate = oEndDate;
			this.sStartTime = oStartTime;
			this.sEndTime = oEndTime;
			this.sLocation = sLocation;
			this.bIsRepeating = bIsRepeating;
			this.nRepititionInterval = nRepetition;
			this.sNameForRepitition = sNameForRepetition;
			this.sDescription = sDescription;

			this.vnParticipants = vnParticipants;
		}
	}
}
