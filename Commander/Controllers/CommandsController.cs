using Commander.Data;
using Commander.Models;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc; // default controller library
using Commander.DTO;

namespace Commander.Controllers
{
    //api/controller
    /*
        api/[controller](Inside route)
        So what this actually does is it outes t the given API resource nd point
        But how does it do it? and whats the significance of it?
        So what is does is it takes the sting before the controller class name
        for example -> in class CommanderController , it takes the wrod before the controller name
        like api/commander in the case of the class

        so what is signifies it take me to the controller classes prefix

        if the controller was say MuditController
        Route what have been api/mudit 
    */
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository , IMapper mapper)//depedency injection
        {
            _repository = repository;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        //GET api/command
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandItems));
        }
        //GET api/command/5
        [HttpGet("{id}" , Name = "GetCommandById")]
        public ActionResult <CommandReadDTO> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDTO>(commandItem));
            }

            return NotFound();
        }

        //POST api/commands

        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges(); // saves changes in your database

            var commandReadDto = _mapper.Map<CommandReadDTO>(commandModel);

            // basically CreatedAtRoute helps us returning the URL of the data object created 
            return CreatedAtRoute(nameof(GetCommandById), new { commandReadDto.Id }, commandReadDto);

            //return Ok(commandReadDto);
        }
    }
}