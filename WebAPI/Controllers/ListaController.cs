using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListaController : ControllerBase
    {
        private static List<ListaItem> lista;
        private static int nextId;

        static ListaController()
        {
            nextId = 1;
            lista = new List<ListaItem>
    {
        new ListaItem { Id = nextId++, Tytul = "Incepcja", Rezyser = "Christopher Nolan", Gatunek = "Sci-Fi", Rok_wydania = 2010 },
        new ListaItem { Id = nextId++, Tytul = "Parasite", Rezyser = "Bong Joon-ho", Gatunek = "Dramat", Rok_wydania = 2019 },
        new ListaItem { Id = nextId++, Tytul = "Skazani na Shawshank", Rezyser = "Frank Darabont", Gatunek = "Dramat", Rok_wydania = 1994 },
        new ListaItem { Id = nextId++, Tytul = "Matrix", Rezyser = "Lana i Lilly Wachowski", Gatunek = "Sci-Fi", Rok_wydania = 1999 },
        new ListaItem { Id = nextId++, Tytul = "Gladiator", Rezyser = "Ridley Scott", Gatunek = "Historyczny", Rok_wydania = 2000 }
    };
        }

        [HttpGet]
        public ActionResult<IEnumerable<ListaItem>> GetAll()
        {
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public ActionResult<ListaItem> GetById(int id)
        {
            var item = lista.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<ListaItem> Add(ListaItem item)
        {
            item.Id = nextId++;
            lista.Add(item);
            return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = lista.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            lista.Remove(item);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ListaItem updatedItem)
        {
            var existingItem = lista.FirstOrDefault(x => x.Id == id);
            if (existingItem == null)
                return NotFound();

            existingItem.Tytul = updatedItem.Tytul;
            existingItem.Rezyser = updatedItem.Rezyser;
            existingItem.Gatunek = updatedItem.Gatunek;
            existingItem.Rok_wydania = updatedItem.Rok_wydania;

            return NoContent();
        }
    }
}
