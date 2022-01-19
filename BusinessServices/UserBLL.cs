using BusinessServices.Services;
using Common;
using Common.ModelsDTO.Input;
using Common.ModelsDTO.Output;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessServices
{
    public class UserBLL : BaseBLL, IUserBLL
    {
        public List<UserModel> GetUsers()
        {
            var result = Db.Users.Include("Countries").Select(x => new UserModel
            {
                Id = x.Id,
                FullName = x.FullName,
                MobileNumber = x.MobileNumber,
                State = x.State,
                CountryName = x.Country.Name,
                CreationTime = x.CreationTime,
                LastUpdateTime = x.LastUpdateTime
            }).ToList();
            return result;
        }

        public GetUsersOutput GetUsersWithFiltration(GetUsersInputModel input)
        {
            var users = Db.Users.Include("Countries") as IQueryable<User>;
            if (input.State.HasValue)
            {
                users = users.Where(x => x.State == (byte)input.State.Value);
            }

            users = users.OrderByDescending(x => x.Id).Skip((input.Page - 1) * input.Top).Take(input.Top + 1);

            var result = new GetUsersOutput
            {
                Users = users.Take(input.Top).Select(x => new UserModel
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    MobileNumber = x.MobileNumber,
                    State = x.State,
                    CountryName = x.Country.Name,
                    CreationTime = x.CreationTime,
                    LastUpdateTime = x.LastUpdateTime
                }).ToList(),
                HasNext = users.Count() > input.Top
            };

            return result;
        }

        public int AddUser(AddUserInputModel input)
        {
            var country = Db.Countries.FirstOrDefault(x => x.Id == input.CountryId);
            if (country == null)
                throw new Exception("Country is not found");
            var user = new User
            {
                FullName = input.FullName,
                MobileNumber = input.MobileNumber,
                State = (int)Constants.UserState.Active,
                CountryId = input.CountryId,
                CreationTime = DateTime.UtcNow,
                LastUpdateTime = DateTime.UtcNow
            };
            Db.Users.Add(user);
            Db.SaveChanges();
            return user.Id;
        }

        public void UpdateUserDetails(UpdateUserDetailsInput input)
        {
            var user = Db.Users.FirstOrDefault(x => x.Id == input.Id);
            if (user == null)
                throw new Exception("User is not found");

            user.FullName = !string.IsNullOrEmpty(input.FullName) && input.FullName != user.FullName ? input.FullName : user.FullName;
            user.MobileNumber = !string.IsNullOrEmpty(input.MobileNumber) && input.MobileNumber != user.MobileNumber ? input.MobileNumber : user.MobileNumber;
            user.State = input.State.HasValue && (byte)input.State.Value != user.State ? (byte)input.State.Value : user.State;
            user.LastUpdateTime = DateTime.UtcNow;

            if (input.CountryId.HasValue && input.CountryId.Value != user.CountryId)
            {
                var country = Db.Countries.FirstOrDefault(x => x.Id == input.CountryId);
                if (country == null)
                    throw new Exception("Country is not found");
                user.CountryId = country.Id;
            }

            Db.SaveChanges();
        }

        public void RemoveUser(int id)
        {
            var user = Db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                throw new Exception("User is not found");

            Db.Users.Remove(user);
            Db.SaveChanges();
        }
    }
}
