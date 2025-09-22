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
		public short? nRepititionInterval { get; protected set; }
		public string? sNameForRepitition;

		public Termin(string sName, DateTime oStartDate, DateTime oEndDate, List<Participant> voParticipants)
		{
			this.sName = sName;
			this.oStartDate = oStartDate;
			this.oEndDate = oEndDate;
			this.voParticipants = voParticipants;
		}

		public void SetColor(Color oColor)
		{
			this.oColor = oColor;
		}

		public void ChangeStartDate(DateTime oStartDate)
		{
			this.oStartDate = oStartDate;
		}

		public void ChangeEndDate(DateTime oEndDate)
		{
			this.oEndDate = oEndDate;
		}

		public void AddParticipant(Participant oToAdd)
		{
			voParticipants.Add(oToAdd);
		}

		public void RemoveParticipant(Participant oToRemove) 
		{ 
			voParticipants.Remove(oToRemove); 
		}
		
		public void ChangeName(string sName)
		{
			this.sName = sName;
		}


	}
}
