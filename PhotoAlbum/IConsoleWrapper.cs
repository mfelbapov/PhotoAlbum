namespace PhotoAlbum
{
	public interface IConsoleWrapper
    {
        void Write(string value);
        void WriteLine(string value);
        ConsoleKeyInfo ReadKey();
        int Read();
        string? ReadLine();
        void Clear();
    }
}

