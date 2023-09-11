using AeroBook.Data;
using AeroBook.Data.Models.Account;
using AeroBook.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AeroBook.Repository
{
    public class AccountRepository: IAccountRepository
    {
        private readonly AeroBookDbContext _dbContext;
        public AccountRepository(AeroBookDbContext context) 
        {
            _dbContext = context;
        }
        public void SignUp(User user)
        {
            User userdata = new User();
            userdata.Email =   user.Email;
            userdata.Password= user.Password;
            userdata.Name= user.Name;
             _dbContext.Users.Add(userdata);
             _dbContext.SaveChanges();
        }
        public User Login(string Email, string Password)
        {
           return _dbContext.Users?.FirstOrDefault(u => u.Email == Email);
        }
    }
}
