using Microsoft.EntityFrameworkCore;
using WebApp2.Data;
using WebApp2.Models;

namespace WebApp2.Repository
{
    public class Repository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;
        public Repository(BancoContext context)
        {
           _bancoContext = context;
        }
       public  Contato Create(Contato contato)
        {
           _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public List<Contato> ListarContatos()
        {
            return _bancoContext.Contatos.ToList();
            
        }

   
        public Contato ListarPorId(int id)
        {
           return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
           
        }

        public Contato Editar(Contato contato)
        {
            Contato contatoDb = ListarPorId(contato.Id);

            if(contatoDb == null)
            {
                throw new Exception("Contato indexistente");
            }

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Telefone = contato.Telefone;

            _bancoContext.Contatos.Update(contatoDb);
            _bancoContext.SaveChanges();
            return contatoDb;
        }

        public bool DeletarContato(int id)
        {
            Contato contatoDb = ListarPorId(id);
            if (contatoDb == null)
            {
                throw new Exception("Contato indexistente");




            }

            _bancoContext.Contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();

            return true;
            
        }
    }
}
