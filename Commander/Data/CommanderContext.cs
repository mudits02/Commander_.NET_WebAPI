using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> options) : base(options)
        {

        }

        public DbSet<Command> Commands { get; set; } // basically if you observe , we are adding all the file names in the folder Model
        



    }
}