using RomanNumeralConverter;

Console.WriteLine();

var romanNumeral = "MMMCCCXXXIII";
var arabicAnswer = Methods.FromRoman(romanNumeral);
Console.WriteLine($"{romanNumeral} Converts To {arabicAnswer}");

Console.WriteLine();

var arabicNumber = 1234;
var romanAnswer = Methods.ToRoman(arabicNumber);
Console.WriteLine($"{arabicNumber} Converts To {romanAnswer}");
