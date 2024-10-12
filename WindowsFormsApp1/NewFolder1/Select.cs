using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase_project
{

    internal class Select
    {

        SqlConnection conn;
        public Select()
        {
            string connString = "Server= localhost; Database= FCAI_2nd_project; Integrated Security=True;";

            this.conn = new SqlConnection(connString);
        }

        public DataTable run(string tableN)
        {
            // table Room


            try
            {


                int n = 0;
                List<string> tables;
                List<string> conditions;

                tables = new List<string>();
                conditions = new List<string>();
                if (tableN == "APPOINTMENT")
                {
                    tableN = "APPOINTMENT";
                    tables.Add("PATIENT");
                    tables.Add("DOCTOR");
                    conditions.Add("PATIENT.ID=APPOINTMENT.PATIENTID");
                    conditions.Add("DOCTOR.ID=APPOINTMENT.DOCTORID");
                };
                if (tableN == "DEPARTMENT")
                {

                    tableN = "DEPARTMENT";
                };
                if (tableN == "DIAGNOSIS")
                {

                    tableN = "DIAGNOSIS";
                };
                if (tableN == "DOCTOR")
                {
                    tableN = "DOCTOR";
                    tables.Add("DEPARTMENT");
                    conditions.Add("DEPARTMENT.ID = DOCTOR.DEPARTMENT_ID");

                };
                if (tableN == "MEDICAL_HISTORY")
                {
                    tableN = "MEDICAL_HISTORY";
                    tables.Add("PATIENT");
                    conditions.Add("MEDICAL_HISTORY.PATIENTID = PATIENT.ID");

                };
                if (tableN == "MEDICATION")
                {
                    tableN = "MEDICATION";

                };
                if (tableN == "NURSE")
                {
                    tableN = "NURSE";
                    tables.Add("DEPARTMENT");
                    conditions.Add("DEPARTMENT.ID = NURSE.DEPARTMENT_ID");

                };
                if (tableN == "PATIENT")
                {
                    tableN = "PATIENT";
                    tables.Add("ROOM");
                    conditions.Add("ROOM.ID = PATIENT.ROOMID");

                };
                if (tableN == "PATIENT_DIAGNOSIS")
                {
                    tableN = "PATIENT_DIAGNOSIS";
                    tables.Add("DIAGNOSIS");
                    conditions.Add("DIAGNOSIS.ID = PATIENT_DIAGNOSIS.DIAGNOSISID");

                };
                if (tableN == "PATIENT_TREATMENT")
                {
                    tableN = "PATIENT_TREATMENT";
                    tables.Add("TREATMENT");
                    conditions.Add("TREATMENT.ID = PATIENT_TREATMENT.TREATMENTID");

                };
                if (tableN == "PATIENTMEDICATION")
                {
                    tableN = "PATIENTMEDICATION";
                    tables.Add("PATIENT");
                    tables.Add("MEDICATION");
                    conditions.Add("PATIENT.ID = PATIENTMEDICATION.PATIENTID");
                    conditions.Add("MEDICATION.ID = PATIENTMEDICATION.MEDICATIONID");

                };
                if (tableN == "ROOM")
                {
                    tableN = "ROOM";
                };



                if (tableN == "TREATMENT")
                {
                    tableN = "TREATMENT";
                };





                if (tableN != null && tableN != "")
                {
                    return ApplySelectDataTable(tableN, tables, conditions);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
            return null;

        }


        public DataTable ApplySelectDataTable(string TableName, List<string> joinedTables = null, List<string> conditions = null)
        {
            conn.Open();
            string sqlQuerySelect = "SELECT * FROM dbo." + TableName;

            if (joinedTables != null && conditions != null)
            {
                for (int i = 0; i < joinedTables.Count; i++)
                {
                    sqlQuerySelect += " join " + joinedTables[i] + " on " + conditions[i];

                }
            }


            SqlCommand command = new SqlCommand(sqlQuerySelect, conn);

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }




        public List<string> ApplySelect(string TableName, List<string> joinedTables = null, List<string> conditions = null, int condID = -1)
        {
            conn.Open();
            string sqlQuerySelect = "SELECT * FROM dbo." + TableName;

            if (joinedTables != null && conditions != null)
            {
                for (int i = 0; i < joinedTables.Count; i++)
                {
                    sqlQuerySelect += " join " + joinedTables[i] + " on " + conditions[i];

                }
            }

            if (condID != -1)
            {
                sqlQuerySelect += " where id = " + condID;
            }

            SqlCommand command = new SqlCommand(sqlQuerySelect, conn);
            List<string> result = new List<string>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        result.Add(reader[i].ToString());
                    }

                }
            }
            conn.Close();

            return result;
        }

    }
}
