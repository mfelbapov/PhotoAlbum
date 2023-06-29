using PhotoAlbum.Models;

namespace PhotoAlbum.Services
{
	public interface IAlbumService
	{
        Task<Album> GetAlbumAsync(int albumId);
    }
}

