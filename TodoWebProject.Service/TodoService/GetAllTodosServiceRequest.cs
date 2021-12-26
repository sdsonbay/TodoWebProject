using System.Collections.Generic;
using System.Threading.Tasks;
using TodoWebProject.Data.TodoData;
using TodoWebProject.Model.Todo;

namespace TodoWebProject.Service.TodoService
{
    public interface IGetAllTodosServiceRequest
    {
        Task<List<GetTodoDataModel>> GetAllTodos();
    }
    public class GetAllTodosServiceRequest: IGetAllTodosServiceRequest
    {
        private IGetAllTodosDataRequest _getAllTodosDataRequest;

        public GetAllTodosServiceRequest(IGetAllTodosDataRequest getAllTodosDataRequest)
        {
            _getAllTodosDataRequest = getAllTodosDataRequest;
        }

        public async Task<List<GetTodoDataModel>> GetAllTodos()
        {
            return await _getAllTodosDataRequest.GetAllTodos();
        }
    }
}