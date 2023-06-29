using Newtonsoft.Json;
using PhotoAlbum.Models;

namespace PhotoAlbum.ApiClient
{
	public class AlbumApiClient
	{
		private const string BASE_ALBUM_URL = "https://jsonplaceholder.typicode.com/photos?albumId=";
        private readonly HttpClient _client;

        public AlbumApiClient(HttpClient client)
		{
			_client = client;
        }

		public async Task<List<Photo>?> GetAlbum(int albumId)
		{
			List<Photo> result = new List<Photo>();
			var response = await _client.GetAsync($"{BASE_ALBUM_URL}{albumId}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Photo>>(json);
            }

            return result;
		}
    }
}

