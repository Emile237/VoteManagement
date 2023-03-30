using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using VoteV2.Models;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VoteV2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CandidatureController : ControllerBase
    {
        private readonly VoteContext _context;
        public CandidatureController(VoteContext context)
        {
            _context = context;
        }
        // GET: <CandidtureController>
        [HttpGet]
        public IEnumerable<Candidature> Get()
        {
            var result = _context.Candidatures
                .Include(c => c.poste)
                .Include(c => c.candidat)
                .ToList();

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(result, settings);
            var deserializedResult = JsonConvert.DeserializeObject<IEnumerable<Candidature>>(json, settings);

            return deserializedResult;
        }

        // GET <CandidtureController>/5
        [HttpGet("{id}")]
        public Candidature Get(int id)
        {
            return _context.Candidatures.First(p => p.Idcandidature== id);

        }

        // POST <CandidtureController>
        [HttpPost]
        public void Post([FromBody] Candidature candidature)
        {
            _context.Candidatures.Add(candidature);
            _context.SaveChanges();
        }

        // PUT <CandidtureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Candidature candidature)
        {
            _context.Candidatures.Update(candidature);
            _context.SaveChanges();
        }

        // DELETE <CandidtureController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Candidatures.Remove(Get(id));
            _context.SaveChanges();
        }
    }
}
