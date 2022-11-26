using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasino.Entidades;

namespace WebApiCasino.Controllers
{
    [ApiController]
    [Route("rifas")]
    public class RifasController:ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public RifasController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Rifa>>> Get()
        {
            return await dbContext.Rifas.ToListAsync();
        }

        //[HttpGet("{id:int}",Name ="obtener ganador")]
        //public async Task<ActionResult<List<Participante>>> Get(int id)
        //{
            //var total = await dbContext.Rifas
        //}

        [HttpPost]
        public async Task<ActionResult> Post(Rifa rifa)
        {
            //rifa.Sumatoria = 3*(from o in dbContext.Rifas where o.Id=='1' from t in o.Nombre select t).Count();
            dbContext.Add(rifa);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Rifa rifa, int id)
        {
            if (rifa.Id != id)
            {
                return BadRequest("El id del premio no coincide con el establecido en la url.");
            }
            dbContext.Update(rifa);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Rifas.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Rifa()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
