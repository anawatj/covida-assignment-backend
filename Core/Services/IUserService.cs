using Core.Domains;
using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService : IService<User>
    {
        public UserDto SignUp(User user);

        public User Update(User user,string userId);

        public User ChangePassword(User user, string userId);

        public UserDto Login(LoginDto dto);

        public User FindUserById(string id, string userId);

        public List<UserDto> FindAllUser( string userId);

        public void DeleteUser(string id, string userId);
    }
}
