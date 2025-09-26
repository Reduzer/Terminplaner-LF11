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

		public IEnumerable<Participant> GetParticipant()
		{
			IEnumerable<Participant> voParticipants = _context.Participants;

			return voParticipants;
		}

		public Participant GetByID(long nID)
		{
			Participant oParticipant = _context.Participants.Where(e => e.nID == nID).FirstOrDefault();

			return oParticipant;
		}

		public Participant AddParticipant(Participant oParticipant)
		{
			EntityEntry<Participant> oEntry = _context.Participants.Add(oParticipant);
			
			_context.SaveChanges();

			return oEntry.Entity;
		}

		public Participant UpdateParticipant(Participant oParticipant)
		{
			EntityEntry<Participant> oEntry = _context.Participants.Update(oParticipant);

			_context.SaveChanges();

			return oEntry.Entity;
		}

		public bool DeleteParticipant(long nID)
		{
			bool bResult = false;

			Participant oParticipant = GetByID(nID);

			_context.Participants.Remove(oParticipant);

			if (GetByID(nID) == null) {
				bResult = true;
			}

			_context.SaveChanges();

			return bResult;
		}
	}
}
