using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; //connectionstring..
using System.Data.Entity; //entityframework..
using Projeto.Entities; //entidades..
using Projeto.DAL.Mappings; //mapeamento..

namespace Projeto.DAL.DataSource
{
    //Regra 1) Classe de Conexão HERDAR DbContext
    public class Conexao : DbContext
    {
        //Regra 2) Construtor que envie para o DbContext a connectionstring..
        public Conexao()
            : base(ConfigurationManager.ConnectionStrings["aula"].ConnectionString)
        {

        }

        //Regra 3) Sobrescrever o método OnModelCreating..
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
        }

        //Regra 4) Declarar um DbSet para cada classe de entidade (LAMBDA)
        public DbSet<Cliente> Cliente { get; set; }
    }   

}
