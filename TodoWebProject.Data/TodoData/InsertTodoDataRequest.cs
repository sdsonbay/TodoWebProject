using System.Threading.Tasks;
using Dapper;
using TodoWebProject.Data.Utils;
using TodoWebProject.Model.Todo;

namespace TodoWebProject.Data.TodoData
{

    public interface IInsertTodoDataRequest
    {
        Task<bool> InsertTodo(InsertTodoDataModel model);
    }
    
    public class InsertTodoDataRequest: IInsertTodoDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public InsertTodoDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> InsertTodo(InsertTodoDataModel model)
        {
            var query = $"INSERT INTO Todo(Title, Description, IsDone, UserId) VALUES @Title, @Description, @IsDone, @UserId";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query, model);
            return response > 0;
        }

    }
}