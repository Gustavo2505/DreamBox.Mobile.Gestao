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

    // TODO: Verificar 

    [Route("api/Items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        private DataContext _data;
        public ItemsController(DataContext data)
        {
            _data = data;
        }
        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            Items itemsdb = _data.Items.Find(id);

            if (itemsdb == null)
            {
                return NotFound();
            }
            return new JsonResult(itemsdb);
        }

        [HttpGet]
        public IEnumerable<Items> GetAllItem(string all)
        {
            return _data.Items.Where(a => a.Id > 0).ToList<Items>();
        }




        [HttpPost]
        public IActionResult AddItem(Items items)
        {
            _data.Items.Add(items);
            _data.SaveChanges();


            return CreatedAtAction("GetItem", new { id = items.Id }, items);

        }
    }
}
