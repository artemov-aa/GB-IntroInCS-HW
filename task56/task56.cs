// Задача 56
// Задайте прямоугольный двумерный массив. Напишите программу,
// которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

Console.Clear();
PrintTitle("Задача 56. Строка массива с наименьшей суммой");

int rows        = InputNaturalNumber("Введите количество строк массива: ");
int columns     = InputNaturalNumber("Введите количество столбцов массива: ");
int minValue    = InputIntegerNumber("Введите минимальное значение для элементов массива: ");
int maxValue    = InputIntegerNumber("Введите максимальное значение для элементов массива: ");

int[,] array = CreateMatrix(rows, columns, minValue, maxValue);
Console.WriteLine("\nИсходная матрица:\n");
PrintMatrix(array);

int row = RowMinSum(array);
Console.WriteLine($"Строка с наименьшей суммой элементов: {row} строка.");


void PrintTitle(string message)
{
    string underline = new string('-', message.Length);
    Console.WriteLine($"{message}\n{underline}\n");
}

int InputNaturalNumber(string message)
{
    Console.Write(message);
    int number = VerifyNaturalNumber(Console.ReadLine());
    return number;
}

int InputIntegerNumber(string message)
{
    Console.Write(message);
    int number = VerifyIntegerNumber(Console.ReadLine());
    return number;
}

int VerifyNaturalNumber(string input)
{
    int result;
    while (!int.TryParse(input, out result) || result < 1)
    {
        Console.Write("Неверный ввод! \nВведите натуральное число: ");
        input = Console.ReadLine();
    }
    return result;
}

int VerifyIntegerNumber(string input)
{
    int result;
    while (!int.TryParse(input, out result))
    {
        Console.Write("Неверный ввод! \nВведите целое число: ");
        input = Console.ReadLine();
    }
    return result;
}

int[,] CreateMatrix(int rows = 4, int columns = 4, int min = 0, int max = 10)
{
    int[,] matrix = new int[rows, columns];
    var rnd = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    int rowsLength = matrix.GetLength(0);
    int columnsLength = matrix.GetLength(1);
    const int widthOfColumn = 3;
    for (int i = 0; i < rowsLength; i++)
    {
        for (int j = 0; j < columnsLength; j++)
        {
            if (j == 0) Console.Write(" | ");
            Console.Write($"{matrix[i, j],widthOfColumn} | ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int RowMinSum(int[,] matrix)
{
    int rowsLength = matrix.GetLength(0), columnsLength = matrix.GetLength(1);
    int sum = 0, minSum = 0;
    int row = 0;
    for (int i = 0; i < rowsLength; i++)
    {
        for (int j = 0; j < columnsLength; j++)
        {
            if (i == 0)
            {
                sum += matrix[i, j];
                minSum = sum;
            }
            else sum += matrix[i, j];
        }
        if (sum < minSum)
        {
            minSum = sum;
            row = i;
        }
        sum = 0;
    }
    return row + 1;
}