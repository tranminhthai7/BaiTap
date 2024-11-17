using NUnit.Framework;
using Moq;
using KoiFarmShop.Services.Interfaces;
using KoiFarmShop.WebApplication.Pages.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using KoiFarmShop.Repositories.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace ChangePasswordTests
{
    [TestFixture]
    public class ChangePasswordModelTests
    {
        private Mock<IUserService> _mockUserService;
        private ChangePasswordModel _changePasswordModel;

        [SetUp]
        public void SetUp()
        {
            // Khởi tạo Mock cho IUserService
            _mockUserService = new Mock<IUserService>();

            // Khởi tạo ChangePasswordModel
            _changePasswordModel = new ChangePasswordModel(_mockUserService.Object);

            // Giả lập HttpContext với cookie
            var mockHttpContext = new Mock<HttpContext>();
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(r => r.Cookies["UserEmail"]).Returns("test@example.com");
            mockHttpContext.Setup(c => c.Request).Returns(mockRequest.Object);

            _changePasswordModel.PageContext = new PageContext
            {
                HttpContext = mockHttpContext.Object
            };
        }

        [Test]
        public async Task OnPostAsync_WhenPasswordsDoNotMatch_ReturnsErrorMessage()
        {
            // Arrange
            _changePasswordModel.CurrentPassword = "currentpassword";
            _changePasswordModel.NewPassword = "newpassword";
            _changePasswordModel.ConfirmNewPassword = "differentpassword";

            // Act
            var result = await _changePasswordModel.OnPostAsync();

            // Assert
            Assert.That(result, Is.TypeOf<PageResult>());
            Assert.That(_changePasswordModel.ErrorMessage, Is.EqualTo("Mật khẩu mới và xác nhận mật khẩu không khớp."));
        }

        [Test]
        public async Task OnPostAsync_WhenUserNotLoggedIn_RedirectsToLoginPage()
        {
            // Arrange: không có cookie UserEmail
            var mockHttpContext = new Mock<HttpContext>();
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(r => r.Cookies["UserEmail"]).Returns((string)null);
            mockHttpContext.Setup(c => c.Request).Returns(mockRequest.Object);

            _changePasswordModel.PageContext.HttpContext = mockHttpContext.Object;

            // Act
            var result = await _changePasswordModel.OnPostAsync();

            // Assert
            Assert.That(result, Is.TypeOf<RedirectToPageResult>());
            var redirectResult = result as RedirectToPageResult;
            Assert.That(redirectResult.PageName, Is.EqualTo("/Accounts/Login"));
        }

        [Test]
        public async Task OnPostAsync_WhenPasswordChangeFails_ReturnsErrorMessage()
        {
            // Arrange
            _changePasswordModel.CurrentPassword = "wrongpassword";
            _changePasswordModel.NewPassword = "newpassword";
            _changePasswordModel.ConfirmNewPassword = "newpassword";

            // Mock dịch vụ thay đổi mật khẩu trả về false
            _mockUserService.Setup(s => s.ChangePasswordAsync("test@example.com", "wrongpassword", "newpassword"))
                .ReturnsAsync(false);

            // Act
            var result = await _changePasswordModel.OnPostAsync();

            // Assert
            Assert.That(result, Is.TypeOf<PageResult>());
            Assert.That(_changePasswordModel.ErrorMessage, Is.EqualTo("Mật khẩu hiện tại không đúng."));
        }

        [Test]
        public async Task OnPostAsync_WhenPasswordChangeSucceeds_ReturnsSuccessMessage()
        {
            // Arrange
            _changePasswordModel.CurrentPassword = "currentpassword";
            _changePasswordModel.NewPassword = "newpassword123";
            _changePasswordModel.ConfirmNewPassword = "newpassword123";

            // Mock dịch vụ thay đổi mật khẩu trả về true
            _mockUserService.Setup(s => s.ChangePasswordAsync("test@example.com", "currentpassword", "newpassword123"))
                .ReturnsAsync(true);

            // Act
            var result = await _changePasswordModel.OnPostAsync();

            // Assert
            Assert.That(result, Is.TypeOf<PageResult>());
            Assert.That(_changePasswordModel.SuccessMessage, Is.EqualTo("Đổi mật khẩu thành công!"));
            Assert.That(string.IsNullOrEmpty(_changePasswordModel.ErrorMessage), Is.True);
        }
    }
}