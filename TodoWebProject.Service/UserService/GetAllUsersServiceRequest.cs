using System.Collections.Generic;
using System.Threading.Tasks;
using TodoWebProject.Data.UserData;
using TodoWebProject.Model.User;

namespace TodoWebProject.Service.UserService
{
    public interface IGetAllUsersServiceRequest
    {
        Task<List<GetUserDataModel>> GetAllUsers();
    }
    public class GetAllUsersServiceRequest: IGetAllUsersServiceRequest
    {
        private readonly IGetAllUsersDataRequest _getAllUsersDataRequest;

        public GetAllUsersServiceRequest(IGetAllUsersDataRequest getAllUsersDataRequest)
        {
            _getAllUsersDataRequest = getAllUsersDataRequest;
        }

        public async Task<List<GetUserDataModel>> GetAllUsers()
        {
            return await _getAllUsersDataRequest.GetAllUsers();
        }
    }
}