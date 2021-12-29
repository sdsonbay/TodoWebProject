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

        public UserController(IGetAllUsersServiceRequest getAllUsersServiceRequest)
        {
            _getAllUsersServiceRequest = getAllUsersServiceRequest;
        }

        [HttpGet("all")]
        public async Task<List<GetUserDataModel>> GetAllUsers()
        {
            return await _getAllUsersServiceRequest.GetAllUsers();
        }
    }
}