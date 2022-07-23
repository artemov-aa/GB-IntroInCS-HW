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

Console.Write("Задайте количество строк матрицы: ");
int rows = VerifyIntegerNumber(Console.ReadLine());
Console.Write("Задайте количество столбцов матрицы: ");
int columns = VerifyIntegerNumber(Console.ReadLine());
Console.Write("Задайте минимальное значение элементов: ");
int min = VerifyIntegerNumber(Console.ReadLine());
Console.Write("Задайте максимальное значение элементов: ");
int max = VerifyIntegerNumber(Console.ReadLine());

int[,] array = GetMatrix(rows, columns, min, max);

Console.WriteLine("\nИсходная матрица:\n");
PrintMatrix(array);

int minSum;
MinSumByRows(array, out minSum);

Console.WriteLine($"Строка с наименьшей суммой элементов: {minSum + 1} строка.");

int VerifyIntegerNumber(string input)
{
    int result;

    while (!int.TryParse(input, out result))
    {
        Console.Write("Неверный ввод! \nВведите натуральное число -> ");
        input = Console.ReadLine();
    }

    return result;
}

int[,] GetMatrix(int rows = 4, int columns = 4, int min = 0, int max = 10)
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
    int rowsLength = matrix.GetLength(0), columnsLength = matrix.GetLength(1);
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

void MinSumByRows(int[,] matrix, out int numberOfRow)
{
    int rowsLength = matrix.GetLength(0), columnsLength = matrix.GetLength(1);
    int sum = 0, minSum = 0;
    numberOfRow = 0;

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
            numberOfRow = i;
        }

        sum = 0;
    }
}