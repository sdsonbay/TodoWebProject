using System.Threading.Tasks;
using Dapper;
using TodoWebProject.Data.Utils;
using TodoWebProject.Model.User;

namespace TodoWebProject.Data.UserData
{
    public interface IUpdateUserByIdDataRequest
    {
        
    }
    public class UpdateUserByIdDataRequest: IUpdateUserByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public UpdateUserByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> UpdateUserById(InsertUserDataModel model, int id)
        {
            var query = $"UPDATE User SET Username = @Username WHERE Id = {id}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query, model);
            return response > 0;
        }
    }
}