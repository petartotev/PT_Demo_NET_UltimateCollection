namespace Personal.Algorithms.Greedy.Models;

public class GreedyGenerator
{
    public void ReturnMinNumberOfCoinsToGetAmount(int amount)
    {
        List<int> coins = new() { 1, 2, 5, 10, 20, 50, 100, 200 };

        var coinsCountTotal = 0;

        while (amount > 0 && coins.Count > 0)
        {
            var currentCoinValue = coins.Last();
            coins.Remove(currentCoinValue);

            var coinsCountUsedCurrently = amount / currentCoinValue;

            if (coinsCountUsedCurrently > 0)
            {
                Console.WriteLine($"{coinsCountUsedCurrently} coin(s) with value {currentCoinValue} used.");
            }

            coinsCountTotal += coinsCountUsedCurrently;

            amount -= currentCoinValue * coinsCountUsedCurrently;
        }

        Console.WriteLine($"{new string('=', 25)}\n{coinsCountTotal} coin(s) used in total.");
    }
}
