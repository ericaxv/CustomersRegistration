using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Projeto.Repository.Entities;

namespace Projeto.Repository.Persistence
{
   public class ClienteRepository : Conexao
    {
        public void Insert(Cliente c)
        {
            OpenConnection();
            string query = "Insert into Cliente (Nome, Email)" + "values(@Nome, @Email)";

            cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public void Update(Cliente c)
        {
            OpenConnection();

            string query = "update Cliente set Nome = @Nome, Email = @Email where IdCliente = @IdCliente";

            cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@IdCliente", c.IdCliente);
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Email", c.Email);
            cmd.ExecuteNonQuery();


            CloseConnection();

        }

        public void Delete(int idCliente)
        {
            OpenConnection();

            string query = "delete from Cliente where IdCliente = @IdCliente";

            cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Idcliente", idCliente);
            cmd.ExecuteNonQuery();

            CloseConnection();

        }

        public List<Cliente> FindAll()
        {
            OpenConnection();

            string query = "select * from Cliente";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Cliente> lista = new List<Cliente>();

            while (dr.Read())
            {
                Cliente c = new Cliente();

                c.IdCliente = Convert.ToInt32(dr["idCliente"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Email = Convert.ToString(dr["Email"]);

                lista.Add(c);
            }

            CloseConnection();
            return lista;
        }

        public Cliente FindById(int idCliente)
        {
            OpenConnection();

            string query = "select * from Cliente where IdCliente = @IdCliente";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdCliente", idCliente);
            dr = cmd.ExecuteReader();

            Cliente c = null;

            if(dr.Read())
            {
                c = new Cliente();
                c.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Email = Convert.ToString(dr["Email"]);

            }

            CloseConnection();
            return c;
        }
    }
}
