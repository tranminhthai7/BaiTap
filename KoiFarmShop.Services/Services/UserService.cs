using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Services.Interfaces;
using KoiFarmShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace KoiFarmShop.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        // Constructor để khởi tạo repository
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        // Hàm đăng nhập
        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _repository.GetUserByEmailAsync(email);
            if (user != null && VerifyPassword(password, user.Password))
            {
                return user;
            }
            return null;
        }

        // Hàm đăng ký người dùng
        public async Task<User> RegisterAsync(string userName, string password, string fullName, string email, string phone, string address)
        {
            var newUser = new User
            {
                UserName = userName,
                Password = HashPassword(password),  // Mã hóa mật khẩu
                FullName = fullName,
                Email = email,
                Phone = phone,
                Address = address,
                CreateDate = DateTime.Now
            };
            return await _repository.RegisterUserAsync(newUser);
        }

        // Mã hóa mật khẩu sử dụng SHA-256
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // Kiểm tra mật khẩu đã nhập so với mật khẩu lưu trữ
        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return storedPassword == HashPassword(enteredPassword);
        }

        // Phương thức đăng ký người dùng bằng cách truyền vào đối tượng User
        public async Task<bool> RegisterUserAsync(User user)
        {
            try
            {
                // Kiểm tra xem email đã tồn tại trong hệ thống chưa
                var existingUser = await _repository.GetUserByEmailAsync(user.Email);
                if (existingUser != null)
                {
                    // Nếu người dùng đã tồn tại, trả về false
                    return false;
                }

                // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
                user.Password = HashPassword(user.Password);

                // Thêm người dùng mới vào cơ sở dữ liệu thông qua repository
                _repository.AddUser(user);


                return true; // Đăng ký thành công
            }
            catch (Exception ex)
            {
                // Ghi lại log hoặc xử lý ngoại lệ nếu cần thiết
                Console.WriteLine($"Lỗi khi đăng ký người dùng: {ex.Message}");
                return false; // Đăng ký thất bại
            }
        }

        // Các phương thức khác như thêm, xóa, cập nhật người dùng
        public bool AddUser(User user)
        {
            return _repository.AddUser(user);
        }

        public bool DelUser(int Id)
        {
            return _repository.DelUser(Id);
        }

        public bool DelUser(User user)
        {
            return _repository.DelUser(user);
        }

        public Task<User> GetUserById(int Id)
        {
            return _repository.GetUserById(Id);
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> users = await _repository.GetUsers();
            return users;
        }

        public bool UpdUser(User user)
        {
            return _repository.UpdUser(user);
        }

        public async Task<List<User>> GetUsersByCondition(string condition)
        {
            List<User> users = await GetUsers();
            var filteredUsers = users.Where(u => u.UserName.Contains(condition)).ToList();
            return filteredUsers;
        }

        public Task AddUserAsync(User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
