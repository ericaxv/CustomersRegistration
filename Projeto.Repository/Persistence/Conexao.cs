using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Projeto.Repository.Persistence
{
   public class Conexao
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlTransaction tr;

        public void OpenConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["aula"].ConnectionString);
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
        }
    }
}
