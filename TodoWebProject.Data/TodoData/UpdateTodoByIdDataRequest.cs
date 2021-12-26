using System.Threading.Tasks;
using Dapper;
using TodoWebProject.Data.Utils;
using TodoWebProject.Model.Todo;

namespace TodoWebProject.Data.TodoData
{
    public interface IUpdateTodoByIdDataRequest
    {
        Task<bool> UpdateTodoById(InsertTodoDataModel model, int id);
    }
    public class UpdateTodoByIdDataRequest: IUpdateTodoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public UpdateTodoByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> UpdateTodoById(InsertTodoDataModel model, int id)
        {
            var query = $"UPDATE Todo SET Title = @Title, Description = @Description, IsDone = @IsDone, UserId = @UserId WHERE Id = {id}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query, model);
            return response > 0;
        }
    }
}