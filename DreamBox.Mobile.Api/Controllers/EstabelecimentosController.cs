using DreamBox.Mobile.Api.Database;
using DreamBox.Mobile.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamBox.Mobile.Api.Controllers
{
    [Route("api/Estabelecimentos")]
    [ApiController]
    public class EstabelecimentosController : ControllerBase
    {
        private DataContext _data;
        public EstabelecimentosController(DataContext data)
        {
            _data = data;
        }

        //TODO: CRIAR METODO PARA CADASTRAR E EXCLUIR USUÁRIOS;
        [HttpGet("Get")]
        public IActionResult GetEstabelecimento(string nome)
        {
            
            Estabelecimentos estabelecimentos = _data.Estabelecimentos.FirstOrDefault(a => a.Nome == nome);


            if (estabelecimentos == null)
            {
                return NotFound();
            }
            return new JsonResult(estabelecimentos);

        }


        [HttpPost("Add")]
        public IActionResult IncluirEstabelecimento(Estabelecimentos estabelecimentos)
        {
            _data.Estabelecimentos.Add(estabelecimentos);
            _data.SaveChanges();
            //_data.SaveChanges(); metodo esta correto, mas preciso verificar o pq ele não esta salvando no banco ("minha suspeita é que não esta sendo populado todas as tabelas")
            return CreatedAtAction(nameof(GetEstabelecimento),
                new
                {
                    nome = estabelecimentos.Nome,
                    // usuario = estabelecimentos.UsuariosId

                }, estabelecimentos);
        }



      /*  [HttpGet ("{Id}")]
         public IActionResult GetItem(int id)
         {
             Items itemsdb = _data.Items.Find(id);

             if (itemsdb == null)
             {
                 return NotFound();
             }
             return new JsonResult(itemsdb);
         }
      /*   public IActionResult AddItem(Vendas vendas)
         {
             _data.Vendas.Add(vendas);
             _data.SaveChanges();


             return CreatedAtAction("GetJob", new { id = vendas.Id }, vendas);

         }*/
    }
}