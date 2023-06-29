using PhotoAlbum.ApiClient;
using PhotoAlbum.Models;

namespace PhotoAlbum.Services
{
	public class AlbumService : IAlbumService
	{
		IAlbumApiClient _albumApiClient;
		public AlbumService(IAlbumApiClient albumApiClient)
		{
			_albumApiClient = albumApiClient;
		}

		public async Task<Album> GetAlbumAsync(int albumId)
		{
			var result = await _albumApiClient.GetAlbum(albumId);
			return new Album(albumId, result);
		}
	}
}

