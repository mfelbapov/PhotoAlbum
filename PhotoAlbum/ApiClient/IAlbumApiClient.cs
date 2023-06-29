using PhotoAlbum.Models;

namespace PhotoAlbum.ApiClient
{
	public interface IAlbumApiClient
	{
        Task<List<Photo>?> GetAlbum(int albumId);
    }
}

