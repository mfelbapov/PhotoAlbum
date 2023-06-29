﻿using NSubstitute;
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
        public async Task Should_DisplayInstructionPrompts()
        {
            _consoleWrapper.ReadLine().Returns("12");
            await _sut.Run();

            Received.InOrder(() =>
            {
                _consoleWrapper.WriteLine("Welcome to the PhotoApp");
                _consoleWrapper.WriteLine("Pick an album you want to see (1-100)");
                _consoleWrapper.Write("Please enter a valid choice: ");
            });
        }

        [Test]
        public async Task Given_ValidInput_When_Run_Then_CallsAlbumServiceWithCorrectAlbumNumber()
        {
            var expectedPhotoAlbum = 12;
            _consoleWrapper.ReadLine().Returns($"{expectedPhotoAlbum}");
            await _sut.Run();

            await _albumService.Received().GetAlbumAsync(expectedPhotoAlbum);
        }

        [TestCase("-1")]
        [TestCase("0")]
        [TestCase("101")]
        [TestCase("a")]
        [TestCase("Z")]
        [TestCase("!")]
        public async Task Given_InvalidNumericalInput_When_Run_Then_ClearsAndResetsThePrompt(string input)
        {
            await _sut.Run();

            _consoleWrapper.ReadLine().Returns(input);

            _consoleWrapper.Received().Clear();
            _consoleWrapper.Received().Write("ENTER VALID CHOICE: Number between 1 and 100");
        }
    }
}

