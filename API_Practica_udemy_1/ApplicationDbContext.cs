using API_Practica_udemy_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API_Practica_udemy_1
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<TarjetaCredito> TarjetaCredito { get; set; }
        //constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }
    }
}
