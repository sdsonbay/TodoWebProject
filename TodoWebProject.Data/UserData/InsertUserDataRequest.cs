using System.Threading.Tasks;
using Dapper;
using TodoWebProject.Data.Utils;
using TodoWebProject.Model.User;

namespace TodoWebProject.Data.UserData
{
    public interface IInsertUserDataRequest
    {
        Task<bool> InsertUser(InsertUserDataModel model);
    }
    public class InsertUserDataRequest: IInsertUserDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public InsertUserDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> InsertUser(InsertUserDataModel model)
        {
            var query = $"INSERT INTO User(Username) VALUES @Username";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query, model);
            return response > 0;
        }
    }
}