// Задача 36
// Задайте одномерный массив, заполненный случайными числами.
// Найдите сумму элементов, стоящих на нечётных позициях.
// [3, 7, 23, 12] -> 19
// [-4, -6, 89, 6] -> 0

int[] FillArray(int size =10, int minValue = 0, int maxValue = 100)
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

int SumOfNumbersOnEvenPos(int[] array)
{
    int sum = 0;
    for (int i = 1; i < array.Length; i +=2)
    {
        sum += array[i];
    }

    return sum;
}
    
Console.Clear();

int[] array = FillArray(4, -10, 50);
PrintArray(array);

Console.WriteLine($"Сумма элементов, стоящих на нечётных позициях равна {SumOfNumbersOnEvenPos(array)}");