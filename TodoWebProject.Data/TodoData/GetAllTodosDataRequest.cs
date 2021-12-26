using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TodoWebProject.Data.Utils;
using TodoWebProject.Model.Todo;

namespace TodoWebProject.Data.TodoData
{
    public interface IGetAllTodosDataRequest
    {
        Task<List<GetTodoDataModel>> GetAllTodos();
    }
    public class GetAllTodosDataRequest: IGetAllTodosDataRequest
    {
        private IProjectDbConnection _dbConnection;

        public GetAllTodosDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public async Task<List<GetTodoDataModel>> GetAllTodos()
        {
            var query = $"SELECT Id, Title, Description, IsDone, UserId FROM Todo";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.QueryAsync<GetTodoDataModel>(query);
            return response.ToList();
        }
    }
}