using Microsoft.EntityFrameworkCore;
using WebAPI_Pessoa.Models;

namespace WebAPI_Pessoa.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<PessoaModel> Pessoas { get; set; }
    }
}
