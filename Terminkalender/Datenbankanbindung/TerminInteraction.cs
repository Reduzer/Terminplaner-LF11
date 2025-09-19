using Microsoft.Data.SqlClient;
using Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datenbankanbindung
{
	internal class TerminInteraction
	{
		private const string c_sCreationString = @"INSERT INTO Termine.Termine (Name, Guid, CreationDate, StartDate, EndDate, Location, Participants, Color, IsRepeating, RepititionInterval, NameForRepitition) VALUES (@)";
		private const string c_sUpdateString = @"";
		private const string c_sDeleteString = @"";
		private const string c_sGetAllString = @"";
		private const string c_sGetByIDString = @"";
		
		private string m_oConnectionString;

		internal TerminInteraction(string oBuilderString)
		{
			this.m_oConnectionString = oBuilderString;
		}

		internal long CreateTermin(Termin oTerminToCreate)
		{
			long nID = -1;
			Guid RuntimeGUIDForCreation = Guid.NewGuid();

			using(SqlConnection oConnection = new SqlConnection(m_oConnectionString)){
				using(SqlCommand oCommand = new SqlCommand(c_sCreationString, oConnection)){
					oCommand.Parameters.Add("Name", System.Data.SqlDbType.Text).Value = oTerminToCreate.sName;
					oCommand.Parameters.Add("GUID", System.Data.SqlDbType.Text).Value = RuntimeGUIDForCreation.ToString();
					oCommand.Parameters.Add("CreationDate", System.Data.SqlDbType.DateTime).Value = System.DateTime.Now;
					oCommand.Parameters.Add("StartDate", System.Data.SqlDbType.DateTime).Value = oTerminToCreate.oStartDate;
					oCommand.Parameters.Add("EndDate", System.Data.SqlDbType.DateTime).Value = oTerminToCreate.oEndDate;
					oCommand.Parameters.Add("Location", System.Data.SqlDbType.Text).Value = oTerminToCreate.sLocation;
					oCommand.Parameters.Add("Participants", System.Data.SqlDbType.BigInt).Value = oTerminToCreate.voParticipants;
					oCommand.Parameters.Add("Color", System.Data.SqlDbType.Text).Value = oTerminToCreate.oColor.ToString();
					oCommand.Parameters.Add("IsRepeating", System.Data.SqlDbType.Bit).Value = oTerminToCreate.bIsRepeating;
					oCommand.Parameters.Add("RepititionInterval", System.Data.SqlDbType.Int).Value = oTerminToCreate.nRepititionInterval;
					oCommand.Parameters.Add("NameForRepitition", System.Data.SqlDbType.Text).Value = oTerminToCreate.sNameForRepitition;

					try{
						oConnection.Open();
						int nRowsEffected = oCommand.ExecuteNonQuery();

						if(nRowsEffected > 0){ 
							nID = GetTerminIDByGUID(RuntimeGUIDForCreation);
						} else {
							throw new Exception("No rows where effected");
						}

					} catch (Exception e){
//Logging the Exception with date, time, oject data, etc.
						Debug.WriteLine(e.Message);						
					}

					oConnection.Close();
				}
			}

			return nID;
		}

		private long GetTerminIDByGUID(Guid oGuid)
		{
			
		}

		internal Termin GetTerminByID(long nID)
		{
		
		}

		internal List<Termin> GetAllTermine()
		{
			
		}

	}
}
