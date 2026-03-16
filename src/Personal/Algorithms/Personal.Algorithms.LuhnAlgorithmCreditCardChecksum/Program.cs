namespace Personal.Algorithms.LuhnAlgorithmCreditCardChecksum;

public class Program
{
    public static void Main()
    {
        var cardNumber1 = "4024657236950748"; // valid
        var cardNumber2 = "4024607236950748"; // invalid

        Console.WriteLine($"Validate {nameof(cardNumber1)}: {IsValid(cardNumber1)}");
        Console.WriteLine($"Validate {nameof(cardNumber2)}: {IsValid(cardNumber2)}");

        /*
        1. Analyze Credit Card number:
        
        4024 6572 3695 074|8 - Checksum / verification digit
        
        2. Start from right to left, ones in brackets to be kept as is, the others should be multiplied by 2 and if the resulting value exceeds 9 => subtract by 9.
        
        4(0)2(4) 6(5)7(2) 3(6)9(5) 0(7)4(8)
        <----------------------------------
        
        8 (as is)
        8 = 4 x 2 (double)
        7 (as is)
        0 = 0 x 2 (double)
        
        5 (as is)
        9 = 9 * 2 (double) = 18 (more than 10) => 18 - 9 (subtract 9)
        6 (as is)
        6 = 3 * 2 (double)
        
        2 (as is)
        5 = 7 * 2 (double) = 14 (more than 10) => 14 - 9 (subtract 9)
        5 (as is)
        3 = 6 * 2 (double) = 12 (more than 10) => 12 - 9 (subtract 9)
        
        4 (as is)
        4 = 2 * 2 (double) 
        0 (as is)
        8 = 4 * 2 (double)
        
        3. Sum all values:
        8 + 8 + 7 + 0 + 5 + 9 + 6 + 3 + 2 + 5 + 5 + 3 + 4 + 4 + 0 + 8 = 
        23 + 26 + 15 + 16 = 
        80
        
        4. Calculate modulus 10:
        80 % 10 = 0 => ✅ VALID
        
        5. How to generate the Checksum / verification digit from the card number:
        
        4024 6572 3695 074|?
        
        5.1. Calculate sum:
        
        (4 * 2) + 7 + (2 * 0) + 5 + (2 * 9 - 9) + 6 + (2 * 3) + 2 + (2 * 7 - 9) + 5 + (2 * 6 - 9) + 4 + (2 * 2) + 0  + (2 * 4) = 72
        
        5.2 Calculate modulus 10:
        
        72 % 10 = 2
        
        5.3. Subtract it from 10:
        
        10 - 2 = 8 => Checksum = 8
        */
    }

    /// <summary>
    /// Using the Luhn Algorithm (Modulus 10) was created by Hans Peter Luhn (1896–1964), a computer scientist working at IBM.
    /// He developed the algorithm in the 1950s while working at IBM.
    /// The method was patented in 1954 and granted in 1960.
    /// </summary>
    /// <param name="cardNumber">A 16-number card number, without trailing spaces.</param>
    /// <returns>Does the card number pass the checksum digit validation.</returns>
    public static bool IsValid(string cardNumber)
    {
        int sum = 0;
        bool shouldDouble = false;

        // Process digits from right to left
        for (int i = cardNumber.Length - 1; i >= 0; i--)
        {
            int digit = cardNumber[i] - '0';

            if (shouldDouble)
            {
                digit *= 2;

                if (digit > 9)
                    digit -= 9;
            }

            sum += digit;
            shouldDouble = !shouldDouble;
        }

        return (sum % 10 == 0);
    }
}
