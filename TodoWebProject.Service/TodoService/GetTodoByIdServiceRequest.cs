using System.Threading.Tasks;
using TodoWebProject.Data.TodoData;
using TodoWebProject.Model.Todo;

namespace TodoWebProject.Service.TodoService
{
    public interface IGetTodoByIdServiceRequest
    {
        Task<GetTodoDataModel> GetTodoById(int id);
    }
    public class GetTodoByIdServiceRequest: IGetTodoByIdServiceRequest
    {
        private readonly IGetTodoByIdDataRequest _getTodoByIdDataRequest;

        public GetTodoByIdServiceRequest(IGetTodoByIdDataRequest getTodoByIdDataRequest)
        {
            _getTodoByIdDataRequest = getTodoByIdDataRequest;
        }

        public async Task<GetTodoDataModel> GetTodoById(int id)
        {
            return await _getTodoByIdDataRequest.GetTodoById(id);
        }
        
    }
}