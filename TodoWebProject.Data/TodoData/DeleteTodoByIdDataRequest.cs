using System.Threading.Tasks;
using Dapper;
using TodoWebProject.Data.Utils;
using TodoWebProject.Model.Todo;

namespace TodoWebProject.Data.TodoData
{
    public interface IDeleteTodoByIdDataRequest
    {
        Task<bool> DeleteTodoById(InsertTodoDataModel model, int id);
    }
    public class DeleteTodoByIdDataRequest: IDeleteTodoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public DeleteTodoByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> DeleteTodoById(InsertTodoDataModel model, int id)
        {
            var query = $"DELETE FROM Todo WHERE Id = {id}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }
    }
}