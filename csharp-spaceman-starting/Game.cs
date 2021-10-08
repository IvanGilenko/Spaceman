using System;

namespace Spaceman{

  class Game{
    
    //Fields
    private string codeword;
    private string currentWord;
    private int maxGuesses;
    private int wrongGuesses;
    private string[] wordbank= {"genshin", "string", "int", "double"};
    private Ufo ufo = new Ufo();
    private Random rnd = new Random();

    //Constructor
    public Game(){
      codeword = wordbank[rnd.Next(4)];
      maxGuesses = 5;
      wrongGuesses = 0;
      currentWord = "".PadLeft(codeword.Length, '_');
    }

    //Methods
    public void Greet(){
      Console.Write("Greetings");
    }

    public bool DidWin(){
      return codeword.Equals(currentWord);
    }

    public bool DidLose(){
      return (wrongGuesses >= maxGuesses);
    }

    public void Display(){
      Console.WriteLine(ufo.Stringify());
      Console.WriteLine($"Current Word: {currentWord}");
      Console.WriteLine($"Number of guesses remaining: {maxGuesses - wrongGuesses}");
    }

    public void Ask(){
      Console.WriteLine("Enter a letter: ");
      string entrada = Console.ReadLine();
      if(entrada.Length > 1){
        Console.WriteLine("Wrong man!");
      }
      else{
        char letter = char.Parse(entrada);
        if(codeword.Contains(letter)){
          Console.WriteLine($"The letter {letter} is in the word");
          int index = codeword.IndexOf(letter);
          currentWord = currentWord.Remove(index, 1).Insert(index, letter.ToString());
        }
        else{
          Console.WriteLine("Wrong letter!");
          wrongGuesses++;
          ufo.AddPart();
        }
        
      }
    }

  }
}