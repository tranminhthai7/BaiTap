using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.WebApplication.Pages.Accounts;
using System.Threading.Tasks;

namespace LogoutTests
{
    [TestFixture]
    public class LogoutModelTests
    {
        private LogoutModel _logoutModel;
        private Mock<HttpResponse> _mockHttpResponse;

        [SetUp]
        public void SetUp()
        {
            // Mock HttpResponse và Cookie Collection
            _mockHttpResponse = new Mock<HttpResponse>();
            var mockCookies = new Mock<IResponseCookies>();
            _mockHttpResponse.Setup(r => r.Cookies).Returns(mockCookies.Object);

            // Mock HttpContext
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(c => c.Response).Returns(_mockHttpResponse.Object);

            // Mock PageContext
            _logoutModel = new LogoutModel
            {
                PageContext = new PageContext
                {
                    HttpContext = mockHttpContext.Object
                }
            };
        }

        [Test]
        public async Task OnGetAsync_ClearsCookiesAndRedirectsToLogin()
        {
            // Act
            var result = await _logoutModel.OnGetAsync();

            // Assert
            // Kiểm tra xem cookie "UserEmail", "UserName", "UserFullName" đã được xóa
            _mockHttpResponse.Verify(r => r.Cookies.Delete("UserEmail"), Times.Once);
            _mockHttpResponse.Verify(r => r.Cookies.Delete("UserName"), Times.Once);
            _mockHttpResponse.Verify(r => r.Cookies.Delete("UserFullName"), Times.Once);

            // Kiểm tra kết quả trả về là RedirectToPageResult
            Assert.That(result, Is.TypeOf<RedirectToPageResult>());
            var redirectResult = result as RedirectToPageResult;
            Assert.That(redirectResult.PageName, Is.EqualTo("/Accounts/Login"));
        }
    }
}