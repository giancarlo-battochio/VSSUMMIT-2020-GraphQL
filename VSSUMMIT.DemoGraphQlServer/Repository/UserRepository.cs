using System;
using System.Collections.Generic;
using System.Linq;
using VSSUMMIT.Demo00.Repository;

namespace VSSUMMIT.Demo00
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DemoContext context) : base(context) { }

        public List<User> GetAllUsers(int page, int pageSize)
        {
            return GetWithPagination(page, pageSize).ToList();
        }

        public User GetUserById(int id)
        {
            return Get().FirstOrDefault(x => x.Id == id);
        }

        public User AddUser(User user)
        {
            var result = AddAsync(user).Result;
            return result;
        }

        public User UpdateUser(User lastStateUser, User user)
        {
            lastStateUser.Name = user.Name;
            lastStateUser.Address = user.Address;
            lastStateUser.Birthday = user.Birthday;

            var result = UpdateAsync(lastStateUser).Result;
            return result;
        }

        public User DeleteUser(int id)
        {
            var lastStateUser = Get().FirstOrDefault(x => x.Id == id);
            var result = DeleteAsync(lastStateUser).Result;
            return result;
        }
    }
}
