// Задача 23
// Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
// 3 -> 1, 8, 27
// 5 -> 1, 8, 27, 64, 125

int[] TableOfCubes(int number)
{
    int[] cubes = new int[number];
    for (int i = 0; i < number; i++)
    {
        cubes[i] = (int)Math.Pow(i+1, 3);
    } 

    return cubes;
}

Console.Clear();

Console.Write("Введите число: ");
string input = Console.ReadLine();

int number = 0;
while (!int.TryParse(input, out number))
{
    Console.Write($"Неверный ввод! \nВведите натуральное число: ");
    input = Console.ReadLine();
}

foreach(int element in TableOfCubes(number))
{
    Console.Write($"{element.ToString()} ");
}
Console.WriteLine("\b \b");