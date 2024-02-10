using Erm.BussinessLayer;
using Erm.DataAccess;

internal class Program 
{
    static void Main()
    {
        IRiskProfileService riskProfileService = new RiskProfileService();

        string cmd = String.Empty;
        while (!cmd.Equals(CommandHelper.ExitCommand))
        {

            try
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine(CommandHelper.InputSymbol);
                cmd = Console.ReadLine();

                switch (cmd)
                {
                    case CommandHelper.GetRiskProfileCommand:
                        Console.WriteLine("Enter risk profile name for get:");
                        string rpNameToGet = Console.ReadLine();
                        RiskProfile riskProfile = riskProfileService.Get(rpNameToGet);
                        Console.WriteLine($"Get {riskProfile.RiskName}");
                        break;
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
                    case CommandHelper.UpdateRiskProfileCommand:
                        Console.WriteLine("Enter risk profile name for update:");
                        string rpNameToUpdate = Console.ReadLine();
                        Console.WriteLine("Enter new risk profile name:");
                        string rpNewName = Console.ReadLine();
                        Console.WriteLine("Enter risk profile description:");
                        string rpDescriptionToUpdate = Console.ReadLine();
                        Console.WriteLine("Enter new business process:");
                        string rpBusinessProcessToUpdate = Console.ReadLine();
                        int rpOccurreceProbabilityToUpdate;
                        Console.WriteLine("Enternew occurrence probability:");
                        while (!int.TryParse(Console.ReadLine(), out rpOccurreceProbabilityToUpdate))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer value for occurrence probability:");
                        }
                        int rpPotentialBusinessImpactToUpdate;
                        Console.WriteLine("Enter new potential business impact:");
                        while (!int.TryParse(Console.ReadLine(), out rpPotentialBusinessImpactToUpdate))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer value for potential business impact:");
                        }

                        RiskProfileInfo riskProfileInfoToUpdate = new()
                        {
                            Name = rpNewName,
                            Description = rpDescriptionToUpdate,
                            BusinessProcess = rpBusinessProcessToUpdate,
                            OccurreceProbability = rpOccurreceProbabilityToUpdate,
                            PotentialBusinessImpact = rpPotentialBusinessImpactToUpdate
                        };

                        riskProfileService.Update(rpNameToUpdate, riskProfileInfoToUpdate);
                        break;
                    case CommandHelper.DeleteRiskProfileCommand: 
                        Console.WriteLine("Enter risk profile name for delete:");
                        string rpNameToDelete = Console.ReadLine();
                        riskProfileService.Delete(rpNameToDelete);
                        break;
                    case CommandHelper.HelpCommand:
                        Console.WriteLine("> Available commands:");
                        Console.WriteLine(CommandHelper.CreateRiskProfileCommand);
                        Console.WriteLine(CommandHelper.HelpCommand);
                        Console.WriteLine(CommandHelper.ExitCommand);
                        Console.WriteLine(CommandHelper.GetRiskProfileCommand);
                        Console.WriteLine(CommandHelper.UpdateRiskProfileCommand);
                        Console.WriteLine(CommandHelper.DeleteRiskProfileCommand);
                        Console.WriteLine(CommandHelper.CountRiskProfileCommand);
                        break;
                    case CommandHelper.ExitCommand:
                        Console.WriteLine("Exiting...");
                        break;
                    case CommandHelper.CountRiskProfileCommand:
                        Console.WriteLine("Enter risk level name for count:");
                        string rlNameToCount = Console.ReadLine();
                        double count = riskProfileService.CalculateRisk(rlNameToCount);
                        Console.WriteLine($"Count {count}");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(CommandHelper.UnknownCommandMessage);
                        break;
                }
            } catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(CommandHelper.InputSymbol + ex.Message);
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
    public const string GetRiskProfileCommand = "get_rsf";
    public const string UpdateRiskProfileCommand = "update_rsf";
    public const string DeleteRiskProfileCommand = "delete_rsf";
    public const string CountRiskProfileCommand = "count_rsf";
}