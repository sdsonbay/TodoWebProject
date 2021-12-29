using System.Threading.Tasks;
using TodoWebProject.Data.UserData;
using TodoWebProject.Model.Todo;
using TodoWebProject.Model.User;

namespace TodoWebProject.Service.UserService
{
    public interface IInsertUserServiceRequest
    {
        Task<bool> InsertUser(InsertUserDataModel model);
    }
    public class InsertUserServiceRequest: IInsertUserServiceRequest
    {
        private readonly IInsertUserDataRequest _insertUserDataRequest;

        public InsertUserServiceRequest(IInsertUserDataRequest insertUserDataRequest)
        {
            _insertUserDataRequest = insertUserDataRequest;
        }

        public async Task<bool> InsertUser(InsertUserDataModel model)
        {
            return await _insertUserDataRequest.InsertUser(model);
        }
    }
}