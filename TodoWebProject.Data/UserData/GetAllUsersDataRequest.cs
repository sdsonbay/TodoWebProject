using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TodoWebProject.Data.Utils;
using TodoWebProject.Model.User;

namespace TodoWebProject.Data.UserData
{
    public interface IGetAllUsersDataRequest
    {
        Task<List<GetUserDataModel>> GetAllUsers();
    }
    public class GetAllUsersDataRequest: IGetAllUsersDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public GetAllUsersDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<GetUserDataModel>> GetAllUsers()
        {
            var query = $"SELECT Id, Username FROM User";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.QueryAsync<GetUserDataModel>(query);
            return response.ToList();
        }

    }
}