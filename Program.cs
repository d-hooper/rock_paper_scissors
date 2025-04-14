internal class Program
{
  private static void Main(string[] args)
  {
    Console.Clear();
    Console.WriteLine("Rock Paper Scissors");
    Console.WriteLine();
    string userHand = ChooseHand();
    Console.WriteLine();
    string computerHand = GetComputerHand();
    Console.WriteLine();
    Console.WriteLine($"You chose {userHand}.");
    Console.WriteLine();
    Console.WriteLine($"The computer chose {computerHand}.");
    Console.WriteLine();
    if (userHand == computerHand)
    {
      Console.WriteLine("It's a tie.");
    }
    if ((userHand == "rock" && computerHand == "paper") || (userHand == "paper" && computerHand == "scissors") || (userHand == "scissors" && computerHand == "rock"))
    {
      Console.WriteLine("The computer wins...");
      return;
    }
    else
    {
      Console.WriteLine("You win!");
    }
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
}