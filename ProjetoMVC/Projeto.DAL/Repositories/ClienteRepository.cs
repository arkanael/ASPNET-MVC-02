using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.DAL.DataContext;
using System.Data.SqlClient;

namespace Projeto.DAL.Repositories
{
    /// <summary>
    /// Classe para acessar a base de dados na tabela de cliente
    /// </summary>
    public class ClienteRepository : Context
    {
        /// <summary>
        /// Método para inserir um cliente na base de dados
        /// </summary>
        /// <param name="cliente"></param>
        public void Insert(Cliente cliente)
        {
            try
            {
                OpenConnection();

                string query = "Insert into Cliente(RazaoSocial, NomeFantasia, CNPJ, InscricaoEstadual, Email, Site, Telefone, Status) values(@RazaoSocial, @NomeFantasia, @CNPJ, @InscricaoEstadual, @Email, @Site, @Telefone, @Status)";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@RazaoSocial", cliente.RazaoSocial);
                cmd.Parameters.AddWithValue("@NomeFantasia", cliente.NomeFantasia);
                cmd.Parameters.AddWithValue("@CNPJ", cliente.CNPJ);
                cmd.Parameters.AddWithValue("@InscricaoEstadual", cliente.InscricaoEstadual);
                cmd.Parameters.AddWithValue("@Email", cliente.Email);
                cmd.Parameters.AddWithValue("@Site", cliente.Site);
                cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                cmd.Parameters.AddWithValue("@Status", cliente.Status.ToString());

                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception("Houve um erro ao cadastrar o cliente na base de dados: "+ erro.Message);
            }
            finally
            {
                CloseConnection();
            }

        }

        /// <summary>
        /// Método para verificar se já existe um cnpj cadastrado na base de dados.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns>true or false</returns>
        public bool HasCNPJ(string cnpj)
        {
            try
            {
                OpenConnection();
                string query = "select count(CNPJ) from Cliente where CNPJ = @cnpj";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CNPJ", cnpj);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
            catch (Exception erro)
            {
                throw new Exception("Houve um erro ao verificar se o CNPJ estava cadastrado na base de dados: " + erro.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<Cliente> FindAll()
        {
            try
            {
                OpenConnection();
                string query = "select RazaoSocial, NomeFantasia, CNPJ, InscricaoEstadual, Email, Site, Telefone, Status from Cliente;";

                cmd = new SqlCommand(query, con);

                dr = cmd.ExecuteReader();

                List<Cliente> lista = new List<Cliente>();

                while (dr.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                    cliente.RazaoSocial = Convert.ToString(dr["RazaoSocial"]);
                    cliente.NomeFantasia = Convert.ToString(dr["NomeFantazia"]);
                    cliente.CNPJ = Convert.ToString(dr["CNPJ"]);
                    cliente.InscricaoEstadual = Convert.ToString(dr["InscricaoEstadual"]);
                    cliente.Email = Convert.ToString(dr["Email"]);
                    cliente.Site = Convert.ToString(dr["Site"]);
                    cliente.Telefone = Convert.ToString(dr["Telefone"]);
                    cliente.Status = (Status) Enum.Parse(typeof(Status), Convert.ToString(dr["Status"]));

                    lista.Add(cliente);

                }

                return lista;

            }
            catch (Exception erro)
            {
                throw new Exception("Houve um erro ao obter a listagem de clientes cadastrados na base de dados: " + erro.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
