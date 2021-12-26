using System.Data;
using System.Data.SqlClient;

namespace TodoWebProject.Data.Utils
{
    public interface IProjectDbConnection
    {
        IDbConnection GetConnection();
    }
    public class ProjectDbConnection: IProjectDbConnection
    {
        private string _connectionString;

        public ProjectDbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}