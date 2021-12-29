using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoWebProject.Model.User;
using TodoWebProject.Service.UserService;

namespace TodoWebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: Controller
    {
        private readonly IGetAllUsersServiceRequest _getAllUsersServiceRequest;
        private readonly IGetUserByIdServiceRequest _getUserByIdServiceRequest;
        private readonly IInsertUserServiceRequest _insertUserServiceRequest;
        private readonly IUpdateUserByIdServiceRequest _updateUserByIdServiceRequest;
        private readonly IDeleteUserByIdServiceRequest _deleteUserByIdServiceRequest;

        public UserController(IGetAllUsersServiceRequest getAllUsersServiceRequest, IGetUserByIdServiceRequest getUserByIdServiceRequest, IInsertUserServiceRequest insertUserServiceRequest, IUpdateUserByIdServiceRequest updateUserByIdServiceRequest, IDeleteUserByIdServiceRequest deleteUserByIdServiceRequest)
        {
            _getAllUsersServiceRequest = getAllUsersServiceRequest;
            _getUserByIdServiceRequest = getUserByIdServiceRequest;
            _insertUserServiceRequest = insertUserServiceRequest;
            _updateUserByIdServiceRequest = updateUserByIdServiceRequest;
            _deleteUserByIdServiceRequest = deleteUserByIdServiceRequest;
        }

        [HttpGet("all")]
        public async Task<List<GetUserDataModel>> GetAllUsers()
        {
            return await _getAllUsersServiceRequest.GetAllUsers();
        }
    }
}