using System.Net;
using FluentAssertions;
using Moq;
using Moq.Protected;
using PhotoAlbum.ApiClient;
using PhotoAlbum.Models;

namespace PhotoAlbum.Tests.ApiClientTests
{
    public class ApiAlbumClientTests
	{
		[Test]
		public async Task Should_GetPhotos_When_SuccessfullResponse()
		{
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent("[{'albumId':1, 'id':1, 'title':'photo title'}]")
               })
               .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com/photos?albumId="),
            };

            var expectedContent = new List<Photo> { new Photo(1, 1, "photo title")};

            var _sut = new AlbumApiClient(httpClient);

            var result = await _sut.GetAlbum(1);
            
            result.Should().BeEquivalentTo(expectedContent);
        }
	}
}

