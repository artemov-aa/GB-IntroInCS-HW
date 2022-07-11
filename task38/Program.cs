// Задача 38
// Задайте массив вещественных чисел.
// Найдите разницу между максимальным и минимальным элементов массива.
// [3 7 22 2 78] -> 76

int[] FillArray(int size = 10, int minValue = 0, int maxValue = 100)
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

int MinOrMaxValue(int[] array, bool maximum = true)
{
    int desiredValue = array[0];
    for (int i = 1; i < array.Length; i++)
    {
        if (maximum)
        {
            if (array[i] > desiredValue) desiredValue = array[i];
        }
        else if (array[i] < desiredValue) desiredValue = array[i];
    }

    return desiredValue;
}

Console.Clear();

int[] array = FillArray(10, 0, 50);
PrintArray(array);

int maxElement = MinOrMaxValue(array);
int minElement = MinOrMaxValue(array, false);
int difference = maxElement - minElement;

Console.WriteLine($"Максимальный элемент массива: {maxElement}");
Console.WriteLine($"Минимальный элемент массива: {minElement}");
Console.WriteLine($"{maxElement} - {minElement} = {difference}");