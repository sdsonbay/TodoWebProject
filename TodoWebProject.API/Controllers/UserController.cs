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

        [HttpGet("{id}")]
        public async Task<GetUserDataModel> GetUserById(int id)
        {
            return await _getUserByIdServiceRequest.GetUserById(id);
        }

        [HttpPost("insert")]
        public async Task<bool> InsertUser([FromBody] InsertUserDataModel model)
        {
            return await _insertUserServiceRequest.InsertUser(model);
        }

        [HttpPut("update")]
        public async Task<bool> UpdateUserById([FromBody] InsertUserDataModel model, int id)
        {
            return await _updateUserByIdServiceRequest.UpdateUserById(model, id);
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteUserById(int id)
        {
            return await _deleteUserByIdServiceRequest.DeleteUserById(id);
        }
    }
}