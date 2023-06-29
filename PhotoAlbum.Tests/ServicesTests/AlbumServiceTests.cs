using Moq;
using PhotoAlbum.ApiClient;
using PhotoAlbum.Services;

namespace PhotoAlbum.Tests.ServicesTests
{
	public class AlbumServiceTests
	{
		[Test]
		public async Task Should_CallApiClientWithCorrectAlbumId()
		{
            Mock<IAlbumApiClient> clientMock = new Mock<IAlbumApiClient>();

            var albumId = 12;

			var sut = new AlbumService(clientMock.Object);

			await sut.GetAlbumAsync(albumId);

			clientMock.Verify(x => x.GetAlbum(albumId), Times.Once);
		}
	}
}