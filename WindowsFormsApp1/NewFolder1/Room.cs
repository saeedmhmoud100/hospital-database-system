using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataBase_project
{
    internal class Room
    {

        SqlConnection conn;
        public  Room()
        {

            string connString = "Server= localhost; Database= FCAI_2nd_project; Integrated Security=True;";

            this.conn= new SqlConnection(connString);
        }

        public void insertRoom(int ROOMID,string roomType,string roomLocation)
            {
            conn.Open();
                string sqlQueryInsert =
                                    "INSERT INTO dbo.ROOM(id,ROOM_TYPE, LOCATION) VALUES (@ROOMID,@ROOM_TYPE, @LOCATION)";

                SqlCommand command = new SqlCommand(sqlQueryInsert, conn);
                command.Parameters.AddWithValue("@ROOM_TYPE", roomType);
                command.Parameters.AddWithValue("@LOCATION", roomLocation);
                command.Parameters.AddWithValue("@ROOMID", ROOMID);
                command.ExecuteNonQuery();
            conn.Close();

            }

        public void DeleteRoom(int roomID)
            {
            conn.Open();
                string sqlQueryInsert =
                                    "DELETE FROM dbo.ROOM WHERE id = " + roomID + ';';
                ;
                using (SqlCommand command = new SqlCommand(sqlQueryInsert, conn))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected + " row(s) deleted");
                }
                conn.Close() ;
            }

        public void updateRoom(int ROOMID, string roomType, string roomLocation)
        {
                conn.Open() ;
                string sqlQueryUpdate =
                    "UPDATE dbo.ROOM SET ROOM_TYPE = '" + roomType + "'," +
                    "LOCATION = '" + roomLocation + "' WHERE id = " + ROOMID + ";";

                using (SqlCommand command = new SqlCommand(sqlQueryUpdate, conn))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected + " row(s) updated");
                }

                conn.Close() ;
            }
    }
}
