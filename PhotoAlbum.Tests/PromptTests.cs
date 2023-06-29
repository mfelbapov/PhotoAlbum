using NSubstitute;
using PhotoAlbum.Services;

namespace PhotoAlbum.Tests
{
	public class PromptTests
    {
        Prompt _sut;
        IAlbumService _albumService;
        IConsoleWrapper _consoleWrapper;

        [SetUp]
        public void Setup()
        {
            _albumService = Substitute.For<IAlbumService>();
            _consoleWrapper = Substitute.For<IConsoleWrapper>();
            _sut = new Prompt(_albumService, _consoleWrapper);
        }

        [Test]
        public void Should_DisplayInstructionPrompts()
        {
            _consoleWrapper.ReadLine().Returns("12");
            _sut.Run();

            Received.InOrder(() =>
            {
                _consoleWrapper.WriteLine("Welcome to the PhotoApp");
                _consoleWrapper.WriteLine("Pick album you want to see (1-100)");
                _consoleWrapper.Write("Please enter a valid choice: ");
            });
        }
    }
}

