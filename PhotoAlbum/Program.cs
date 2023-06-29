using PhotoAlbum;
using PhotoAlbum.ApiClient;
using PhotoAlbum.Services;

var httpClient = new HttpClient();
var apiClient = new AlbumApiClient(httpClient);
var albumService = new AlbumService(apiClient);
var consoleWrapper = new ConsoleWrapper();
var consolePrompt = new Prompt(albumService, consoleWrapper);
await consolePrompt.Run();