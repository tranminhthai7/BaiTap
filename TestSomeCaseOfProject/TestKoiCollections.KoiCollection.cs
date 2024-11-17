using NUnit.Framework;
using Moq;
using KoiFarmShop.Services.Interfaces;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.WebApplication.Pages.KoiCollections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestKoiCollections.KoiCollection
{
    [TestFixture]
    public class KoiCollectionModelTests
    {
        private Mock<IKoiService> _mockKoiService;
        private KoiCollectionModel _koiCollectionModel;

        [SetUp]
        public void SetUp()
        {
            // Khởi tạo Mock IKoiService
            _mockKoiService = new Mock<IKoiService>();

            // Khởi tạo KoiCollectionModel với Mock IKoiService
            _koiCollectionModel = new KoiCollectionModel(_mockKoiService.Object);
        }

        [Test]
        public async Task OnGetAsync_CallsGetKoisAndSetsKoiCollection()
        {
            // Arrange: Giả lập dữ liệu trả về từ IKoiService
            var koiList = new List<Koi>
            {
                new Koi { KoiId = 1, Name = "Koi 1" },
                new Koi { KoiId = 2, Name = "Koi 2" }
            };
            _mockKoiService.Setup(service => service.GetKois()).ReturnsAsync(koiList);

            // Act: Gọi OnGetAsync
            await _koiCollectionModel.OnGetAsync();

            // Assert: Kiểm tra GetKois được gọi và KoiCollection được gán đúng
            _mockKoiService.Verify(service => service.GetKois(), Times.Once);
            Assert.That(_koiCollectionModel.KoiCollection, Is.EqualTo(koiList));
        }

        [Test]
        public async Task OnGetAsync_WhenGetKoisReturnsNull_SetsKoiCollectionToEmpty()
        {
            // Arrange: Giả lập null trả về từ GetKois
            _mockKoiService.Setup(service => service.GetKois()).ReturnsAsync((List<Koi>?)null);

            // Act: Gọi OnGetAsync
            await _koiCollectionModel.OnGetAsync();

            // Assert: KoiCollection phải là danh sách trống
            Assert.That(_koiCollectionModel.KoiCollection, Is.Not.Null, "KoiCollection không được phép là null.");
            Assert.That(_koiCollectionModel.KoiCollection, Is.Empty, "KoiCollection phải là danh sách trống.");
        }
    }
}
