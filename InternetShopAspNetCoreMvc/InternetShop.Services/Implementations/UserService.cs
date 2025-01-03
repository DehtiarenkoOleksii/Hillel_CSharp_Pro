using InternetShop.Data.Models;
using InternetShop.Repositories.Repositories.Interfaces;
using InternetShop.Services.Interfaces;


namespace InternetShop.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id) ?? throw new Exception("User not found");
        }

        public async Task AddUserAsync(User user)
        {
            if (string.IsNullOrEmpty(user.Username))
            {
                throw new Exception("Username cannot be empty");
            }
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
