// Задача 34
// Задайте массив заполненный случайными положительными трёхзначными числами.
// Напишите программу, которая покажет количество чётных чисел в массиве.
// [345, 897, 568, 234] -> 2

int[] FillArray(int size = 10, int minValue = 100, int maxValue = 999)
{
    int[] array = new int[size];
    for (int i = 0; i < size; i++)
    {
        array[i] = new Random().Next(minValue, maxValue + 1);
    }
    return array;
}

void PrintArray(int[] array)
{
    Console.WriteLine(string.Join(", ", array));
}

int NumberOfEvens(int[] array)
{
    int countOfEvens = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] % 2 == 0) countOfEvens++;
    }

    return countOfEvens;
}

Console.Clear();

int[] array = FillArray(4);
PrintArray(array);

Console.WriteLine($"Количество четных чисел в массиве: {NumberOfEvens(array)}");

