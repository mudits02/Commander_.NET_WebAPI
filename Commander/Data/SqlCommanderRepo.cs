using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }


        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            /*
                The entities are stored in a part of the EF called the "Change Tracker." The Change Tracker keeps track of all the changes you make to the entities during the lifetime of the DbContext

            */
            return (_context.SaveChanges() >= 0); //Saves those saved data instances to the databse
        }
    }
}