using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiFarmShop.Services.Interfaces;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.WebApplication.Pages.Contact;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ContactTests
{
    [TestFixture]
    public class ContactModelTests
    {
        private Mock<IContactService> _mockContactService;
        private ContactModel _contactModel;

        [SetUp]
        public void SetUp()
        {
            _mockContactService = new Mock<IContactService>();
            _contactModel = new ContactModel(_mockContactService.Object);
        }

        [Test]
        public void OnGet_WhenContactPostedQueryExists_SetsSuccessMessage()
        {
            var mockHttpContext = new Mock<HttpContext>();
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(r => r.Query["contact_posted"]).Returns("true");
            mockHttpContext.Setup(c => c.Request).Returns(mockRequest.Object);

            _contactModel.PageContext = new PageContext
            {
                HttpContext = mockHttpContext.Object
            };

            _contactModel.OnGet();

            Assert.That(_contactModel?.SuccessMessage, Is.EqualTo("Liên hệ đã được gửi thành công!"));
        }

        [Test]
        public async Task OnPostAsync_WhenModelStateIsInvalid_ReturnsPageResult()
        {
            _contactModel.ModelState.AddModelError("Name", "Name is required");

            var result = await _contactModel.OnPostAsync();

            Assert.That(result, Is.TypeOf<PageResult>());
        }

        [Test]
        public async Task OnPostAsync_WhenContactIsValid_CallsAddContactAndRedirects()
        {
            _contactModel.Contact = new Contact
            {
                Name = "Test User",
                Email = "test@example.com"
            };

            var result = await _contactModel.OnPostAsync();

            _mockContactService.Verify(s => s.AddContact(It.IsAny<Contact>()), Times.Once);
            Assert.That(result, Is.TypeOf<RedirectToPageResult>());

            var redirectResult = result as RedirectToPageResult;
            Assert.That(redirectResult.PageName, Is.EqualTo("/Contact/Contact"));
            Assert.That(redirectResult.RouteValues["contact_posted"], Is.EqualTo(true));
        }
    }
}