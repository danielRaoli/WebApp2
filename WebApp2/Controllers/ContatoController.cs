using Microsoft.AspNetCore.Mvc;
using WebApp2.Models;
using WebApp2.Repository;

namespace WebApp2.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _crepository;
        public ContatoController(IContatoRepository repositoryContato)
        {
            _crepository = repositoryContato;
        }
        public IActionResult Index()
        {
           List<Contato> contatos =_crepository.ListarContatos();
            
            return View(contatos);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Contato contato)
        {
        
            _crepository.Create(contato);
            return RedirectToAction("Index");
        }
        
        public IActionResult Edit(int id)
        {
            Contato c = _crepository.ListarPorId(id);
            return View(c);
        }

        [HttpPost]
        public IActionResult Edit(Contato contato)
        {
            _crepository.Editar(contato);
            return RedirectToAction("Index");

        }


        public IActionResult Delet(int id)
        {
           Contato cont = _crepository.ListarPorId(id);
            return View(cont);
        }

        
        public IActionResult DeletConfirmed(int id)
        {
            _crepository.DeletarContato(id);
            return RedirectToAction("Index");
        }
    }
}
