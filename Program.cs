class Program
{
  static void Main(string[] args)
  {
    if (args.Length == 0)
    {
      Console.WriteLine("Specify a file path");
      return;
    }
    string path = args[0];
    if (!File.Exists(path))
    {
      Console.WriteLine("There is no such file.");
      return;
    }

    StreamReader reader = new StreamReader(path);

    int linesCount = 0;
    string? line;
    while ((line = reader.ReadLine()) != null)
    {
      Console.WriteLine(++linesCount + "-" + line);
    }
  }
}