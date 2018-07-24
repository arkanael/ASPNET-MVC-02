using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DAL.DataContext
{
    public class Context
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlTransaction tr;

        /// <summary>
        /// Método para abrir uma conexão com o banco de dadoss
        /// </summary>
        protected void OpenConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);
            con.Open();
        }

        /// <summary>
        /// Método para fechar a conexão com o banco de dadoss
        /// </summary>
        protected void CloseConnection()
        {
            con.Close();
        }
    }
}
