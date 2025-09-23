using System.Drawing;

namespace Shared
{
	public class Termin
	{
		public string sName { get; protected set; }
		public DateTime oStartDate { get; protected set; }
		public DateTime oEndDate { get; protected set; }
		public string sLocation { get; protected set; }
		public List<Participant> voParticipants { get; protected set; }
		public Color oColor { get; private set; }
		public bool bIsRepeating { get; protected set; }
		public short? nRepititionInterval { get; protected set; }
		public string? sNameForRepitition;

		public Termin(DateTime oStartDateTime, DateOnly oStartDate) 
		{
			this.oStartDate = oStartDateTime;
		}

		public Termin(string sName, DateTime oStartDate, DateTime oEndDate, string sLocation, List<Participant> voParticipants, Color oColor, bool bIsRepeating ,short nRepetition, string sNameForRepetition)
		{
			this.sName = sName;
			this.oStartDate = oStartDate;
			this.oEndDate = oEndDate;
			this.sLocation = sLocation;
			this.voParticipants = voParticipants;
			this.oColor = oColor;
			this.bIsRepeating = bIsRepeating;
			this.nRepititionInterval = nRepetition;
			this.sNameForRepitition = sNameForRepetition;
		}
	}
}
