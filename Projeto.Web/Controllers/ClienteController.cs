using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Web.Models; //camada de modelo..
using Projeto.Entities; //entidades..
using Projeto.DAL.Persistence; //acesso a dados..

namespace Projeto.Web.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Cliente/Consulta
        public ActionResult Consulta()
        {
            return View();
        }

        public JsonResult CadastrarCliente(ClienteViewModelCadastro model)
        {
            System.Threading.Thread.Sleep(3000);

            try
            {
                Cliente c = new Cliente(); //entidade..
                c.Nome  = model.Nome;
                c.Email = model.Email;

                ClienteDal d = new ClienteDal(); //persistencia..
                d.Insert(c); //gravando..

                return Json("Cliente " + c.Nome + ", cadastrado com sucesso.");
            }
            catch(Exception e)
            {
                //retornar mensagem de erro..
                return Json(e.Message);
            }
        }

        public JsonResult ConsultarClientes()
        {
            try
            {
                ClienteDal d = new ClienteDal();

                //executando a consulta e enviando os dados para a página..
                return Json(d.FindAll()); //enviando a lista de Clientes..
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
        }


        public JsonResult ExcluirCliente(int id)
        {
            try
            {
                ClienteDal d = new ClienteDal();
                Cliente c = d.FindById(id); //buscar o cliente pelo id..

                //excluindo..
                d.Delete(c);

                return Json("Cliente " + c.Nome + ", excluido com sucesso.");
            }
            catch(Exception e)
            {
                return Json("Erro ao excluir Cliente: " + e.Message);
            }
        }


        public JsonResult AtualizarCliente(ClienteViewModelEdicao model)
        {
            try
            {
                Cliente c = new Cliente(); //entidade..
                c.IdCliente = model.IdCliente;
                c.Nome = model.Nome;
                c.Email = model.Email;

                ClienteDal d = new ClienteDal(); //persistencia..
                d.Update(c); //atualizando..

                return Json("Cliente " + c.Nome + ", atualizado com sucesso.");
            }
            catch(Exception e)
            {
                return Json("Erro ao atualizar Cliente: " + e.Message);
            }
        }

    }
}