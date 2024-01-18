using Newtonsoft.Json;
using RulesEngine.Models;

namespace DemoRulesEngine;

// https://www.nuget.org/packages/RulesEngine
// https://github.com/microsoft/RulesEngine
public class Program
{
    static async Task Main()
    {
        var thingToValidate = new ThingToValidate { Country = "india", LoyaltyFactor = 2, TotalPurchasesToDate = 5001 };

        await ExecuteWorkflowFromJsonAsync(thingToValidate);

        await ExecuteWorkflowFromObjectAsync(thingToValidate);
    }

    private static async Task ExecuteWorkflowFromJsonAsync(ThingToValidate thingToValidate)
    {
        var json = await File.ReadAllTextAsync("../../../workflow.json");
        var workflows = JsonConvert.DeserializeObject<Workflow[]>(json);

        var rulesEngine = new RulesEngine.RulesEngine(workflows);

        List<RuleResultTree> results = await rulesEngine.ExecuteAllRulesAsync("Discount", thingToValidate);

        foreach (var result in results)
        {
            Console.WriteLine($"{result.Rule.RuleName}: {result.IsSuccess}");
        }
    }

    private static async Task ExecuteWorkflowFromObjectAsync(ThingToValidate thingToValidate)
    {
        var workflows = new Workflow[]
        {
            new Workflow
            {
                WorkflowName = "Test",
                Rules = new List<Rule>
                {
                    new Rule
                    {
                        RuleName = "GiveDiscount10",
                        SuccessEvent = "10",
                        ErrorMessage = "One or more adjust rules failed.",
                        RuleExpressionType = RuleExpressionType.LambdaExpression,
                        Expression = "input1.country == \"india\" AND input1.loyaltyFactor <= 2 AND input1.totalPurchasesToDate >= 5000"
                    },
                    new Rule
                    {
                        RuleName = "GiveDiscount20",
                        SuccessEvent = "20",
                        ErrorMessage = "One or more adjust rules failed.",
                        RuleExpressionType = RuleExpressionType.LambdaExpression,
                        Expression = "input1.country == \"india\" AND input1.loyaltyFactor >= 3 AND input1.totalPurchasesToDate >= 10000"
                    }
                }
            }
        };

        var rulesEngine = new RulesEngine.RulesEngine(workflows);

        List<RuleResultTree> results = await rulesEngine.ExecuteAllRulesAsync("Test", thingToValidate);

        foreach (var result in results)
        {
            Console.WriteLine($"{result.Rule.RuleName}: {result.IsSuccess}");
        }
    }
}