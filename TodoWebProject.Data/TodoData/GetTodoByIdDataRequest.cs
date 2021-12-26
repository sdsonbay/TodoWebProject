using System.Threading.Tasks;
using Dapper;
using TodoWebProject.Data.Utils;
using TodoWebProject.Model.Todo;

namespace TodoWebProject.Data.TodoData
{
    public interface IGetTodoByIdDataRequest
    {
        Task<GetTodoDataModel> GetTodoById(int id);
    }
    public class GetTodoByIdDataRequest: IGetTodoByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public GetTodoByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<GetTodoDataModel> GetTodoById(int id)
        {
            var query = $"SELECT Id, Title, Description, IsDone, UserId FROM Todo WHERE Id = {id}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.QueryFirstOrDefaultAsync<GetTodoDataModel>(query);
            return response;
        }

    }
}