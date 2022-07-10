// Задача 27
// Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
// 452 -> 11
// 82 -> 10
// 9012 -> 12

int SumOFDigitsInNumber(string number)
{
    int sumOfDigits = 0;
    for (int i = 0; i < number.Length; i++)
    {
        sumOfDigits += number[i] - '0';
    }

    return sumOfDigits;
}

Console.Clear();

string input = string.Empty;

do
{
    Console.Write("Введите натуральное число: ");
    input = Console.ReadLine();
}
while (!int.TryParse(input, out var result) || result < 0);

int sumOfDigits = SumOFDigitsInNumber(input);
Console.WriteLine($"Сумма цифр введенного числа равна {sumOfDigits}");

