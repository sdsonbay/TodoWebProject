using System.Threading.Tasks;
using Dapper;
using TodoWebProject.Data.Utils;
using TodoWebProject.Model.Todo;
using TodoWebProject.Model.User;

namespace TodoWebProject.Data.UserData
{
    public interface IGetUserByIdDataRequest
    {
        Task<GetUserDataModel> GetUserById(int id);
    }
    public class GetUserByIdDataRequest: IGetUserByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public GetUserByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<GetUserDataModel> GetUserById(int id)
        {
            var query = $"SELECT Id, Username FROM User WHERE Id = {id}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.QueryFirstOrDefaultAsync<GetUserDataModel>(query);
            return response;
        }
    }
}