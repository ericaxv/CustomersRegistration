using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Presentation.Models;
using Projeto.Business;
using Projeto.Repository.Entities;


namespace Projeto.Presentation.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteBusiness business;

        public ClienteController()
        {
            business = new ClienteBusiness();
        }

        // GET: Cliente
        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Consulta()
        {
            var lista = ObterConsultadeClientes();

            return View(lista);
        }

        private List<ClienteConsultaViewModel> ObterConsultadeClientes()
        {
            var lista = new List<ClienteConsultaViewModel>();

            foreach (Cliente c in business.ConsultarTodos())
            {
                var model = new ClienteConsultaViewModel();

                model.IdCliente = c.IdCliente;
                model.Nome = c.Nome;
                model.Email = c.Email;


                lista.Add(model);
            }

            return lista;
        }

        [HttpPost]
        public ActionResult CadastrarCliente(ClienteCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cliente c = new Cliente();
                    c.Nome = model.Nome;
                    c.Email = model.Email;

                    business.Cadastrar(c);

                    ViewBag.Mensagem = $"Cliente {c.Nome} cadastrado com sucesso.";

                    ModelState.Clear();

                }

                catch (Exception e)
                {
                    ViewBag.Mensagem = "Ocorreu um erro" + e.Message;
                }
            }

            return View("Cadastro");
        }

        public ActionResult Edicao(int id)
        {
            var model = new ClienteEdicaoViewModel();

            try
            {
                Cliente c = business.ConsultarPorId(id);
                model.IdCliente = c.IdCliente;
                model.Nome = c.Nome;
                model.Email = c.Email;


            }
            catch (Exception e)
            {
                ViewBag.Mensagem = "Erro: " + e.Message;
            }

            return View(model);
        }

        public ActionResult Exclusao(int id)
        {
            var model = new ClienteExclusaoViewModel();

            try
            {
                Cliente c = business.ConsultarPorId(id);

                model.IdCliente = c.IdCliente;
                model.Nome = c.Nome;
                model.Email = c.Email;

            }
            catch (Exception e)
            {
                ViewBag.mensagem = "Erro: " + e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AtualizarCliente(ClienteEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cliente c = new Cliente();
                    c.IdCliente = model.IdCliente;
                    c.Nome = model.Nome;
                    c.Email = model.Email;

                    business.Atualizar(c);

                    ViewBag.Mensagem = $"Cliente {c.Nome} atualizado com sucesso.";

                    ModelState.Clear();

                }

                catch (Exception e)
                {
                    ViewBag.Mensagem = "Ocorreu um erro" + e.Message;
                }
            }

            return View("Edicao");
        }
        [HttpPost]
        public ActionResult ExcluirCliente(ClienteExclusaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    business.Excluir(model.IdCliente);

                    ViewBag.Mensagem = $"Cliente excluído com sucesso.";

                }

                catch (Exception e)
                {
                    ViewBag.Mensagem = "Ocorreu um erro" + e.Message;
                }
            }

            var lista = ObterConsultadeClientes();
            return View("Consulta", lista);
        }
    }
}