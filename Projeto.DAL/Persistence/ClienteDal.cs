using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //entityframework..
using Projeto.Entities; //entidades..
using Projeto.DAL.DataSource; //conexão..

namespace Projeto.DAL.Persistence
{
    public class ClienteDal
    {
        public void Insert(Cliente c)
        {
            using (Conexao con = new Conexao())
            {
                con.Entry(c).State = EntityState.Added; //inserindo..
                con.SaveChanges(); //executando..
            }
        }

        public void Update(Cliente c)
        {
            using (Conexao con = new Conexao())
            {
                con.Entry(c).State = EntityState.Modified; //atualizando..
                con.SaveChanges(); //executando..
            }
        }

        public void Delete(Cliente c)
        {
            using (Conexao con = new Conexao())
            {
                con.Entry(c).State = EntityState.Deleted; //excluindo..
                con.SaveChanges(); //executando..
            }
        }

        public List<Cliente> FindAll()
        {
            using (Conexao con = new Conexao())
            {
                return con.Cliente.ToList();
            }
        }

        public Cliente FindById(int idCliente)
        {
            using (Conexao con = new Conexao())
            {
                return con.Cliente.Find(idCliente);
            }
        }

    }
}
