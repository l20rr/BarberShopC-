using BarberShop2024.Shared;

namespace BarberShop2024.Server.Model
{
    public interface IUserModel
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
        Task<User> AddUser(User user);
        User UpdateUser(int userId, User user);
        void DeleteUser(int userId);
    }
}
