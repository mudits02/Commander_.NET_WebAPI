using Commander.Models;
using Commander.Controllers;
using System.Collections.Generic;

namespace Commander.Data

{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int Id);

        void CreateCommand(Command cmd);

    }
}