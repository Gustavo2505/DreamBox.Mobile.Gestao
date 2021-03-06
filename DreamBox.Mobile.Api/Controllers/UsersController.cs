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
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private DataContext _data;
        public UsersController(DataContext data)
        {
            _data = data;
        }

        //TODO: CRIAR METODO PARA CADASTRAR E EXCLUIR USUÁRIOS;
        [HttpGet]
        public IActionResult GetUser(string email, string password)
        {
            Usuarios userDb = _data.Usuarios.FirstOrDefault(a => a.Email == email && a.Senha == password);


            if (userDb == null)
            {
                return NotFound();
            }
            return new JsonResult(userDb);

        }


        [HttpPost]
        public IActionResult AddUser(Usuarios user)
        {
           
            _data.Usuarios.Add(user);
            _data.SaveChanges();
            //_data.SaveChanges(); metodo esta correto, mas preciso verificar o pq ele não esta salvando no banco ("minha suspeita é que não esta sendo populado todas as tabelas")
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
      /*   [HttpGet]
         public IActionResult GetUserId(int id)
         {
             Items itemsdb = _data.Items.Find(id);

             if (itemsdb == null)
             {
                 return NotFound();
             }
             return new JsonResult(itemsdb);
         }
   /*      public IActionResult AddItem(Vendas vendas)
         {
             _data.Vendas.Add(vendas);
             _data.SaveChanges();


             return CreatedAtAction("GetJob", new { id = vendas.Id }, vendas);

         }*/
    }
}
