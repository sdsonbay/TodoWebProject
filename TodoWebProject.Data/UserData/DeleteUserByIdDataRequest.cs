using System.Threading.Tasks;
using Dapper;
using TodoWebProject.Data.Utils;
using TodoWebProject.Model.User;

namespace TodoWebProject.Data.UserData
{
    public interface IDeleteUserByIdDataRequest
    {
        Task<bool> DeleteUserById(InsertUserDataModel model, int id);
    }
    public class DeleteUserByIdDataRequest: IDeleteUserByIdDataRequest
    {
        private readonly IProjectDbConnection _dbConnection;

        public DeleteUserByIdDataRequest(IProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> DeleteUserById(InsertUserDataModel model, int id)
        {
            var query = $"DELETE FROM User WHERE Id = {id}";
            using var conn = _dbConnection.GetConnection();
            var response = await conn.ExecuteAsync(query);
            return response > 0;
        }
    }
}