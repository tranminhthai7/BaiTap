using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
namespace KoiFarmShop.Repositories.Interfaces
{
    public interface IUserRepository
    {
        // lay danh sách acccount
        Task<List<User>> GetUsers();
        Boolean DelUser(int Id);
        Boolean DelUser(User account);
        Boolean AddUser(User account);
        Boolean UpdUser(User account);
        Task<User> GetUserById(int Id);
    }

}
