using Core.Domains;
using Core.Repositories;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Error;
using Implements.Utils;
using Core.Dtos;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Implements.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IMapper mapper;
        private AppDbContext db;
        private IConfiguration config;
        public UserService(AppDbContext db,IMapper mapper,IConfiguration config,IUserRepository userRepository)
        {
            this.db = db;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.config = config;
        }
        public User ChangePassword(User user, string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
           
            
                User? dbUser = this.userRepository.FindByEmail(user.Email);
                if (dbUser == null)
                {
                    throw new NotFoundException("User Not Found");
                }
                dbUser.Password = Passwords.HashPassword(user.Password);
                this.userRepository.Update(dbUser);
                return dbUser;
          
        }

        public void DeleteUser(string id, string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            User? user = this.userRepository.FindById(id);
            if (user==null)
            {
                throw new NotFoundException("User Not Found");
            }
            this.userRepository.Delete(user);
        }

        public List<UserDto> FindAllUser( string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            List<User> users = this.userRepository.FindAll();
                if (users.Count == 0)
                {
                    throw new NotFoundException("User Not Found");
                }
                return mapper.Map<List<User>, List<UserDto>>(users);

          
        }

        public User FindUserById(string id, string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }

            User? user = this.userRepository.FindById(id);
                if (user == null)
                {

                    throw new NotFoundException("User Not Found");
                }
                return user;
           
        }

        public UserDto Login(LoginDto dto)
        {
            List<string> errors = ValidateLogin(dto);
            if(errors.Count >0)
            {
                throw new FieldValueException(string.Join(",", errors));
            }
            User? user = this.userRepository.FindByEmail(dto.Email);
            if (user == null)
            {

                throw new BadRequestException("User Not Found");
            }
            if (!Passwords.VerifyPassword(dto.Password,user.Password))
            {
                throw new BadRequestException("Password is not valid");
            }
            UserDto userDto = mapper.Map<User, UserDto>(user);
            userDto.Jwt = Jwt.GenerateJSONWebToken(this.config,userDto);
            return userDto;
        }

        public UserDto SignUp(User data)
        {
            List<string> errors = Validate(data);
            if(errors.Count > 0)
            {
                throw new FieldValueException(String.Join(",", errors));
            }
            User? user = this.userRepository.FindByEmail(data.Email);
            if (user !=null)
            {

                throw new BadRequestException("Email in used");
            }
            data.Id = UUID.GenerateUUID();
            data.Password = Passwords.HashPassword(data.Password);
            User ret = this.userRepository.Save(data);

            UserDto userDto = mapper.Map<User, UserDto>(ret);
            userDto.Jwt = Jwt.GenerateJSONWebToken(this.config,userDto);
            return userDto;
        }

        public User Update(User data, string userId)
        {
            var existUser = this.userRepository.FindById(userId);
            if (existUser == null)
            {
                throw new UnAuthorizeException("UnAuthorize");
            }
            List<string> errors = Validate(data);
            if (errors.Count > 0)
            {
                throw new FieldValueException(String.Join(",", errors));
            }
            User? user = this.userRepository.FindByEmail(data.Email);
            if (user != null)
            {
                if(user.Id != data.Id)
                {
                    throw new BadRequestException("email in used");
                }
                
            }
            data.Password = Passwords.HashPassword(data.Password);
            User ret = this.userRepository.Update(data);
            return ret;
        }

        public List<string> ValidateLogin(LoginDto dto)
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(dto.Email))
            {
                errors.Add("Email is Required");
            }
            if (!string.IsNullOrEmpty(dto.Email) && !Formats.IsEmail(dto.Email))
            {
                errors.Add("Email is Invalid format");
            }
            if (string.IsNullOrEmpty(dto.Password))
            {
                errors.Add("Password is Required");
            }
            return errors;
        }

        public List<string> Validate(User data)
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrEmpty(data.Email))
            {
                errors.Add("Email is Required");
            }
            if (!string.IsNullOrEmpty(data.Email) && !Formats.IsEmail(data.Email))
            {
                errors.Add("Email is Invalid format");
            }
            if (string.IsNullOrEmpty(data.FirstName))
            {
                errors.Add("First Name is Required");
            }
            if (string.IsNullOrEmpty(data.LastName))
            {
                errors.Add("Last Name is Required");
            }
            if (string.IsNullOrEmpty(data.Password))
            {
                errors.Add("Password is Required");
            }
            if (string.IsNullOrEmpty(data.Mobile))
            {
                errors.Add("Mobile is Required");
            }
            if (!string.IsNullOrEmpty(data.Mobile) && !Formats.IsMobile(data.Mobile))
            {
                errors.Add("Mobile is invalid format");
            }
            return errors;
        }
    }
}
