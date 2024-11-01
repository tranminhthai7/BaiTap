using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
namespace KoiFarmShop.Services.Interfaces
{
    public interface IUserService
    {
        // lay danh sách acccount
        Task<List<User>> GetAllUser();
        Boolean DelUser(int Id);
        Boolean DelUser(User account);
        Boolean AddUser(User account);
        Boolean UpdUser(User account);
        Task<User> GetUserById(int Id);
    }

}
