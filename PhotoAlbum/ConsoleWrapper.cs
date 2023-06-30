namespace PhotoAlbum
{
    public class ConsoleWrapper : IConsoleWrapper
	{
        public void Clear()
        {
            Console.Clear();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public int Read()
        {
            return Console.Read();
        }

        public string? ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}

