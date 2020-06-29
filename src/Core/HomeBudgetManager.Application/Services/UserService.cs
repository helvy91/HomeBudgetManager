using HomeBudgetManager.Application.Interfaces.Repositories;
using HomeBudgetManager.Application.Interfaces.Services;
using HomeBudgetManager.Application.Interfaces.Services.User.Dtos;
using HomeBudgetManager.Application.Interfaces.Utils.Cryptography;
using HomeBudgetManager.Application.Services.Base;
using HomeBudgetManager.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace HomeBudgetManager.Application.Services
{
    public class UserService : BaseService<User, int, IUserRepository, UserDto, CreateUserDto, CreateUserDto, GetPagedDto>, IUserService
    {
        private readonly IEncrypter _encrypter;
        
        public UserService(IUserRepository repository, IEncrypter encrypter) : base(repository)
        {
            _encrypter = encrypter ?? throw new ArgumentNullException(nameof(encrypter));
        }

        public async Task<AuthenticateResult> AuthenticateAsync(CreateUserDto dto)
        {
            var result = new AuthenticateResult();
            result.User = await _repository.GetAsync(dto.Login);
            if (result.User == null)
            {
                return result;
            }

            var passwordHash = _encrypter.GetHash(dto.Password, result.User.Salt);
            if (passwordHash != result.User.PasswordHash)
            {
                return result;
            }

            result.Success = true;
            return result;
        }

        public async override Task CreateAsync(CreateUserDto dto)
        {
            string salt = _encrypter.GetSalt(dto.Password);
            string passwordHash = _encrypter.GetHash(dto.Password, salt);

            var user = new User()
            {
                Login = dto.Login,
                PasswordHash = passwordHash,
                Email = dto.Email,
                Salt = salt
            };

            await _repository.AddAsync(user);
        }
    }
}
