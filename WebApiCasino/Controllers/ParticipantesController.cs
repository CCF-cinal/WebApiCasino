using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasino.Entidades;

namespace WebApiCasino.Controllers
{
    [ApiController]
    [Route("participantes")]
    public class ParticipantesController:ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ParticipantesController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Participante>>> Get()
        {
            return await dbContext.Participantes.ToListAsync();
        }

        

        [HttpPost]
        public async Task<ActionResult> Post(Participante participante)
        {
            var existeRifa = await dbContext.Rifas.AnyAsync(x => x.Id == participante.RifaId);
            if (!existeRifa)
            {
                return BadRequest($"No existe la rifa con el id: {participante.RifaId}");
            }
            dbContext.Add(participante);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Participante participante, int id)
        {
            var exist = await dbContext.Participantes.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("El participante especificado no existe. ");
            }
            if (participante.Id != id)
            {
                return BadRequest("El id del participante no coincide con el establecido.");
            }
            dbContext.Update(participante);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Participantes.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Participante()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
