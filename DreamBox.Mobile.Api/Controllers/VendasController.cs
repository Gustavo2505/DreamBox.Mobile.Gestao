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
    public class VendasController : ControllerBase
    {

        private DataContext _data;
        public VendasController(DataContext data)
        {
            _data = data;
        }
        [HttpGet("{id}")]
        public IActionResult GetVendas(int id)
        {
            Vendas vendasDb = _data.Vendas.Find(id);

            if (vendasDb == null)
            {
                return NotFound();
            }
            return new JsonResult(vendasDb);
        }

        [HttpGet]
        public IEnumerable<Vendas> GetAllVendas(string all)
        {
            return _data.Vendas.Where(a => a.Id > 0).ToList<Vendas>();
        }




        [HttpPost]
        public IActionResult AddVenda(Vendas vendas)
        {
            _data.Vendas.Add(vendas);
            _data.SaveChanges();


            return CreatedAtAction("GetItem", new { id = vendas.Id }, vendas);

        }
    }
}
