﻿//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       timop
//       Andrew Webster <arw7@students.calvin.edu>
//
// Copyright 2004-2011 by OM International
//
// This file is part of OpenPetra.org.
//
// OpenPetra.org is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// OpenPetra.org is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.Data;
using System.Data.Odbc;
using Ict.Common;
using Ict.Common.DB;
using Ict.Common.Data;
using Ict.Common.Verification;
using Ict.Petra.Shared.MReporting;
using Ict.Petra.Server.MPartner.Extracts;

namespace Ict.Petra.Server.MPartner.queries
{
    /// <summary>
    /// this creates the query for extracts of partners by special types
    /// </summary>
    public class QueryPartnerBySpecialType
    {
        /// <summary>
        /// calculate an extract from a report: all partners of a given type (or selection of multiple types)
        /// </summary>
        /// <param name="AParameters"></param>
        /// <param name="AResults"></param>
        /// <returns></returns>
        public static bool CalculateExtract(TParameterList AParameters, TResultList AResults)
        {
            // get the partner keys from the database
            try
            {
//                TLogging.Log( "Name of the SPECIAL TYPE Extract: " + AParameters.Get("nameOfExtract"));
//                TLogging.Log( "Description of the SPECIAL TYPE Extract: " + AParameters.Get("descriptionOfExtract"));
//                TLogging.Log( "ARW LOG: Parameters received: \n\t" +
////                             AParameters.Get("param_city") + "\n\t" +
////                             AParameters.Get("param_from") + "\n\t" +
////                             AParameters.Get("param_to") + "\n\t" +
////                             AParameters.Get("param_region") + "\n\t" +
////                             AParameters.Get("param_country") + "\n\t" +
////                             AParameters.Get("param_dateSet") + "\n\t" +
//                             "param_active: "+ AParameters.Get("param_active").ToString() + ".\n\t" +
//                             "param_mailingOnly: "+ AParameters.Get("param_mailingAddressesOnly") + ".\n\t" +
//                             "param_familiesOnly: "+ AParameters.Get("param_familiesOnly") + ".\n\t" +
//                             "param_excludeNoSolicitations: "+ AParameters.Get("param_excludeNoSolicitations") + ".\n\t" +
//                             "param_explicit_specialtypes: "+ AParameters.Get("param_explicit_specialtypes"));
                Boolean ReturnValue = false;
                Boolean NewTransaction;
                TDBTransaction Transaction = DBAccess.GDBAccessObj.GetNewOrExistingTransaction(IsolationLevel.Serializable, out NewTransaction);
                string SqlStmt = TDataBase.ReadSqlFile("Partner.Queries.ExtractByPartnerSpecialType.sql");
                int Index = 0;
                int SizeOfArray;
                String ValueList;
                String ListValue;
                String ParameterList = "";

                // set array to correct size depending on number of specialtypes selected
                ValueList = AParameters.Get("param_explicit_specialtypes").ToString();
                SizeOfArray = StringHelper.CountOccurencesOfChar(ValueList, ',') + 1;

                OdbcParameter[] parameters = new OdbcParameter[SizeOfArray + 5];
//                TLogging.Log("parameters[] created...");
                // this *should* always have at least one selection because the client requires it
                ListValue = StringHelper.GetNextCSV(ref ValueList, ",");

                if (ListValue.Length == 0)
                {
                    throw new NoNullAllowedException("At least one option must be checked.");                       // safety
                }

                Index = 0;

                // this will determine how many ?'s to put in the SQL query and then insert the values pulled out of the CSV list
                while (ListValue != "")
                {
                    parameters[Index] = new OdbcParameter("specialtype" + Index.ToString(), OdbcType.VarChar);
                    parameters[Index].Value = ListValue;
                    Index++;

                    if (ParameterList.Length == 0)
                    {
                        ParameterList = "?";
                    }
                    else
                    {
                        ParameterList = ParameterList + ",?";
                    }

                    ListValue = StringHelper.GetNextCSV(ref ValueList, ",");
                }

                SqlStmt = SqlStmt.Replace("##ParameterList##", ParameterList);
                // reading in parameters and getting them ready to be inserted into the query
                parameters[Index + 1] = new OdbcParameter("Date", OdbcType.Date);
                parameters[Index + 1].Value = AParameters.Get("param_dateSet").ToDate();
                parameters[Index] = new OdbcParameter("param_dateFieldsIncluded", OdbcType.Bit);

                if (parameters[Index + 1].Value == null)  // if a date has not been supplied
                {
                    parameters[Index].Value = false;
                }
                else // if there is a date supplied, we want to use it
                {
                    parameters[Index].Value = true;
                }

                parameters[Index + 2] = new OdbcParameter("param_active", OdbcType.Bit);
                parameters[Index + 2].Value = AParameters.Get("param_active").ToBool();
                parameters[Index + 3] = new OdbcParameter("param_familiesOnly", OdbcType.Bit);
                parameters[Index + 3].Value = AParameters.Get("param_familiesOnly").ToBool();
                parameters[Index + 4] = new OdbcParameter("param_excludeNoSolicitations", OdbcType.Bit);
                parameters[Index + 4].Value = AParameters.Get("param_excludeNoSolicitations").ToBool();

                TLogging.Log("getting the data from the database", TLoggingType.ToStatusBar);
                DataTable partnerkeys = DBAccess.GDBAccessObj.SelectDT(SqlStmt, "partners", Transaction, parameters);

                if (NewTransaction)
                {
                    DBAccess.GDBAccessObj.RollbackTransaction();
                }

                // if this is taking a long time, every now and again update the TLogging statusbar, and check for the cancel button
                // TODO: we might need to add this functionality to TExtractsHandling.CreateExtractFromListOfPartnerKeys as well???
                if (AParameters.Get("CancelReportCalculation").ToBool() == true)
                {
                    return false;
                }

                TLogging.Log("preparing the extract", TLoggingType.ToStatusBar);

                TVerificationResultCollection VerificationResult;
                int NewExtractID;

                // create an extract with the given name in the parameters
                ReturnValue = TExtractsHandling.CreateExtractFromListOfPartnerKeys(
                    AParameters.Get("nameOfExtract").ToString(),
                    AParameters.Get("descriptionOfExtract").ToString(),
                    out NewExtractID,
                    out VerificationResult,
                    partnerkeys,
                    0);

                if (ReturnValue)
                {
                    DBAccess.GDBAccessObj.CommitTransaction();
                }
                else
                {
                    DBAccess.GDBAccessObj.RollbackTransaction();
                }

                return ReturnValue;
            }
            catch (Exception)
            {
//                TLogging.Log(e.ToString());
                DBAccess.GDBAccessObj.RollbackTransaction();
                return false;
            }
        }
    }
}