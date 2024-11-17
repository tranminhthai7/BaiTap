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


namespace TestLogin
{
    [TestFixture]
    public class LoginModelTests
    {
        [Test]
        public async Task OnPostAsync_WhenEmailOrPasswordEmpty_ReturnsErrorMessage()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            var loginModel = new LoginModel(mockUserService.Object)
            {
                Email = "",  // Không nhập Email
                Password = "" // Không nhập Password
            };

            // Act
            var result = await loginModel.OnPostAsync();

            // Assert
            Assert.That(result, Is.TypeOf<PageResult>()); // Kiểm tra xem có phải PageResult không (không chuyển hướng)
            Assert.That(loginModel.ErrorMessage, Is.EqualTo("Email hoặc mật khẩu không được để trống.")); // Kiểm tra thông báo lỗi
        }

        [Test]
        public async Task OnPostAsync_WhenLoginSuccessful_SetsCookiesAndRedirects()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.LoginAsync("test@example.com", "password123"))
                .ReturnsAsync(new User
                {
                    Email = "test@example.com",
                    UserName = "TestUser",
                    FullName = "Test User"
                });

            var loginModel = new LoginModel(mockUserService.Object)
            {
                Email = "test@example.com",
                Password = "password123"
            };

            // Mock HttpContext and Response Cookies
            var mockHttpContext = new Mock<HttpContext>();
            var mockResponse = new Mock<HttpResponse>();
            var mockCookies = new Mock<IResponseCookies>();

            // Setup the mock to handle the cookie appending
            mockResponse.Setup(r => r.Cookies).Returns(mockCookies.Object);
            mockHttpContext.Setup(c => c.Response).Returns(mockResponse.Object);

            var pageContext = new PageContext(new ActionContext(mockHttpContext.Object, new RouteData(), new PageActionDescriptor()));
            loginModel.PageContext = pageContext;

            // Act
            var result = await loginModel.OnPostAsync();

            // Assert
            mockCookies.Verify(c => c.Append("UserEmail", "test@example.com", It.IsAny<CookieOptions>()), Times.Once);
            mockCookies.Verify(c => c.Append("UserName", "TestUser", It.IsAny<CookieOptions>()), Times.Once);
            mockCookies.Verify(c => c.Append("UserFullName", "Test User", It.IsAny<CookieOptions>()), Times.Once);

            Assert.That(result, Is.TypeOf<RedirectToPageResult>());
            var redirectResult = (RedirectToPageResult)result;
            Assert.That(redirectResult.PageName, Is.EqualTo("/Accounts/Index"));
        }

        [Test]
        public async Task OnPostAsync_WhenLoginFails_ReturnsErrorMessage()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(x => x.LoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((User)null); // Trả về null khi đăng nhập thất bại

            var loginModel = new LoginModel(mockUserService.Object)
            {
                Email = "wrong@example.com",
                Password = "wrongpassword"
            };

            // Act
            var result = await loginModel.OnPostAsync();

            // Assert
            Assert.That(result, Is.TypeOf<PageResult>()); // Kiểm tra nếu là PageResult (không chuyển hướng)
            Assert.That(loginModel.ErrorMessage, Is.EqualTo("Email hoặc mật khẩu không chính xác.")); // Kiểm tra thông báo lỗi
        }
    }

}