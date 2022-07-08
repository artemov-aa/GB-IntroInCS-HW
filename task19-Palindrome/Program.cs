// Задача 19.
// Напишите программу, которая принимает на вход пятизначное число
// и проверяет, является ли оно палиндромом.
// 14212 -> нет
// 12821 -> да
// 23432 -> да

string CheckInput(string input, int numberLength)
{
    while (!int.TryParse(input, out int result) || result < 0 || input.Length != numberLength)
    {
        Console.Write($"Неверный ввод! \nВведите {numberLength}-значное натуральное число: ");
        input = Console.ReadLine();
    }
    return input;
}

void IsItA5DigitPalindrome(string number)
{    
    if ((number[0] == number[4]) && (number[1] == number[3]))
        Console.WriteLine("Введенное число - палиндром.");
    else
        Console.WriteLine("Введенное число - не палиндром.");
}

Console.Write("Введите пятизначное натуральное число: ");

IsItA5DigitPalindrome(CheckInput(Console.ReadLine(), 5));