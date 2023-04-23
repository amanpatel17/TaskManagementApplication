using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace task4._0
{
    internal class AddDb
    {
        DataBase db = new DataBase();
        public bool insertusertask(string task_name, DateTime date , MemoryStream picture, string description , string category)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `usertask`( `task_name`, `date`, `picture` , `description`, `category`) VALUES (@tn,@date,@pic , @dscp, @cat)", db.getConnection);

           // command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@tn", MySqlDbType.VarChar).Value = task_name;
           command.Parameters.Add("@date", MySqlDbType.Date).Value = date; 
            command.Parameters.Add("@pic", MySqlDbType.Blob).Value = picture.ToArray();
            command.Parameters.Add("@dscp", MySqlDbType.VarChar).Value = description;
            command.Parameters.Add("@cat", MySqlDbType.VarChar).Value = category;

            db.openconnection();

            if(command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }


        }


        //status form data show 

        public DataTable getStatus(MySqlCommand command)
        {

            command.Connection = db.getConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }

       
        public bool updateusertask(int id , string task_name, DateTime date, MemoryStream picture, string description, string category)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `usertask` SET `task_name`=@tn,`date`=@date,`picture`=@pic,`description`=@dscp,`category`=@cat WHERE `id` = @ID", db.getConnection);

            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@tn", MySqlDbType.VarChar).Value = task_name;
            command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
            command.Parameters.Add("@pic", MySqlDbType.Blob).Value = picture.ToArray();
            command.Parameters.Add("@dscp", MySqlDbType.VarChar).Value = description;
            command.Parameters.Add("@cat", MySqlDbType.VarChar).Value = category;

            db.openconnection();



            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }

        }

        // delete fun 

        public bool deleteusertask(int id)

        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `usertask` WHERE `id` = @del",  db.getConnection);

            command.Parameters.Add("@del", MySqlDbType.Int32).Value = id;

            db.openconnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }

        }

        internal bool delusertask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
