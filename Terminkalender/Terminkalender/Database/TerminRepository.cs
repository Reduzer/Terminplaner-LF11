using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;

namespace Datenbankanbindung
{
	public class TerminRepository
	{
		private TerminVerwalterContext _context;

		public TerminRepository(TerminVerwalterContext oContext)
		{
			this._context = oContext;
		}

		public IEnumerable<Termin> GetTermine()
		{
			IEnumerable<Termin> voTermine = _context.Termine;

			return voTermine;
		}

		public Termin GetByID(long nID)
		{
			Termin oTermin = _context.Termine.Where(e => e.nID == nID).FirstOrDefault();

			return oTermin;
		}

		public Termin AddTermin(Termin termine)
		{
			EntityEntry<Termin> oEntry = _context.Termine.Add(termine);
			_context.SaveChanges();
			return oEntry.Entity;
		}

		public Termin UpdateTermin(Termin termine)
		{
			EntityEntry<Termin> oEntry = _context.Termine.Update(termine);
			_context.SaveChanges();
			return oEntry.Entity;
		}

		public bool DeleteTermin(long nID)
		{
			bool bResult = false;

			Termin oTermin = GetByID(nID);

			_context.Termine.Remove(oTermin);

			if (GetByID(nID) == null) {
				bResult = true;
			}

			_context.SaveChanges();

			return bResult;
		}
	}
}
