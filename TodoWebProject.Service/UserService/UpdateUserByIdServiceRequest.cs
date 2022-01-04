using System.Data;
using System.Threading.Tasks;
using TodoWebProject.Data.UserData;
using TodoWebProject.Model.User;

namespace TodoWebProject.Service.UserService
{
    public interface IUpdateUserByIdServiceRequest
    {
        Task<bool> UpdateUserById(InsertUserDataModel model, int id);
    }
    public class UpdateUserByIdServiceRequest: IUpdateUserByIdServiceRequest
    {
        private readonly IUpdateUserByIdDataRequest _updateUserByIdDataRequest;

        public UpdateUserByIdServiceRequest(IUpdateUserByIdDataRequest updateUserByIdDataRequest)
        {
            _updateUserByIdDataRequest = updateUserByIdDataRequest;
        }

        public async Task<bool> UpdateUserById(InsertUserDataModel model, int id)
        {
            return await _updateUserByIdDataRequest.UpdateUserById(model, id);
        }
    }
}