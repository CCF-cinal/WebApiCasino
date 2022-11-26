using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasino.Entidades;

namespace WebApiCasino.Controllers
{
    [ApiController]
    [Route("premios")]
    public class PremiosController:ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PremiosController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Premio>>> Get()
        {
            return await dbContext.Premios.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Premio premio)
        {
            var existeRifa = await dbContext.Rifas.AnyAsync(x => x.Id == premio.RifaId);
            if (!existeRifa)
            {
                return BadRequest($"No existe la rifa con el id: {premio.RifaId} ");
            }
            dbContext.Add(premio);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Premio premio, int id)
        {
            var exist = await dbContext.Premios.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El premio especificado no existe. ");
            }
            if (premio.Id != id)
            {
                return BadRequest("El id del premio no coincide con el establecido en la url.");
            }
            dbContext.Update(premio);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Premios.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Premio()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
