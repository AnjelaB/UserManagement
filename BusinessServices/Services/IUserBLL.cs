using Common.ModelsDTO.Input;
using Common.ModelsDTO.Output;
using System.Collections.Generic;

namespace BusinessServices.Services
{
    public interface IUserBLL
    {
        List<UserModel> GetUsers();

        GetUsersOutput GetUsersWithFiltration(GetUsersInputModel input);

        int AddUser(AddUserInputModel input);

        void UpdateUserDetails(UpdateUserDetailsInput input);

        void RemoveUser(int id);
    }
}
