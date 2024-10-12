using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataBase_project
{
    internal class Medication
    {

        SqlConnection conn;
        public Medication()
        {

            string connString = "Server= localhost; Database= FCAI_2nd_project; Integrated Security=True;";

            this.conn= new SqlConnection(connString);
        }


        public void run()
        {
            // table Room

            conn.Open();
            try
            {


                Console.WriteLine("Enter 1 to insert");
                Console.WriteLine("Enter 2 to update");
                Console.WriteLine("Enter 3 to delete");
                Console.WriteLine("Enter 4 to select");
                Console.WriteLine("Enter 0 to exit");

                int n = int.Parse(Console.ReadLine());

                while (n != 0)
                {
                    switch (n)
                    {
                        case 1:
                            insertMedication();
                            break;
                        case 2:
                            updateMedication();
                            break;
                        case 3:
                            DeleteMedication();
                            break;
                        case 4:
                            Select select = new Select();
                            select.ApplySelect("MEDICATION");
                            break;
                        default:
                            Console.WriteLine("Entar a valid number!!!");
                            break;
                    }
                    Console.WriteLine("Enter 1 to insert");
                    Console.WriteLine("Enter 2 to update");
                    Console.WriteLine("Enter 3 to delete");
                    Console.WriteLine("Enter 4 to select");
                    Console.WriteLine("Enter 0 to exit");

                    n = int.Parse(Console.ReadLine());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();
        }



        void insertMedication()
            {
                var MEDICATIONID = 0;
                var NAME = "M";
                var AMOUNT = 3;
                var FREQUENCY = 30;
                var DESCRIPTION = "CAIRO";


                string sqlQueryInsert =
                                    "INSERT INTO dbo.MEDICATION(id,NAME, AMOUNT, FREQUENCY, DESCRIPTION) VALUES (@MEDICATIONID,@NAME, @AMOUNT, @FREQUENCY, @DESCRIPTION)";

                SqlCommand command = new SqlCommand(sqlQueryInsert, conn);
                command.Parameters.AddWithValue("@MEDICATIONID", MEDICATIONID);
                command.Parameters.AddWithValue("@NAME", NAME);
                command.Parameters.AddWithValue("@AMOUNT", AMOUNT);
                command.Parameters.AddWithValue("@FREQUENCY", FREQUENCY);
                command.Parameters.AddWithValue("@DESCRIPTION", DESCRIPTION);
                command.ExecuteNonQuery();
            }

        void DeleteMedication()
            {

                int MedicationID = 0;
                string sqlQueryInsert =
                                    "DELETE FROM dbo.MEDICATION WHERE id = " + MedicationID + ';';
                ;
                using (SqlCommand command = new SqlCommand(sqlQueryInsert, conn))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected + " row(s) deleted");
                }
            }

        void updateMedication()
            {
            var MedicationID = 0;
            var name = "M";
            var amount = 80;

            string sqlQueryUpdate =
                    "UPDATE dbo.MEDICATION SET NAME = '" + name + "'," +
                    "AMOUNT = '" + amount + "' WHERE id = " + MedicationID + ";";

                using (SqlCommand command = new SqlCommand(sqlQueryUpdate, conn))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected + " row(s) updated");
                }
            }

    }
}
