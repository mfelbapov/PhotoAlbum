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

            if (!Enumerable.Range(1, 100).Contains(input))
            {
                _consoleWrapper.Clear();
                _consoleWrapper.Write("ENTER VALID CHOICE: Number between 1 and 100");
            }

            var result = await _albumService.GetAlbumAsync(input);

            if (!result.Photos.Any())
            {
                _consoleWrapper.Clear();
                _consoleWrapper.WriteLine($"Photo Album {result.Id} Has No Photos");
            }

            
        }
	}
}

