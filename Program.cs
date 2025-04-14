using System.Text.Json;
using System.Collections.Generic;

internal class Program
{

  static int PlayerWins = 0;
  static int ComputerWins = 0;

  private static void Main()
  {
    LoadGame();

    Dictionary<string, string> winConditions = new Dictionary<string, string>();

    winConditions.Add("rock", "scissors");
    winConditions.Add("scissors", "paper");
    winConditions.Add("paper", "rock");

    Console.Clear();
    Console.WriteLine("Rock Paper Scissors\n");
    if (PlayerWins > 0 || ComputerWins > 0)
    {
      Console.WriteLine($"Ongoing Score Tally: You - {PlayerWins} | Computer - {ComputerWins}\n");
    }
    string userHand = ChooseHand();
    string computerHand = GetComputerHand();

    Console.WriteLine($"You chose {userHand}.\n");
    Console.WriteLine($"The computer chose {computerHand}.\n");

    string myHandBeats = winConditions[userHand];

    if (userHand == computerHand)
    {
      Console.WriteLine("It's a tie.");
    }

    else if (myHandBeats == computerHand)
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("You win!\n");
      PlayerWins++;
      Console.ResetColor();
    }
    else
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("The computer wins...\n");
      ComputerWins++;
      Console.ResetColor();
    }


    Console.WriteLine($"Score Tally: You - {PlayerWins} | Computer - {ComputerWins}\n");
    SaveGame(PlayerWins, ComputerWins);
    Replay();
  }

  static string ChooseHand()
  {
    Console.WriteLine("Choose Your Hand Shape");
    Console.WriteLine("1. Rock");
    Console.WriteLine("2. Paper");
    Console.WriteLine("3. Scissors\n");
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
        Console.Clear();
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
    Console.WriteLine("Would you like to play again? ( y / n )\n");
    Console.WriteLine();
    string? choice = Console.ReadLine();
    if (choice != "y" && choice != "n")
    {
      Console.Clear();
      Console.WriteLine("Invalid input option, try again.\n");
      Replay();
    }
    if (choice == "y")
    {
      Main();
    }
    Environment.Exit(0);
  }

  static void SaveGame(int playerWins, int computerWins)
  {
    SaveData save = new(playerWins, computerWins);
    string saveData = JsonSerializer.Serialize(save);
    File.WriteAllText("saveGame.json", saveData);
  }

  static void LoadGame()
  {
    if (!File.Exists("saveGame.json")) return;
    string jsonString = File.ReadAllText("saveGame.json");
    SaveData? data = JsonSerializer.Deserialize<SaveData>(jsonString);

    if (data != null)
    {
      PlayerWins = data.PlayerWins;
      ComputerWins = data.ComputerWins;
    }
  }
}

internal class SaveData
{
  public int PlayerWins { get; set; }
  public int ComputerWins { get; set; }

  public SaveData(int playerWins, int computerWins)
  {
    PlayerWins = playerWins;
    ComputerWins = computerWins;
  }
}