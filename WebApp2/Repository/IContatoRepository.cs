using WebApp2.Models;

namespace WebApp2.Repository
{
    public interface IContatoRepository
    {
        List<Contato> ListarContatos();

        Contato ListarPorId(int id);

        Contato Create(Contato contato);

        Contato Editar(Contato contato);

        bool DeletarContato(int id);

        


    }
}
