using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities; //entidades..
using System.Data.Entity.ModelConfiguration; //mapeamento..

namespace Projeto.DAL.Mappings
{
    //Classe de mapeamento da entidade Cliente
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        //construtor..
        public ClienteMap()
        {
            //nome da tabela..
            ToTable("Cliente");

            //chave primária..
            HasKey(c => c.IdCliente);

            //campos..
            Property(c => c.IdCliente)
                .HasColumnName("IdCliente");

            Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.Email)
                .HasColumnName("Email")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
