using System.Diagnostics;
using System.Reflection.Metadata;

class Program
{
  private static void addWordToDictionary(Dictionary<string, int> dictionary, string dictionaryWord)
  {
    if (dictionaryWord.Length > 0)
    {
      if (dictionary.ContainsKey(dictionaryWord))
      {
        dictionary[dictionaryWord] += 1;
      }
      else
      {
        dictionary[dictionaryWord] = 1;
      }
    }
  }

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
    string word = "";
    Dictionary<string, int> words = new Dictionary<string, int>();

    bool previousCharSpaceValue = false;

    string? line;
    while ((line = reader.ReadLine()) != null)
    {
      charactersCount += line.Length;

      foreach (var character in line)
      {
        if (!((character >= 'A' && character <= 'Z') || (character >= 'a' && character <= 'z')) && character != '#' && character != '@')
        {
          if (!previousCharSpaceValue) previousCharSpaceValue = true;

          if (word.Length > 1) addWordToDictionary(words, word.ToLower());
          word = ""; //flash the contents
        }
        else
        {
          previousCharSpaceValue = false;
          ++nonSpaceCharactersCount;
          word += character;
        }
      }

      ++linesCount;
      addWordToDictionary(words, word);
      word = ""; //flash the contents
    }

    int wordsNumber = 0;
    foreach (var pair in words)
    {
      wordsNumber += pair.Value;
    }

    var sorted = words
    .OrderByDescending(kvp => kvp.Value)
    .ToList();


    Console.WriteLine("number of lines: " + linesCount);
    Console.WriteLine("number of characters: " + (charactersCount + linesCount - 1)); //For \n characters
    Console.WriteLine("number of non-space characters: " + nonSpaceCharactersCount);
    Console.WriteLine("number of words: " + wordsNumber);
    Console.WriteLine("number of words base on Dictionary: " + words.Count);

    Console.WriteLine("Top 5 frequent words: ");
    var count = 0;
    foreach (var pair in sorted)
    {
      Console.WriteLine($"{pair.Key}: {pair.Value}");
      count++;
      if (count >= 5) break;
    }

  }
}