using System.Threading.Tasks;
using TodoWebProject.Data.TodoData;
using TodoWebProject.Model.Todo;

namespace TodoWebProject.Service.TodoService
{
    public interface IInsertTodoServiceRequest
    {
        Task<bool> InsertTodo(InsertTodoDataModel model);
    }
    public class InsertTodoServiceRequest: IInsertTodoServiceRequest
    {
        private readonly IInsertTodoDataRequest _insertTodoDataRequest;

        public InsertTodoServiceRequest(IInsertTodoDataRequest insertTodoDataRequest)
        {
            _insertTodoDataRequest = insertTodoDataRequest;
        }

        public async Task<bool> InsertTodo(InsertTodoDataModel model)
        {
            return await _insertTodoDataRequest.InsertTodo(model);
        }
    }
}