using System.Diagnostics;
using System.Reflection.Metadata;

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
    int nonSpaceCharactersCount = 0;
    int charactersCount = 0;
    int wordsCount = 0;

    bool previousCharSpaceValue = false;
    bool lineHasValue = false;

    string? line;
    while ((line = reader.ReadLine()) != null)
    {
      charactersCount += line.Length;

      foreach (var character in line)
      {
        lineHasValue = true; 
        if (character == ' ')
        {
          if (!previousCharSpaceValue)
          {
            previousCharSpaceValue = true;
            ++wordsCount;
          }
        }
        else
        {
          previousCharSpaceValue = false;
          ++nonSpaceCharactersCount;
        }
      }

      if (lineHasValue) ++wordsCount;  //In this way we can add the last word on the line (if there is any word).
      ++linesCount;
      lineHasValue = false;
    }

    Console.WriteLine("number of lines: " + linesCount);
    Console.WriteLine("number of characters: " + (charactersCount + linesCount - 1)); //For \n characters
    Console.WriteLine("number of non-space characters: " + nonSpaceCharactersCount);
    Console.WriteLine("number of words: " + wordsCount);
  }
}