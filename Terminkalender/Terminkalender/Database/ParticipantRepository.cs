using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;

namespace Datenbankanbindung
{
	public class ParticipantRepository
	{
		private TerminVerwalterContext _context;

		public ParticipantRepository(TerminVerwalterContext oContext)
		{
			_context = oContext;
		}

		public IEnumerable<Participant> GetTermine()
		{
			IEnumerable<Participant> voParticipants = _context.Participants;

			return voParticipants;
		}

		public Participant GetByID(long nID)
		{
			Participant oParticipant = _context.Participants.Where(e => e.nID == nID).FirstOrDefault();

			return oParticipant;
		}

		public Participant AddTermin(Participant oParticipant)
		{
			EntityEntry<Participant> oEntry = _context.Participants.Add(oParticipant);
			return oEntry.Entity;
		}

		public Participant UpdateTermin(Participant oParticipant)
		{
			EntityEntry<Participant> oEntry = _context.Participants.Update(oParticipant);
			return oEntry.Entity;
		}

		public bool DeleteTermin(long nID)
		{
			bool bResult = false;

			Participant oParticipant = GetByID(nID);

			_context.Participants.Remove(oParticipant);

			if (GetByID(nID) == null) {
				bResult = true;
			}
			return bResult;
		}
	}
}
