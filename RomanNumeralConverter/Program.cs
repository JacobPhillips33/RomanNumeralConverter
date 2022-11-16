using RomanNumeralConverter;

var userContinue = "yes";

while (userContinue == "yes")
{
    Console.WriteLine("Would you like to: ");
    Console.WriteLine("1. Convert from Arabic \"Regular\" Numbers to Roman Numerals");
    Console.WriteLine("2. Convert from Roman Numerals to Arabic \"Regular\" Numbers");
    Console.WriteLine();
    Console.Write("Enter \"1\" or \"2\": ");

    var userChoice = Console.ReadLine();

    while (userChoice != "1" && userChoice != "2")
    {
        Console.WriteLine();
        Console.WriteLine("Invalid entry. Please enter \"1\" or \"2\"");
        userChoice = Console.ReadLine();
    }

    if (userChoice == "1")
    {
        Console.WriteLine();
        Console.Write("Please enter a number between 1-3999: ");

        var userInputParse = int.TryParse(Console.ReadLine(), out int userInput);

        while (!userInputParse || userInput < 1 || userInput > 3999)
        {
            Console.WriteLine();
            Console.Write("Invalid entry. Please enter a number between 1-3999: ");
            userInputParse = int.TryParse(Console.ReadLine(), out userInput);
        }

        var romanAnswer = Methods.ToRoman(userInput);
        Console.WriteLine();
        Console.WriteLine($"{userInput} --> {romanAnswer}");
    }

    else
    {
        Console.WriteLine();
        Console.WriteLine("Please enter a Roman Numeral between 1-3999 to be converted to an Arabic \"Regular\" Number:  ");
        var userInput = Console.ReadLine().ToUpper();
        Console.WriteLine();

        var arabicAnswer = Methods.FromRoman(userInput);

        while (arabicAnswer == 0)
        {
            Console.WriteLine("Invalid Roman Numeral. Please enter a valid Roman Numeral between 1-3999: ");
            userInput = Console.ReadLine().ToUpper();
            arabicAnswer = Methods.FromRoman(userInput);
            Console.WriteLine();
        }

        Console.WriteLine($"{userInput} --> {arabicAnswer}");
    }
    Console.WriteLine();
    Console.Write("Would you like to convert another number? \"Yes\" or \"No\": ");
    userContinue = Console.ReadLine().ToLower();
    Console.WriteLine();

    while (userContinue != "yes" && userContinue != "no")
    {
        Console.Write("Invalid entry. Please enter \"Yes\" or \"No\": ");
        userContinue = Console.ReadLine().ToLower();
        Console.WriteLine();
    }
}
Console.WriteLine("Thanks! Have a great day!");