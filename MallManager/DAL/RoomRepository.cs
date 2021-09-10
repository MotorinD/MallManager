using MallManager.Additional;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MallManager.DAL.Entities;

namespace MallManager.DAL
{
    public class RoomRepository : BaseRepository
    {
        public List<Room> GetList()
        {
            var res = new List<Room>();

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Room", connection);
                connection.Open();
                var adapter = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                res = ds.Tables[0].ToList<Room>();
            }

            return res;
        }

        public Room Get(int id)
        {
            var res = new Room();

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Room where Id = @id", connection);
                cmd.Parameters.AddWithValue("@id", id);

                connection.Open();
                var adapter = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                res = ds.Tables[0].ToList<Room>().FirstOrDefault();
            }

            return res;
        }

        public int Add(Room entity)
        {
            var id = 0;

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var cmd = new SqlCommand("INSERT INTO Room (Square, Type, Price, Description) OUTPUT INSERTED.Id VALUES(@square, @type, @price, @description)", connection);

                cmd.Parameters.AddWithValue("@square", entity.Square);
                cmd.Parameters.AddWithValue("@type", entity.Type);
                cmd.Parameters.AddWithValue("@price", entity.Price);
                cmd.Parameters.AddWithValue("@description", entity.Description);

                connection.Open();
                id = (int)cmd.ExecuteScalar();
                connection.Close();
            }

            return id;
        }

        public void Edit(Room entity)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var cmd = new SqlCommand("UPDATE Room Set Square = @square, Type =  @type, Price = @price, Description = description where Id = @id", connection);
                
                cmd.Parameters.AddWithValue("@id", entity.Id);
                cmd.Parameters.AddWithValue("@square", entity.Square);
                cmd.Parameters.AddWithValue("@type", entity.Type);
                cmd.Parameters.AddWithValue("@price", entity.Price);
                cmd.Parameters.AddWithValue("@description", entity.Description);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var cmd = new SqlCommand("Delete from Room where Id = @id", connection);

                cmd.Parameters.AddWithValue("@id", id);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}
