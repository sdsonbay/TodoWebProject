using System.Data;
using System.Threading.Tasks;
using TodoWebProject.Data.TodoData;
using TodoWebProject.Model.Todo;

namespace TodoWebProject.Service.TodoService
{
    public interface IDeleteTodoByIdServiceRequest
    {
        Task<bool> DeleteTodoById(InsertTodoDataModel model, int id);
    }
    public class DeleteTodoByIdServiceRequest: IDeleteTodoByIdServiceRequest
    {
        private readonly IDeleteTodoByIdDataRequest _deleteTodoByIdDataRequest;

        public DeleteTodoByIdServiceRequest(IDeleteTodoByIdDataRequest deleteTodoByIdDataRequest)
        {
            _deleteTodoByIdDataRequest = deleteTodoByIdDataRequest;
        }

        public async Task<bool> DeleteTodoById(InsertTodoDataModel model, int id)
        {
            return await _deleteTodoByIdDataRequest.DeleteTodoById(model, id);
        }
    }
}