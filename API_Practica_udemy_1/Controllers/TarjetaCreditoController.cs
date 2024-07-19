using API_Practica_udemy_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Practica_udemy_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaCreditoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TarjetaCreditoController(ApplicationDbContext dbContext) 
        {
            _context = dbContext;
        }

        // GET: api/<TarjetaCreditoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listadoTarjetas = await _context.TarjetaCredito.ToListAsync();
                return Ok(listadoTarjetas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TarjetaCreditoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var tarjetaCredito = await _context.TarjetaCredito.FirstOrDefaultAsync(a => a.Id == id);
                return Ok(tarjetaCredito);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        // POST api/<TarjetaCreditoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                if (tarjeta != null)
                {
                    await _context.AddAsync(tarjeta);
                    await _context.SaveChangesAsync();
                    return Ok(tarjeta);
                }
                return BadRequest("Error insert in db");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TarjetaCreditoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                if (tarjeta != null && tarjeta.Id == id)
                {
                    _context.Update(tarjeta);
                    await _context.SaveChangesAsync();
                    return Ok(tarjeta);
                }
                return BadRequest("Error update in db");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TarjetaCreditoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarjeta = await _context.TarjetaCredito.FirstOrDefaultAsync(t => t.Id == id);

                if(tarjeta != null)
                {
                    _context.Remove(tarjeta);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Tarjeta terminada en:" + tarjeta.Numero.Substring(15) + " Eliminada" });
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
