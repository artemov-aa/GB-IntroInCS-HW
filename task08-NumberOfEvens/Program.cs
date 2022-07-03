// Задача 8.
// Напишите программу, которая на вход принимает число (N), а на выходе показывает все чётные числа от 1 до N.
// 5 -> 2, 4
// 8 -> 2, 4, 6, 8

Console.Clear();

int num = 0;

Console.WriteLine("Введите число: ");
num = Int32.Parse(Console.ReadLine());


Console.Write($"Вот все четные числа в ряду от 1 до {num}: ");

for (int i = 1; i <= num; i++)
{
    if ((i % 2) == 0)
        Console.Write($"{i} ");
}

Console.WriteLine();