// Задача 19.
// Напишите программу, которая принимает на вход пятизначное число
// и проверяет, является ли оно палиндромом.
// 14212 -> нет
// 12821 -> да
// 23432 -> да

bool IsItAPalindrome(string number)
{
    if ((number[0] == number[4]) && (number[1] == number[3]))
        return true;
    else
        return false;
}

Console.Write("Введите пятизначное число: ");
string input = Console.ReadLine();

while (!int.TryParse(input, out int result) || result < 0 || input.Length != 5)
{
    Console.Write($"Неверный ввод! \nВведите пятизначное натуральное число: ");
    input = Console.ReadLine();
}

if (IsItAPalindrome(input))
    Console.WriteLine("Введенное число - палиндром.");
else
    Console.WriteLine("Введенное число - не палиндром.");