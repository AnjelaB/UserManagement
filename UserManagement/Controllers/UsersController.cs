using BusinessServices;
using Common.ModelsDTO.Input;
using Common.ModelsDTO.Output;
using System.Collections.Generic;
using System.Web.Http;

namespace UserManagement.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        public List<UserModel> GetUsers()
        {
            using (var userBll = new UserBLL())
            {
                var result = userBll.GetUsers();
                return result;
            }
        }

        [HttpPost]
        public GetUsersOutput GetUsersWithFiltration(GetUsersInputModel input)
        {
            using (var userBll = new UserBLL())
            {
                var result = userBll.GetUsersWithFiltration(input);
                return result;
            }
        }

        [HttpPost]
        public IHttpActionResult AddUser(AddUserInputModel input)
        {
            using (var userBll = new UserBLL())
            {
                var result = userBll.AddUser(input);
                return Ok(result);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateUserDetails(UpdateUserDetailsInput input)
        {
            using (var userBll = new UserBLL())
            {
                userBll.UpdateUserDetails(input);
                return Ok();
            }
        }

        [HttpDelete]
        public IHttpActionResult RemoveUser(int id)
        {
            using (var userBll = new UserBLL())
            {
                userBll.RemoveUser(id);
                return Ok();
            }
        }
    }
}
