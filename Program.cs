internal class Program
{

  static int PlayerWins = 0;
  static int ComputerWins = 0;
  private static void Main()
  {
    Console.Clear();
    Console.WriteLine("Rock Paper Scissors");
    Console.WriteLine();
    string userHand = ChooseHand();
    Console.WriteLine();
    string computerHand = GetComputerHand();
    Console.WriteLine($"You chose {userHand}.");
    Console.WriteLine();
    Console.WriteLine($"The computer chose {computerHand}.");
    Console.WriteLine();
    if (userHand == computerHand)
    {
      Console.WriteLine("It's a tie.");
    }
    else if ((userHand == "rock" && computerHand == "paper") || (userHand == "paper" && computerHand == "scissors") || (userHand == "scissors" && computerHand == "rock"))
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("The computer wins...");
      ComputerWins++;
      Console.ResetColor();
    }
    else
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("You win!");
      PlayerWins++;
      Console.ResetColor();
    }

    Console.WriteLine();
    Console.WriteLine($"Score Tally: You - {PlayerWins} | Computer - {ComputerWins}");
    Replay();
  }

  static string ChooseHand()
  {
    Console.WriteLine("Choose Your Hand Shape");
    Console.WriteLine("1. Rock");
    Console.WriteLine("2. Paper");
    Console.WriteLine("3. Scissors");
    Console.WriteLine("Input '1' / '2' / '3' to select the respective option.");
    string? choice = Console.ReadLine();
    switch (choice)
    {
      case ("1"):
        choice = "rock";
        return choice;
      case ("2"):
        choice = "paper";
        return choice;
      case ("3"):
        choice = "scissors";
        return choice;
      default:
        Console.WriteLine("Invalid input option, try again.");
        return ChooseHand();
    }
  }

  static string GetComputerHand()
  {
    int randomNumber = new Random().Next(1, 4);
    string choice = randomNumber.ToString();
    switch (choice)
    {
      case ("1"):
        choice = "rock";
        return choice;
      case ("2"):
        choice = "paper";
        return choice;
      case ("3"):
        choice = "scissors";
        return choice;
      default:
        throw new Exception("No hand shape was selected by the computer.");
    }
  }

  static void Replay()
  {
    Console.WriteLine();
    Console.WriteLine("Would you like to play again? ( y / n )");
    Console.WriteLine();
    string? choice = Console.ReadLine();
    if (choice != "y" && choice != "n")
    {
      Console.WriteLine("Invalid input option, try again.");
      Replay();
    }
    if (choice == "y")
    {
      Main();
    }
    Environment.Exit(0);
  }
}