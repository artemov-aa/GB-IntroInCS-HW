// Задача 47
// Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

float[,] FillRandomMatrix(int rows = 4, int columns = 4, int digitsOfRndValue = 1)
{
    float[,] matrix = new float[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = (float)(Math.Round(((2 * rnd.NextDouble()) - 1), 2)
                            * Math.Pow(10, digitsOfRndValue));
        }
    }

    return matrix;
}

void PrintMatrix(float[,] matrix)
{
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

Console.Clear();
float[,] mtrx = FillRandomMatrix();
PrintMatrix(mtrx);