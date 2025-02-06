using TTATAutomation.Models;
using TTATAutomation.Repositories.Interfaces;
using TTATAutomation.Services.Interfaces;
using BCrypt.Net;

namespace TTATAutomation.Services
{
    public class UserService : IUserService
    {


        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            var user = await _unitOfWork.UserRepository.GetByEmailAsync(email);
            if (user == null || !VerifyPassword(password, user.Password))
                return null; // Authentication failed

            return user; // Authentication successful
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _unitOfWork.UserRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task RegisterUserAsync(User user)
        {
            user.Id = Guid.NewGuid();
            user.Password = HashPassword(user.Password); // Hash the password before storing
            user.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var existingUser = await _unitOfWork.UserRepository.GetByIdAsync(user.Id);
            if (existingUser == null) return false;

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.Role = user.Role;
            existingUser.LastUpdatedAt = DateTime.UtcNow;

            await _unitOfWork.UserRepository.UpdateAsync(existingUser);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null) return false;

            await _unitOfWork.UserRepository.DeleteAsync(user);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _unitOfWork.UserRepository.GetByEmailAsync(email);
        }
    }
}