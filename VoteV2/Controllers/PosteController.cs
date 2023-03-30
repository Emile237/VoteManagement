using Microsoft.AspNetCore.Mvc;
using VoteV2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoteV2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PosteController : ControllerBase
    {
        private readonly VoteContext _context;
        public PosteController(VoteContext context)
        {

            _context = context;
        }
        // GET: api/<PosteController>
        [HttpGet]
        public IEnumerable<Poste> Get()
        {
            var result = _context.Postes.ToList();

            return result;
        }

        // GET api/<PosteController>/5
        [HttpGet("{id}")]
        public Poste Get(int id)
        {
            return _context.Postes.First(p=>p.Idposte==id);
        }

        // POST api/<PosteController>
        [HttpPost]
        public void Post([FromBody] Poste poste)
        {
            _context.Postes.Add(poste);
            _context.SaveChanges();
        }

        // PUT api/<PosteController>
        [HttpPut()]
        public void Put([FromBody] Poste poste)
        {
            _context.Postes.Update(poste);
            _context.SaveChanges();
        }

        // DELETE api/<PosteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Postes.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}
