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

		public void Run()
		{
            _consoleWrapper.WriteLine("Welcome to the PhotoApp");
            _consoleWrapper.WriteLine("Pick album you want to see (1-100)");
            _consoleWrapper.Write("Please enter a valid choice: ");
        }
	}
}

