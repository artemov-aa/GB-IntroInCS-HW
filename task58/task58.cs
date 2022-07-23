// Задача 58
// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, заданы 2 массива:

Console.Clear();
PrintTitle("Задача 58. Произведение матриц");

int rowsFirstMatrix        = InputNumber("Введите количество строк матрицы A: ", 0);
int columnsFirstMatrix     = InputNumber("Введите количество столбцов матрицы A: ", 0);
int rowsSecondMatrix       = InputNumber("Введите количество строк матрицы B: ", 0);
int columnsSecondMatrix    = InputNumber("Введите количество столбцов матрицы B: ", 0);

int[,] firstMatrix  = CreateMatrix(rowsFirstMatrix, columnsFirstMatrix);
int[,] secondMatrix = CreateMatrix(rowsSecondMatrix, columnsSecondMatrix);

Console.WriteLine("\nИсходные матрицы:\n");
PrintMatrix(firstMatrix);
PrintMatrix(secondMatrix);

int[,] productOfMatrices;
if (!MatrixProduct(firstMatrix, secondMatrix, out productOfMatrices))
    Console.WriteLine("Матрицы А и В не согласованы и не могут быть перемножены.");
else
{
    Console.WriteLine("Произведение матриц А и В:\n");
    PrintMatrix(productOfMatrices);
}

Console.WriteLine();




void PrintTitle(string message)
{
    string underline = new string('-', message.Length);
    Console.WriteLine($"{message}\n{underline}\n");
}

int InputNumber(string message, int typeOfNumber)
{
    Console.Write(message);
    string input = Console.ReadLine();
    int number = 0;
    switch (typeOfNumber)
    {
        case 0:
            while (!int.TryParse(input, out number) || number < 1)
            {
                Console.Write("Неверный ввод!\nВведите натуральное число: ");
                input = Console.ReadLine();
            }
            break;
        case 1:
            while (!int.TryParse(input, out number))
            {
                Console.Write("Неверный ввод!\nВведите целое число: ");
                input = Console.ReadLine();
            }
            break;
    }
    return number;
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

bool MatrixProduct(int[,] mtrxA, int[,] mtrxB, out int[,] mtrxProduct)
{
    int rowLenMtrxA = mtrxA.GetLength(0), rowLenMtrxB = mtrxB.GetLength(0);
    int colLenMtrxA = mtrxA.GetLength(1), colLenMtrxB = mtrxB.GetLength(1);
    mtrxProduct = new int[rowLenMtrxA, colLenMtrxB];
    int element = 0;
    if (colLenMtrxA != rowLenMtrxB) return false;
    for (int i = 0; i < rowLenMtrxA; i++)
        for (int j = 0; j < colLenMtrxB; j++)
        {
            for (int k = 0; k < colLenMtrxA; k++)
            {
                element += mtrxA[i, k] * mtrxB[k, j];
            }
            mtrxProduct[i, j] = element;
            element = 0;
        }
    return true;
}