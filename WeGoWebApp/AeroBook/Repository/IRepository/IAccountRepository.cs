using AeroBook.Data.Models.Account;

namespace AeroBook.Repository.IRepository
{
    public interface IAccountRepository
    {
        void SignUp(User user);
        User Login(string Email,string Password);
    }
}
