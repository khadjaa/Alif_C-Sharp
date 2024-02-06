using Erm.BussinessLayer;

internal class Program 
{
    static void Main()
    {
        IRiskProfileService riskProfileService = new RiskProfileService();

        string cmd = String.Empty;
        while (!cmd.Equals(CommandHelper.ExitCommand))
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(CommandHelper.InputSymbol);
            cmd = Console.ReadLine();

            switch (cmd)
            {
                case CommandHelper.CreateRiskProfileCommand:
                    Console.WriteLine("Enter risk profile name:");
                    string rpName = Console.ReadLine();
                    Console.WriteLine("Enter risk profile description:");
                    string rpDescription = Console.ReadLine();
                    Console.WriteLine("Enter business process:");
                    string rpBusinessProcess = Console.ReadLine();
                    int rpOccurreceProbability;
                    Console.WriteLine("Enter occurrence probability:");
                    while (!int.TryParse(Console.ReadLine(), out rpOccurreceProbability))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer value for occurrence probability:");
                    }
                    int rpPotentialBusinessImpact;
                    Console.WriteLine("Enter potential business impact:");
                    while (!int.TryParse(Console.ReadLine(), out rpPotentialBusinessImpact))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer value for potential business impact:");
                    }

                    RiskProfileInfo riskProfileInfo = new()
                    {
                        Name = rpName,
                        Description = rpDescription,
                        BusinessProcess = rpBusinessProcess,
                        OccurreceProbability = rpOccurreceProbability,
                        PotentialBusinessImpact = rpPotentialBusinessImpact
                    };

                    riskProfileService.Create(riskProfileInfo);

                    break;
                case CommandHelper.HelpCommand:
                    Console.WriteLine("> Available commands:");
                    Console.WriteLine(CommandHelper.CreateRiskProfileCommand);
                    Console.WriteLine(CommandHelper.HelpCommand);
                    Console.WriteLine(CommandHelper.ExitCommand);
                    break;
                case CommandHelper.ExitCommand:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(CommandHelper.UnknownCommandMessage);
                    break;
            }
        }
    }
}

file static class CommandHelper
{
    public const string InputSymbol = ">";
    public const string ExitCommand = "exit";
    public const string HelpCommand = "help";
    public const string CreateRiskProfileCommand = "create_rsf";
    public const string CreateRiskProfileDescriptionCommand = "create_rsf_des";
    public const string UnknownCommandMessage = "Unknown command, use help to see available commands.";
}