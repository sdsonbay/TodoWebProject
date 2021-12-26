using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoWebProject.Model.Todo;
using TodoWebProject.Service.TodoService;

namespace TodoWebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController: Controller
    {
        private readonly IGetAllTodosServiceRequest _getAllTodosServiceRequest;
        private readonly IGetTodoByIdServiceRequest _getTodoByIdServiceRequest;
        private readonly IInsertTodoServiceRequest _insertTodoServiceRequest;
        private readonly IUpdateTodoByIdServiceRequest _updateTodoByIdServiceRequest;

        public TodoController(IGetAllTodosServiceRequest getAllTodosServiceRequest, IGetTodoByIdServiceRequest getTodoByIdServiceRequest, IInsertTodoServiceRequest insertTodoServiceRequest, IUpdateTodoByIdServiceRequest updateTodoByIdServiceRequest)
        {
            _getAllTodosServiceRequest = getAllTodosServiceRequest;
            _getTodoByIdServiceRequest = getTodoByIdServiceRequest;
            _insertTodoServiceRequest = insertTodoServiceRequest;
            _updateTodoByIdServiceRequest = updateTodoByIdServiceRequest;
        }

        [HttpGet("all")]
        public async Task<List<GetTodoDataModel>> GetAllTodos()
        {
            return await _getAllTodosServiceRequest.GetAllTodos();
        }

        [HttpGet("{id}")]
        public async Task<GetTodoDataModel> GetTodoById(int id)
        {
            return await _getTodoByIdServiceRequest.GetTodoById(id);
        }

        [HttpPost("insert")]
        public async Task<bool> InsertTodo([FromBody]InsertTodoDataModel model)
        {
            return await _insertTodoServiceRequest.InsertTodo(model);
        }

        [HttpPut("update")]
        public async Task<bool> UpdateTodoById([FromBody] InsertTodoDataModel model, int id)
        {
            return await _updateTodoByIdServiceRequest.UpdateTodoById(model, id);
        }

    }
}