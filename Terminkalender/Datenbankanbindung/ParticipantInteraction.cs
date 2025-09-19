using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datenbankanbindung
{
	internal class ParticipantInteraction
	{
		private SqlConnectionStringBuilder m_oConnectionString;
		
		internal ParticipantInteraction(SqlConnectionStringBuilder oBuilderString)
		{
			this.m_oConnectionString = oBuilderString;
		}

	}
}
