using Projeto.DAL.Repositories;
using Projeto.Entities;
using Projeto.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.WEB.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        /// <summary>
        /// Método para responder a requisção ajax do JQUERY
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult CadastrarCliente(ClienteCadastroViewModel model)
        {
            try
            {
               

                ClienteRepository repository = new ClienteRepository();

                Cliente cliente = new Cliente();
                cliente.RazaoSocial = model.RazaoSocial;
                cliente.NomeFantasia = model.NomeFantasia;
                cliente.CNPJ = model.CNPJ;
                cliente.InscricaoEstadual = model.InscricaoEstadual;
                cliente.Email = model.Email;
                cliente.Site = model.Site;
                cliente.Telefone = model.Telefone;
                cliente.Status = model.Status;

                repository.Insert(cliente);

                return Json($"Cliente {cliente.RazaoSocial} cadastrado com sucesso");
            }
            catch (Exception erro)
            {
                return Json($" erro ao tentar cadastrar cliente." + erro.Message);
            }
        }
        // GET: Cliente/Consulta
        public ActionResult Consulta()
        {
            return View();
        }

        /// <summary>
        /// Método para responder a requisção ajax do JQUERY
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ConsultarCliente()
        {
            try
            {
                List<ClienteConsultaViewModel> lista = new List<ClienteConsultaViewModel>();

                ClienteRepository repository = new ClienteRepository();

                foreach (Cliente cliente in repository.FindAll())
                {
                    ClienteConsultaViewModel model = new ClienteConsultaViewModel();

                    model.IdCliente = cliente.IdCliente;
                    model.RazaoSocial = cliente.RazaoSocial;
                    model.NomeFantasia = cliente.NomeFantasia;
                    model.CNPJ = cliente.CNPJ;
                    model.InscricaoEstadual = cliente.InscricaoEstadual;
                    model.Email = cliente.Email;
                    model.Site = cliente.Site;
                    model.Telefone = cliente.Telefone;
                    model.Status = cliente.Status.ToString();

                    lista.Add(model);
                }

                ///<summary>
                ///JsonRequestBehavior.AllowGet permit que o método responda uma requisição GET
                /// </summary>
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
    }
}