using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ServicioWebRest.Areas.API.Models
{
    public class ClientManager
    {
        String str = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Clients.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

        public bool insertClient(Client cli)
        {
            SqlConnection con = new SqlConnection(str);

            con.Open();

            string sql = "INSERT INTO Clients (Name, Surname, Age) VALUES (@name, @surname, @age)";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value =cli.Name;
            cmd.Parameters.Add("@surname", System.Data.SqlDbType.VarChar).Value = cli.Surname;
            cmd.Parameters.Add("@age", System.Data.SqlDbType.VarChar).Value = cli.Age;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res==1);

        }

        public List<Client> getClients()
        {
            List<Client> list = new List<Client>();

            SqlConnection con = new SqlConnection(str);

            con.Open();

            string sql = "SELECT _id,Name,Surname,Age FROM Clients";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(
                    new Client(reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetInt32(3)));
            }

            reader.Close();

            return list;
        }

        public Client getClient(int ID)
        {
            Client cli = new Client();

            SqlConnection con = new SqlConnection(str);

            con.Open();

            string sql = "SELECT _id,Name,Surname,Age FROM Clients WHERE _id=@id";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;

            SqlDataReader reader =
                  cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            if (reader.Read())
            {
                cli = new Client(reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetInt32(3));

            }

            reader.Close();

            return cli;
        }

        public bool updateClient(Client cli)
        {
            SqlConnection con = new SqlConnection(str);

            con.Open();

            string sql = "UPDATE Clients SET Name=@name, Surname=@surname, Age=@age WHERE _id=@id";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = cli.ID;
            cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = cli.Name;
            cmd.Parameters.Add("@surname", System.Data.SqlDbType.VarChar).Value = cli.Surname;
            cmd.Parameters.Add("@age", System.Data.SqlDbType.VarChar).Value = cli.Age;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public bool deleteClient(int ID)
        {
            SqlConnection con = new SqlConnection(str);

            con.Open();

            string sql = "DELETE FROM Clients WHERE _id=@id";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = ID;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public ClientManager()
        { }
    }
}