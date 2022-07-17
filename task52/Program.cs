// Задача 52.
// Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

int[,] GetMatrix(int rows = 4, int columns = 4, int min = 0, int max = 10)
{
    int[,] matrix = new int[rows, columns];
    var rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    Console.Write("Исходная матрица:\n\n");

    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    const int widthOfColumn = 4;

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (j == 0) Console.Write(" | ");
            Console.Write($"{matrix[i, j],widthOfColumn} | ");
        }
        Console.WriteLine();
    }

    Console.WriteLine();
}

float[] ArithmeticMeanByColumns(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    float[] arithmeticMean = new float[columns];

    for (int i = 0; i < columns; i++)
    {
        int sum = 0;
        for (int j = 0; j < rows; j++) sum += matrix[j, i];
        arithmeticMean[i] = (float)sum / rows;
    }

    return arithmeticMean;
}

Console.Clear();

int[,] arr = GetMatrix();
PrintMatrix(arr);

float[] arr2 = ArithmeticMeanByColumns(arr);

Console.WriteLine("Среднее арифметическое элементов в каждом столбце:");
Console.WriteLine("[{0}]", string.Join(", ", arr2));