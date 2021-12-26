using System.Data;
using System.Threading.Tasks;
using TodoWebProject.Data.TodoData;
using TodoWebProject.Model.Todo;

namespace TodoWebProject.Service.TodoService
{
    public interface IUpdateTodoByIdServiceRequest
    {
        Task<bool> UpdateTodoById(InsertTodoDataModel model, int id);
    }
    public class UpdateTodoByIdServiceRequest: IUpdateTodoByIdServiceRequest
    {
        private readonly IUpdateTodoByIdDataRequest _updateTodoByIdDataRequest;

        public UpdateTodoByIdServiceRequest(IUpdateTodoByIdDataRequest updateTodoByIdDataRequest)
        {
            _updateTodoByIdDataRequest = updateTodoByIdDataRequest;
        }


        public async Task<bool> UpdateTodoById(InsertTodoDataModel model, int id)
        {
            return await _updateTodoByIdDataRequest.UpdateTodoById(model, id);
    }
}