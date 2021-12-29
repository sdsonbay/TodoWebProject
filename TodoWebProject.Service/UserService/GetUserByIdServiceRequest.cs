using System.Threading.Tasks;
using TodoWebProject.Data.UserData;
using TodoWebProject.Model.User;

namespace TodoWebProject.Service.UserService
{
    public interface IGetUserByIdServiceRequest
    {
        Task<GetUserDataModel> GetUserById(int id);
    }
    public class GetUserByIdServiceRequest: IGetUserByIdServiceRequest
    {
        private readonly IGetUserByIdDataRequest _getUserByIdDataRequest;

        public GetUserByIdServiceRequest(IGetUserByIdDataRequest getUserByIdDataRequest)
        {
            _getUserByIdDataRequest = getUserByIdDataRequest;
        }

        public async Task<GetUserDataModel> GetUserById(int id)
        {
            return await _getUserByIdDataRequest.GetUserById(id);
        }
    }
}