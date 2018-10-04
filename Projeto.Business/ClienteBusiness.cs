using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Repository.Entities;
using Projeto.Repository.Persistence;

namespace Projeto.Business
{
    public class ClienteBusiness
    {
        private ClienteRepository repository;

        public ClienteBusiness()
        {
            repository = new ClienteRepository();
        }

        public void Cadastrar(Cliente c)
        {
            repository.Insert(c);
        }

        public void Atualizar(Cliente c)
        {
            repository.Update(c);
        }

        public void Excluir(int idCliente)
        {
            repository.Delete(idCliente);
        }

        public List<Cliente> ConsultarTodos()
        {
            return repository.FindAll();
        }

        public Cliente ConsultarPorId(int idCliente)
        {
            return repository.FindById(idCliente);
        }
            
           
    }
}
