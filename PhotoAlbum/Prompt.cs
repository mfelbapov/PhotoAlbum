using PhotoAlbum.Services;

namespace PhotoAlbum
{
	public class Prompt
	{
        private readonly IAlbumService _albumService;
        private readonly IConsoleWrapper _consoleWrapper;

        public Prompt(IAlbumService albumService, IConsoleWrapper consoleWrapper)
		{
            _albumService = albumService;
            _consoleWrapper = consoleWrapper;
        }

		public async Task Run()
		{
            _consoleWrapper.WriteLine("Welcome to the PhotoApp");
            _consoleWrapper.WriteLine("Pick an album you want to see (1-100)");
            _consoleWrapper.Write("Please enter a valid choice: ");

            int.TryParse(_consoleWrapper.ReadLine(), out var input);

            await _albumService.GetAlbumAsync(input);
        }
	}
}

