using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.Services.Interfaces;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.WebApplication.Pages.Accounts;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterTests
{
    [TestFixture]
    public class RegisterModelTests
    {
        private Mock<IUserService> _mockUserService;
        private RegisterModel _registerModel;

        [SetUp]
        public void SetUp()
        {
            // Khởi tạo Mock cho IUserService
            _mockUserService = new Mock<IUserService>();

            // Khởi tạo RegisterModel với Mock IUserService
            _registerModel = new RegisterModel(_mockUserService.Object);
        }

        [Test]
        public async Task OnPostAsync_WithInvalidModelState_ReturnsPage()
        {
            // Arrange: Giả lập ModelState không hợp lệ
            _registerModel.ModelState.AddModelError("UserName", "UserName is required");

            // Act
            var result = await _registerModel.OnPostAsync();

            // Assert: Kiểm tra kết quả trả về là PageResult
            Assert.That(result, Is.TypeOf<PageResult>());
        }

        [Test]
        public async Task OnPostAsync_WithValidInput_RegistersUserAndRedirectsToIndex()
        {
            // Arrange: Cài đặt thông tin người dùng hợp lệ
            _registerModel.Input = new User
            {
                UserName = "TestUser",
                Password = "password123",
                FullName = "Test User",
                Email = "test@example.com",
                Phone = "0123456789",
                Address = "123 Test Street"
            };

            // Mock dịch vụ trả về đối tượng User khi đăng ký thành công
            _mockUserService.Setup(s => s.RegisterAsync(
                _registerModel.Input.UserName,
                _registerModel.Input.Password,
                _registerModel.Input.FullName,
                _registerModel.Input.Email,
                _registerModel.Input.Phone,
                _registerModel.Input.Address))
                .ReturnsAsync(new User
                {
                    UserName = "TestUser",
                    Email = "test@example.com"
                });

            // Act
            var result = await _registerModel.OnPostAsync();

            // Assert: Kiểm tra kết quả trả về là RedirectToPageResult
            Assert.That(result, Is.TypeOf<RedirectToPageResult>());
            var redirectResult = result as RedirectToPageResult;
            Assert.That(redirectResult.PageName, Is.EqualTo("/Index"));
        }

        [Test]
        public async Task OnPostAsync_WhenRegisterFails_ReturnsPageWithErrorMessage()
        {
            // Arrange: Cài đặt thông tin người dùng
            _registerModel.Input = new User
            {
                UserName = "TestUser",
                Password = "password123",
                FullName = "Test User",
                Email = "test@example.com",
                Phone = "0123456789",
                Address = "123 Test Street"
            };

            // Mock dịch vụ trả về null khi đăng ký thất bại
            _mockUserService.Setup(s => s.RegisterAsync(
                _registerModel.Input.UserName,
                _registerModel.Input.Password,
                _registerModel.Input.FullName,
                _registerModel.Input.Email,
                _registerModel.Input.Phone,
                _registerModel.Input.Address))
                .ReturnsAsync((User?)null);

            // Act
            var result = await _registerModel.OnPostAsync();

            // Assert: Kiểm tra lỗi trong ModelState và kết quả trả về là PageResult
            var errorMessage = _registerModel.ModelState[string.Empty]?.Errors.FirstOrDefault()?.ErrorMessage;
            Assert.That(result, Is.TypeOf<PageResult>());
            Assert.That(errorMessage, Is.EqualTo("Email đã tồn tại hoặc có lỗi khi đăng ký."));
        }
    }
}