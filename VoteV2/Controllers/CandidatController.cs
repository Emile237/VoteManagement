using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VoteV2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoteV2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CandidatController : ControllerBase
    {
        private readonly VoteContext _context;
        public CandidatController(VoteContext context) {

            _context = context;
        }
        // GET: api/<CandidatController>
        [HttpGet]
        public IEnumerable<Candidat> Get()
        {
            var result = _context.Candidats.ToList();

            return result;
        }

        // GET api/<CandidatController>/5
        [HttpGet("{id}")]
        public Candidat Get(int id)
        {
            return _context.Candidats.First(c => c.IdCandidat == id);
        }

        // POST api/<CandidatController>
        [HttpPost]
        public void Post([FromBody] Candidat value)
        {
           _context.Candidats.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<CandidatController>/5
        [HttpPut()]
        public void Put([FromBody] Candidat candidat)
        {
           // candidat.IdCandidat = _context.Candidats.First(c => c.IdCandidat == id).IdCandidat;
            _context.Candidats.Update(candidat);
            _context.SaveChanges();

        }

        // DELETE api/<CandidatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

           var candidatures =  _context.Candidatures.Where(c => c.Idcandidat == id);
            foreach (var candidature in candidatures)
            {
                _context.Remove(candidature);
            }

            _context.Candidats.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}
